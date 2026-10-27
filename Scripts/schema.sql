-- ============================================================
--  LaundryHub Database Schema
--  PostgreSQL 16
--  Run with: psql -U postgres -d laundryhub -f schema.sql
-- ============================================================

-- NOTE: Destructive DROP TABLE commands have been removed so running this
-- script does not drop existing database tables and data.
-- If a full clean reset is needed during development, manually execute:
-- DROP TABLE IF EXISTS order_status_log CASCADE;
-- DROP TABLE IF EXISTS orders CASCADE;
-- DROP TABLE IF EXISTS load_prices CASCADE;
-- DROP TABLE IF EXISTS service_types CASCADE;
-- DROP TABLE IF EXISTS customers CASCADE;
-- DROP TABLE IF EXISTS users CASCADE;

-- ─────────────────────────────────────────────
-- USERS (Admin, Staff, Customer accounts)
-- ─────────────────────────────────────────────
CREATE TABLE IF NOT EXISTS users (
    user_id       SERIAL PRIMARY KEY,
    username      VARCHAR(50)  UNIQUE NOT NULL,
    password_hash TEXT         NOT NULL,          -- BCrypt hash
    full_name     VARCHAR(100) NOT NULL,
    email         VARCHAR(150) UNIQUE NOT NULL,
    role          VARCHAR(20)  NOT NULL
                  CHECK (role IN ('Admin','Staff','Customer')),
    is_active     BOOLEAN      NOT NULL DEFAULT TRUE,
    created_at    TIMESTAMP    NOT NULL DEFAULT NOW()
);

-- ─────────────────────────────────────────────
-- CUSTOMERS (registered + walk-in)
-- ─────────────────────────────────────────────
CREATE TABLE IF NOT EXISTS customers (
    customer_id SERIAL PRIMARY KEY,
    user_id     INT          REFERENCES users(user_id) ON DELETE SET NULL,
    full_name   VARCHAR(100) NOT NULL,
    phone       VARCHAR(20)  UNIQUE NOT NULL,
    email       VARCHAR(150),
    address     TEXT,
    is_archived BOOLEAN      NOT NULL DEFAULT FALSE,
    created_at  TIMESTAMP    NOT NULL DEFAULT NOW()
);

-- ─────────────────────────────────────────────
-- SERVICE TYPES (Wash & Dry, Wash Only, etc.)
-- ─────────────────────────────────────────────
CREATE TABLE IF NOT EXISTS service_types (
    service_id     SERIAL         PRIMARY KEY,
    service_name   VARCHAR(80)    NOT NULL,
    price_per_kilo NUMERIC(10,2)  NOT NULL CHECK (price_per_kilo > 0),
    minimum_weight NUMERIC(5,2)   NOT NULL CHECK (minimum_weight > 0),
    is_active      BOOLEAN        NOT NULL DEFAULT TRUE
);

-- ─────────────────────────────────────────────
-- LOAD PRICES (fixed maximum load sizes)
-- ─────────────────────────────────────────────
CREATE TABLE IF NOT EXISTS load_prices (
    category      VARCHAR(40)  NOT NULL
                  CHECK (category IN ('Clothes','Bedsheets/Towels/Blankets')),
    load_size     VARCHAR(10)  NOT NULL
                  CHECK (load_size IN ('SMALL','MEDIUM','LARGE')),
    max_weight_kg NUMERIC(5,2) NOT NULL CHECK (max_weight_kg > 0),
    price         NUMERIC(10,2) NOT NULL CHECK (price > 0),
    PRIMARY KEY (category, load_size)
);

-- ─────────────────────────────────────────────
-- ORDERS
-- ─────────────────────────────────────────────
CREATE TABLE IF NOT EXISTS orders (
    order_id         SERIAL        PRIMARY KEY,
    order_number     VARCHAR(25)   UNIQUE NOT NULL,  -- e.g. LH-20261011-001
    customer_id      INT           NOT NULL REFERENCES customers(customer_id),
    service_id       INT           NOT NULL REFERENCES service_types(service_id),
    laundry_category VARCHAR(40)   NOT NULL DEFAULT 'Clothes'
                     CHECK (laundry_category IN ('Clothes','Bedsheets/Towels/Blankets')),
    weight_kg        NUMERIC(6,2)  NOT NULL CHECK (weight_kg > 0),
    total_amount     NUMERIC(10,2) NOT NULL CHECK (total_amount >= 0),
    status           VARCHAR(30)   NOT NULL DEFAULT 'Booked'
                     CHECK (status IN ('Booked','Washing','Drying','Ready for Pickup','Claimed','Cancelled')),
    cancel_reason    TEXT,
    cancel_request_status VARCHAR(10)
                     CHECK (cancel_request_status IS NULL OR cancel_request_status IN ('Pending','Approved','Rejected')),
    cancel_request_reason TEXT,
    cancel_requested_at   TIMESTAMP,	
    payment_recorded BOOLEAN       NOT NULL DEFAULT FALSE,
    amount_paid      NUMERIC(10,2) CHECK (amount_paid IS NULL OR amount_paid >= 0),
    created_by       INT           REFERENCES users(user_id),
    pickup_date      DATE,
    claimed_at       TIMESTAMP,
    is_archived      BOOLEAN       NOT NULL DEFAULT FALSE,
    created_at       TIMESTAMP     NOT NULL DEFAULT NOW(),
    updated_at       TIMESTAMP     NOT NULL DEFAULT NOW()
);

-- ─────────────────────────────────────────────
-- ORDER STATUS LOG (for audit trail)
-- ─────────────────────────────────────────────
CREATE TABLE IF NOT EXISTS order_status_log (
    log_id     SERIAL      PRIMARY KEY,
    order_id   INT         NOT NULL REFERENCES orders(order_id),
    old_status VARCHAR(30),
    new_status VARCHAR(30) NOT NULL,
    changed_by INT         REFERENCES users(user_id),
    changed_at TIMESTAMP   NOT NULL DEFAULT NOW(),
    notes      TEXT
);

-- ─────────────────────────────────────────────
-- INDEXES
-- ─────────────────────────────────────────────
CREATE INDEX IF NOT EXISTS idx_orders_customer    ON orders(customer_id);
CREATE INDEX IF NOT EXISTS idx_orders_status      ON orders(status);
CREATE INDEX IF NOT EXISTS idx_orders_created_at  ON orders(created_at);
CREATE INDEX IF NOT EXISTS idx_orders_number      ON orders(order_number);
CREATE INDEX IF NOT EXISTS idx_customers_phone    ON customers(phone);

-- ─────────────────────────────────────────────
-- CONSTRAINTS MIGRATION (for existing databases)
-- ─────────────────────────────────────────────
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM pg_constraint WHERE conname = 'customers_phone_key' OR conname = 'uq_customers_phone'
    ) THEN
        ALTER TABLE customers ADD CONSTRAINT uq_customers_phone UNIQUE (phone);
    END IF;

    IF NOT EXISTS (
        SELECT 1 FROM pg_constraint WHERE conname = 'chk_orders_total_amount'
    ) THEN
        ALTER TABLE orders ADD CONSTRAINT chk_orders_total_amount CHECK (total_amount >= 0);
    END IF;

    IF NOT EXISTS (
        SELECT 1 FROM pg_constraint WHERE conname = 'chk_orders_amount_paid'
    ) THEN
        ALTER TABLE orders ADD CONSTRAINT chk_orders_amount_paid CHECK (amount_paid IS NULL OR amount_paid >= 0);
    END IF;
END $$;

-- ─────────────────────────────────────────────
-- SEED: Default Admin account
-- Password: Admin@123  (BCrypt hash below)
-- CHANGE THIS PASSWORD after first login!
-- ─────────────────────────────────────────────
INSERT INTO users (username, password_hash, full_name, email, role)
VALUES (
    'admin@gmail.com',
    '$2a$11$N28/PDQK9RdJBQSnEF.ejeQQOTG5VZeEILHGnLgqbUtkZXyUJdxcK',
    'Shop Administrator',
    'admin@gmail.com',
    'Admin'
)
ON CONFLICT (username) DO NOTHING;

-- ─────────────────────────────────────────────
-- SEED: Default Staff account
-- Password: Staff@123  (BCrypt hash below)
-- ─────────────────────────────────────────────
INSERT INTO users (username, password_hash, full_name, email, role)
VALUES (
    'staff@gmail.com',
    '$2a$12$bqdcauyXLjzgZZVOy.ak1OOMlSsckfPeFil4oF.oWyTbBNpt6TliS',
    'Laundry Staff',
    'staff@gmail.com',
    'Staff'
)
ON CONFLICT (username) DO NOTHING;

-- ─────────────────────────────────────────────
-- SEED: Default Service Types
-- ─────────────────────────────────────────────
INSERT INTO service_types (service_name, price_per_kilo, minimum_weight)
SELECT 'Wash & Dry', 65.00, 4.0
WHERE NOT EXISTS (SELECT 1 FROM service_types WHERE service_name = 'Wash & Dry');

INSERT INTO service_types (service_name, price_per_kilo, minimum_weight)
SELECT 'Wash Only', 45.00, 4.0
WHERE NOT EXISTS (SELECT 1 FROM service_types WHERE service_name = 'Wash Only');

INSERT INTO service_types (service_name, price_per_kilo, minimum_weight)
SELECT 'Dry Only', 40.00, 4.0
WHERE NOT EXISTS (SELECT 1 FROM service_types WHERE service_name = 'Dry Only');

INSERT INTO service_types (service_name, price_per_kilo, minimum_weight)
SELECT 'Fold Only', 20.00, 1.0
WHERE NOT EXISTS (SELECT 1 FROM service_types WHERE service_name = 'Fold Only');

INSERT INTO load_prices (category, load_size, max_weight_kg, price) VALUES
    ('Clothes', 'SMALL', 5.00, 330.00),
    ('Clothes', 'MEDIUM', 8.00, 440.00),
    ('Clothes', 'LARGE', 15.00, 550.00),
    ('Bedsheets/Towels/Blankets', 'SMALL', 3.00, 440.00),
    ('Bedsheets/Towels/Blankets', 'MEDIUM', 5.00, 650.00),
    ('Bedsheets/Towels/Blankets', 'LARGE', 9.00, 1120.00)
ON CONFLICT (category, load_size) DO NOTHING;
