-- Updates the orders status check constraint to include 'Booked' and sets the default to 'Booked'
ALTER TABLE orders DROP CONSTRAINT IF EXISTS orders_status_check;
ALTER TABLE orders ADD CONSTRAINT orders_status_check 
    CHECK (status IN ('Booked','Washing','Drying','Ready for Pickup','Claimed','Cancelled'));
ALTER TABLE orders ALTER COLUMN status SET DEFAULT 'Booked';
