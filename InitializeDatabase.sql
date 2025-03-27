-- Initialize Database Script for Modern Hotel Management System
-- This script creates sample data for testing the application

USE ModernHotelDb;
GO

-- Clear existing data
DELETE FROM BookingServices;
DELETE FROM Bills;
DELETE FROM Bookings;
DELETE FROM Services;
DELETE FROM ServiceTypes;
DELETE FROM Rooms;
DELETE FROM RoomTypes;
DELETE FROM Customers;
DELETE FROM Users;
GO

-- Insert User Roles (These should match the UserRole enum in the application)
-- Note: The UserRole enum values are already defined in the application

-- Insert Users
INSERT INTO Users (Username, Email, FirstName, LastName, PasswordHash, PasswordSalt, PhoneNumber, Role, IsActive, CreatedAt)
VALUES 
('admin', 'admin@modernhotel.com', 'Admin', 'User', 'hashed_password_placeholder', 'salt_placeholder', '123-456-7890', 0, 1, GETDATE()),
('manager', 'manager@modernhotel.com', 'Manager', 'User', 'hashed_password_placeholder', 'salt_placeholder', '123-456-7891', 1, 1, GETDATE()),
('receptionist', 'receptionist@modernhotel.com', 'Receptionist', 'User', 'hashed_password_placeholder', 'salt_placeholder', '123-456-7892', 2, 1, GETDATE()),
('staff', 'staff@modernhotel.com', 'Staff', 'User', 'hashed_password_placeholder', 'salt_placeholder', '123-456-7893', 3, 1, GETDATE());
GO

-- Insert Room Types
INSERT INTO RoomTypes (Name, Description, BasePrice, Capacity, CreatedAt)
VALUES 
('Standard', 'Standard room with basic amenities', 100.00, 2, GETDATE()),
('Deluxe', 'Deluxe room with premium amenities', 150.00, 2, GETDATE()),
('Suite', 'Spacious suite with separate living area', 250.00, 4, GETDATE()),
('Family', 'Large room suitable for families', 200.00, 6, GETDATE()),
('Executive', 'Executive room with business facilities', 180.00, 2, GETDATE());
GO

-- Insert Rooms
INSERT INTO Rooms (Number, RoomTypeId, Floor, Status, Description, IsActive, CreatedAt)
VALUES 
('101', 1, 1, 0, 'Standard room with city view', 1, GETDATE()),
('102', 1, 1, 0, 'Standard room with garden view', 1, GETDATE()),
('103', 2, 1, 0, 'Deluxe room with city view', 1, GETDATE()),
('104', 2, 1, 0, 'Deluxe room with garden view', 1, GETDATE()),
('201', 3, 2, 0, 'Suite with city view', 1, GETDATE()),
('202', 3, 2, 0, 'Suite with garden view', 1, GETDATE()),
('203', 4, 2, 0, 'Family room with city view', 1, GETDATE()),
('204', 4, 2, 0, 'Family room with garden view', 1, GETDATE()),
('301', 5, 3, 0, 'Executive room with city view', 1, GETDATE()),
('302', 5, 3, 0, 'Executive room with garden view', 1, GETDATE());
GO

-- Insert Customers
INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, City, State, ZipCode, Country, IdentificationType, IdentificationNumber, DateOfBirth, CreatedAt)
VALUES 
('John', 'Doe', 'john.doe@example.com', '123-456-7890', '123 Main St', 'New York', 'NY', '10001', 'USA', 'Passport', 'AB123456', '1980-01-01', GETDATE()),
('Jane', 'Smith', 'jane.smith@example.com', '123-456-7891', '456 Elm St', 'Los Angeles', 'CA', '90001', 'USA', 'Driver License', 'DL987654', '1985-05-15', GETDATE()),
('Michael', 'Johnson', 'michael.johnson@example.com', '123-456-7892', '789 Oak St', 'Chicago', 'IL', '60601', 'USA', 'ID Card', 'ID654321', '1975-10-20', GETDATE()),
('Emily', 'Williams', 'emily.williams@example.com', '123-456-7893', '321 Pine St', 'Houston', 'TX', '77001', 'USA', 'Passport', 'CD789012', '1990-03-25', GETDATE()),
('David', 'Brown', 'david.brown@example.com', '123-456-7894', '654 Maple St', 'Philadelphia', 'PA', '19101', 'USA', 'Driver License', 'DL456789', '1982-07-12', GETDATE());
GO

-- Insert Service Types
INSERT INTO ServiceTypes (Name, Description, CreatedAt)
VALUES 
('Room Service', 'Food and beverage service delivered to the room', GETDATE()),
('Laundry', 'Cleaning and pressing of clothes', GETDATE()),
('Spa', 'Massage and wellness treatments', GETDATE()),
('Transportation', 'Airport transfers and local transportation', GETDATE()),
('Dining', 'Restaurant and bar services', GETDATE());
GO

-- Insert Services
INSERT INTO Services (Name, ServiceTypeId, Description, Price, IsAvailable, CreatedAt)
VALUES 
('Breakfast', 1, 'Continental breakfast delivered to room', 20.00, 1, GETDATE()),
('Lunch', 1, 'Lunch menu delivered to room', 30.00, 1, GETDATE()),
('Dinner', 1, 'Dinner menu delivered to room', 40.00, 1, GETDATE()),
('Shirt Laundry', 2, 'Washing and pressing of shirts', 10.00, 1, GETDATE()),
('Suit Cleaning', 2, 'Dry cleaning of suits', 25.00, 1, GETDATE()),
('Swedish Massage', 3, '60-minute Swedish massage', 80.00, 1, GETDATE()),
('Deep Tissue Massage', 3, '60-minute deep tissue massage', 100.00, 1, GETDATE()),
('Airport Transfer', 4, 'One-way transfer to/from airport', 50.00, 1, GETDATE()),
('City Tour', 4, '4-hour guided city tour', 120.00, 1, GETDATE()),
('Restaurant Reservation', 5, 'Reservation at hotel restaurant', 0.00, 1, GETDATE());
GO

-- Insert Bookings
INSERT INTO Bookings (RoomId, CustomerId, BookingReference, CheckInDate, CheckOutDate, Adults, Children, Status, TotalAmount, Notes, CreatedById, CreatedAt)
VALUES 
(1, 1, 'BK-20250101-001', '2025-01-01', '2025-01-05', 2, 0, 0, 400.00, 'Early check-in requested', 1, GETDATE()),
(3, 2, 'BK-20250105-001', '2025-01-05', '2025-01-10', 2, 0, 0, 750.00, 'Late check-out requested', 1, GETDATE()),
(5, 3, 'BK-20250110-001', '2025-01-10', '2025-01-15', 2, 2, 0, 1250.00, 'Extra bed requested', 1, GETDATE()),
(7, 4, 'BK-20250115-001', '2025-01-15', '2025-01-20', 2, 4, 0, 1000.00, 'Connecting rooms requested', 1, GETDATE()),
(9, 5, 'BK-20250120-001', '2025-01-20', '2025-01-25', 2, 0, 0, 900.00, 'Business center access requested', 1, GETDATE());
GO

-- Insert Booking Services
INSERT INTO BookingServices (BookingId, ServiceId, Quantity, Price, ServiceDate, Notes, CreatedAt)
VALUES 
(1, 1, 2, 20.00, '2025-01-02', 'Breakfast for 2', GETDATE()),
(1, 4, 1, 10.00, '2025-01-03', 'Shirt laundry service', GETDATE()),
(2, 3, 2, 40.00, '2025-01-06', 'Dinner for 2', GETDATE()),
(2, 6, 1, 80.00, '2025-01-07', 'Swedish massage', GETDATE()),
(3, 8, 1, 50.00, '2025-01-10', 'Airport transfer', GETDATE()),
(3, 9, 1, 120.00, '2025-01-12', 'City tour for family', GETDATE()),
(4, 2, 4, 30.00, '2025-01-16', 'Lunch for family', GETDATE()),
(4, 5, 2, 25.00, '2025-01-17', 'Suit cleaning', GETDATE()),
(5, 7, 2, 100.00, '2025-01-21', 'Deep tissue massage for 2', GETDATE()),
(5, 10, 1, 0.00, '2025-01-22', 'Restaurant reservation', GETDATE());
GO

-- Insert Bills
INSERT INTO Bills (BookingId, BillNumber, IssuedById, IssueDate, DueDate, PaidDate, Subtotal, TaxAmount, DiscountAmount, TotalAmount, PaidAmount, Status, PaymentMethod, Notes, CreatedAt)
VALUES 
(1, 'BILL-20250105-001', 1, '2025-01-05', '2025-01-05', '2025-01-05', 430.00, 34.40, 0.00, 464.40, 464.40, 2, 0, 'Payment received in full', GETDATE()),
(2, 'BILL-20250110-001', 1, '2025-01-10', '2025-01-10', '2025-01-10', 870.00, 69.60, 0.00, 939.60, 939.60, 2, 1, 'Payment received in full', GETDATE()),
(3, 'BILL-20250115-001', 1, '2025-01-15', '2025-01-15', '2025-01-15', 1420.00, 113.60, 50.00, 1483.60, 1483.60, 2, 2, 'Discount applied for loyal customer', GETDATE()),
(4, 'BILL-20250120-001', 1, '2025-01-20', '2025-01-20', '2025-01-20', 1120.00, 89.60, 0.00, 1209.60, 1209.60, 2, 0, 'Payment received in full', GETDATE()),
(5, 'BILL-20250125-001', 1, '2025-01-25', '2025-01-25', '2025-01-25', 1100.00, 88.00, 0.00, 1188.00, 1188.00, 2, 1, 'Payment received in full', GETDATE());
GO

PRINT 'Database initialized with sample data.';
