CREATE DATABASE shoppingMVCDB;USE shoppingMVCDB;CREATE TABLE Mens_Product (  pId INT PRIMARY KEY,  pName VARCHAR(50),  pCategory VARCHAR(50),  pPrice INT,  pIsInStock BIT);CREATE TABLE Womens_Product (  pId INT PRIMARY KEY,  pName VARCHAR(50),  pCategory VARCHAR(50),  pPrice INT,  pIsInStock BIT);CREATE TABLE Kids_Product (  pId INT PRIMARY KEY,  pName VARCHAR(50),  pCategory VARCHAR(50),  pPrice INT,  pIsInStock BIT);INSERT INTO Mens_Product (pId, pName, pCategory, pPrice, pIsInStock) VALUES  (1, 'Men Shirt', 'Clothing', 240, 1),  (2, 'Men Jeans', 'Clothing', 390, 0),  (3, 'Men Watch', 'Accessories', 990, 1),  (4, 'Men Shoes', 'Footwear', 590, 1),  (5, 'Men Hat', 'Accessories', 140, 0);INSERT INTO Womens_Product (pId, pName, pCategory, pPrice, pIsInStock) VALUES  (1, 'Women Dress', 'Clothing', 490, 1),  (2, 'Women Shoes', 'Footwear', 390, 0),  (3, 'Women Bag', 'Accessories', 890, 1),  (4, 'Women Necklace', 'Accessories', 290, 1),  (5, 'Women Jacket', 'Clothing', 790, 0);INSERT INTO Kids_Product (pId, pName, pCategory, pPrice, pIsInStock) VALUES  (1, 'Kids T-Shirt', 'Clothing', 140, 1),  (2, 'Kids Shorts', 'Clothing', 190, 0),  (3, 'Kids Sneakers', 'Footwear', 290, 1),  (4, 'Kids Backpack', 'Accessories', 240, 1),  (5, 'Kids Sunglasses', 'Accessories', 90, 0);  select * from Mens_Product  select * from Womens_Product  select * from Kids_Product  CREATE TABLE Holiday_Product (  pId INT PRIMARY KEY,  pName VARCHAR(50),  pCategory VARCHAR(50),  pPrice INT,  pIsInStock BIT);INSERT INTO Holiday_Product (pId, pName, pCategory, pPrice, pIsInStock) VALUES  (1, 'Holiday 1', 'Clothing', 140, 1),  (2, 'Holiday 2', 'Clothing', 190, 0),  (3, 'Holiday 3', 'Footwear', 290, 1),  (4, 'Holiday 4', 'Accessories', 240, 1),  (5, 'Holiday 5', 'Accessories', 90, 0);