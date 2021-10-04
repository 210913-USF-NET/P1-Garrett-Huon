/*Table for Customers: name and email*/

CREATE TABLE Customers(
    ID INT PRIMARY KEY IDENTITY(1000,1),
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(50) NOT NULL

);

INSERT INTO Customers (Name, Email)
VALUES ('Mary', 'Mary.Lamb@gmail.com'),
('Admin', 'Admin@boxshoppe.com');


CREATE TABLE Store(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(100) NOT NULL,
    City VARCHAR(50) NOT NULL,
    State VARCHAR(50) NOT NULL

);

INSERT INTO Store (Name, Address, City, State)
VALUES 
('Bag''em Up', '3848 Handl Blvd', 'Los Angeles', 'CA'),
('Cardboard Bros', '5346 Boxing St', 'Akron', 'OH'),
('Luggin'' It Around', '6892 Carry On Way', 'Omaha', 'NE'),
('Plasticly See Through', '2674 Tupper Ln', 'Savannah', 'GA'),
('A Freight of a Good Time', '4962 Brig St', 'Juneau', 'AL');


SELECT * FROM Customers;


CREATE TABLE ShopOrder(                     /*After everything else*/
    ID INT PRIMARY KEY IDENTITY(100,1),
    Address VARCHAR(100) NOT NULL,
    City VARCHAR(100) NOT NULL,
    State VARCHAR(100) NOT NULL,
    CName VARCHAR(100) NOT NULL,
    Payment VARCHAR(100) NOT NULL,
    Cost DECIMAL(20,2) NOT NULL,
    LineId INT FOREIGN KEY REFERENCES LineItem(ID)

);
SELECT * FROM ShopOrder;
CREATE TABLE StoreInv(
    ID INT Primary Key IDENTITY(500,1),
    CH CHAR(3),
    ProdName VARCHAR(100) NOT NULL,
    ProdPrice DECIMAL(10,2) NOT NULL,
    ProdStock INT NOT Null,
    StoreId INT FOREIGN KEY REFERENCES Store(ID) ON DELETE CASCADE NOT NULL

);

INSERT INTO StoreInv(CH, ProdName, ProdPrice, ProdStock, StoreId)
VALUES 
('C','Super 12x12x12', 8.99, 30, 2),
('C','Crazy 8x8x8', 7.99, 20, 2),
('C','Cool 8x4x4', 4.99, 25, 2),
('C','Rad 4x4x4', 1.99, 35, 2),

('B','Zebra Backpack', 65.99, 32, 1),
('B','Leather Satchel', 49.99, 26, 1),
('B','Light Blue Tote', 29.99, 15, 1),
('B','Reusable Grocery Bag', 5.99, 40, 1),

('L','Professional Briefcase', 45.99, 20, 3),
('L','Purple Carry-On', 69.99, 10, 3),
('L','Standard Suitcase', 49.99, 20, 3),
('L','Nifty Plane Bag', 20.99, 3, 3),

('P','45gal Storage Bin', 19.99, 12, 4),
('P','30 qt Storage Container', 13.00, 15, 4),
('P','Deep Bin w/ Latch Lid', 17.99, 20, 4),
('P','Tupperware Pack', 6.99, 40, 4),

('F','Sea-Ready Freight Container', 319.99, 9, 5),
('F','Stable Truck Shipping Container', 275.00, 6, 5);

CREATE TABLE LineItem(
   ID INT PRIMARY KEY IDENTITY (10000,1),
   Quant INT NOT NULL,
   StoreId INT FOREIGN KEY REFERENCES Store(ID) ON DELETE CASCADE NOT NULL,
   ProdId INT FOREIGN KEY REFERENCES StoreInv(ID) 
);


SELECT StoreInv.ID, StoreInv.ProdName, StoreInv.StoreId From StoreInv 
WHERE StoreInv.StoreId = 1 ;
SELECT * FROM StoreInv;
SELECT * FROM LineItem;
DELETE From StoreInv where ProdPrice =5.94;
DELETE FROM ShopOrder;
DELETE FROM LineItem;

