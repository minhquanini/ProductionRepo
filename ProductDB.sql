CREATE DATABASE ProductDB

CREATE TABLE Brands(
ID int not null PRIMARY KEY IDENTITY(1,1),
Name varchar(256) not null,
Description nvarchar(max)
)

CREATE TABLE Users(
ID int not null PRIMARY KEY IDENTITY(1,1),
UserType int not null,
UserName nvarchar(50) not null,
Email varchar(50) not null,
DateOfBirth Datetime
)

CREATE TABLE Products(
ID int not null PRIMARY KEY IDENTITY(1,1),
ProductName nvarchar(256) not null,
Description nvarchar(max),
Price decimal not null,
Color nvarchar(10) not null,
DateCreated Datetime not null,
AvailabilityStatus int not null,
BrandID int not null FOREIGN KEY REFERENCES Brands(ID)
)

CREATE TABLE Reviews(
ID int not null PRIMARY KEY IDENTITY(1,1),
Rating int,
Comment nvarchar(max) not null,
ProductID int not null FOREIGN KEY REFERENCES Products(ID),
UserID int not null FOREIGN KEY REFERENCES Users(ID)
)

--- Insert some dummy data------

INSERT INTO Users(UserType,UserName,Email,DateOfBirth) 
VALUES
(1,'Messi','messi@gmail.com','1987-06-24 00:00:00.000'),
(2,'Ronaldo','ronaldo@gmail.com','1985-02-05 00:00:00.000'),
(2,'Iniesta','iniesta@gmail.com','1984-05-11 00:00:00.000'),
(1,'Xavi','xavi@gmail.com','1980-01-25 00:00:00.000')

INSERT INTO Brands(Name,Description) 
VALUES
('Apple','America Brand'),
('Samsung','Korea Brand'),
('Xiaomi','China Brand'),
('BPhone','Vietnam Brand')

INSERT INTO Products (ProductName,Description,Price,Color,DateCreated,AvailabilityStatus,BrandID)
VALUES
('Iphone 7 Plus', 'Iphone seven plus', 1000,'Black','2080-01-25 00:00:00.000',1,1),
('Samsung A8', 'Samsung A eight', 650,'Silver','2080-01-25 00:00:00.000',2,2),
('Samsung S10 Plus', 'Samsung S ten plus', 1100,'Black','2080-01-25 00:00:00.000',3,2),
('Xiaomi Redmi Note 7', 'Xiaomi Redmi Note seven', 250,'Pink','2080-01-25 00:00:00.000',1,3),
('Samsung Note 10 Plus', 'Samsung Note ten Plus',1200,'Silver', '2080-01-25 00:00:00.000',2,2),
('Iphone 8 Plus', 'Iphone eight plus', 1000,'White','2080-01-25 00:00:00.000',1,1),
('Iphone X', 'Iphone x', 1400,'White','2080-01-25 00:00:00.000',1,1),
('Iphone Xs Max', 'Iphone xs max', 1500,'Yellow','2080-01-25 00:00:00.000',3,1),
('Bphone 3', 'B phone three', 400,'Black','2080-01-25 00:00:00.000',1,4),
('Xiaomi Redmi 8 Lite', 'Xiaomi Redmi Eight Lite', 230,'Yellow','2080-01-25 00:00:00.000',2,3),
('Bphone 2', 'B phone two', 200,'Black','2080-01-25 00:00:00.000',3,4)

