ALTER TABLE orders
    ADD COLUMN IF NOT EXISTS cancel_request_status VARCHAR(10),
    ADD COLUMN IF NOT EXISTS cancel_request_reason TEXT,
    ADD COLUMN IF NOT EXISTS cancel_requested_at   TIMESTAMP;

ALTER TABLE orders DROP CONSTRAINT IF EXISTS orders_cancel_request_status_check;
ALTER TABLE orders
    ADD CONSTRAINT orders_cancel_request_status_check
    CHECK (cancel_request_status IS NULL
           OR cancel_request_status IN ('Pending','Approved','Rejected'));