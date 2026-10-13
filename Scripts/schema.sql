-- ============================================================
--  LaundryHub Database Schema
--  PostgreSQL 16
--  Run with: psql -U postgres -d laundryhub -f schema.sql
-- ============================================================

-- Drop existing tables (for clean re-run during dev)
DROP TABLE IF EXISTS order_status_log CASCADE;
DROP TABLE IF EXISTS orders CASCADE;
DROP TABLE IF EXISTS service_types CASCADE;
DROP TABLE IF EXISTS customers CASCADE;
DROP TABLE IF EXISTS users CASCADE;

-- ─────────────────────────────────────────────
-- USERS (Admin, Staff, Customer accounts)
-- ─────────────────────────────────────────────
CREATE TABLE users (
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
CREATE TABLE customers (
    customer_id SERIAL PRIMARY KEY,
    user_id     INT          REFERENCES users(user_id) ON DELETE SET NULL,
    full_name   VARCHAR(100) NOT NULL,
    phone       VARCHAR(20)  NOT NULL,
    email       VARCHAR(150),
    address     TEXT,
    is_archived BOOLEAN      NOT NULL DEFAULT FALSE,
    created_at  TIMESTAMP    NOT NULL DEFAULT NOW()
);

-- ─────────────────────────────────────────────
-- SERVICE TYPES (Wash & Dry, Wash Only, etc.)
-- ─────────────────────────────────────────────
CREATE TABLE service_types (
    service_id     SERIAL         PRIMARY KEY,
    service_name   VARCHAR(80)    NOT NULL,
    price_per_kilo NUMERIC(10,2)  NOT NULL CHECK (price_per_kilo > 0),
    minimum_weight NUMERIC(5,2)   NOT NULL CHECK (minimum_weight > 0),
    is_active      BOOLEAN        NOT NULL DEFAULT TRUE
);

-- ─────────────────────────────────────────────
-- ORDERS
-- ─────────────────────────────────────────────
CREATE TABLE orders (
    order_id         SERIAL        PRIMARY KEY,
    order_number     VARCHAR(25)   UNIQUE NOT NULL,  -- e.g. LH-20261011-001
    customer_id      INT           NOT NULL REFERENCES customers(customer_id),
    service_id       INT           NOT NULL REFERENCES service_types(service_id),
    weight_kg        NUMERIC(6,2)  NOT NULL CHECK (weight_kg > 0),
    total_amount     NUMERIC(10,2) NOT NULL,
    status           VARCHAR(30)   NOT NULL DEFAULT 'Washing'
                     CHECK (status IN ('Washing','Drying','Ready for Pickup','Claimed','Cancelled')),
    cancel_reason    TEXT,
    payment_recorded BOOLEAN       NOT NULL DEFAULT FALSE,
    amount_paid      NUMERIC(10,2),
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
CREATE TABLE order_status_log (
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
CREATE INDEX idx_orders_customer    ON orders(customer_id);
CREATE INDEX idx_orders_status      ON orders(status);
CREATE INDEX idx_orders_created_at  ON orders(created_at);
CREATE INDEX idx_orders_number      ON orders(order_number);
CREATE INDEX idx_customers_phone    ON customers(phone);

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
);

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
);

-- ─────────────────────────────────────────────
-- SEED: Default Service Types
-- ─────────────────────────────────────────────
INSERT INTO service_types (service_name, price_per_kilo, minimum_weight) VALUES
    ('Wash & Dry',   65.00, 4.0),
    ('Wash Only',    45.00, 4.0),
    ('Dry Only',     40.00, 4.0),
    ('Fold Only',    20.00, 1.0);
