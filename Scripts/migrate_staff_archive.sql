-- Adds is_archived column to users table for staff archive/restore feature
ALTER TABLE users ADD COLUMN IF NOT EXISTS is_archived BOOLEAN NOT NULL DEFAULT FALSE;
