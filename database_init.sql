USE master
DROP DATABASE IF EXISTS SolarPanelInstallationDatabase
GO
CREATE DATABASE SolarPanelInstallationDatabase
GO
USE SolarPanelInstallationDatabase
GO
DROP TABLE IF EXISTS Storage
DROP TABLE IF EXISTS LoginInformation
DROP TABLE IF EXISTS OrderEntries
DROP TABLE IF EXISTS Inventory
DROP TABLE IF EXISTS ProjectLogEntries
DROP TABLE IF EXISTS Orders
DROP TABLE IF EXISTS Parts
DROP TABLE IF EXISTS Projects
DROP TABLE IF EXISTS Persons
GO
CREATE TABLE Persons(
	PersonID		INT IDENTITY (1, 1) PRIMARY KEY,
	FirstName		VARCHAR(20) NOT NULL,
	LastName		VARCHAR(20) NOT NULL,
	Job				VARCHAR(20) NOT NULL,
)
GO
CREATE TABLE LoginInformation(
	PersonID		INT REFERENCES Persons(PersonID) NOT NULL,
	Email			VARCHAR(50) UNIQUE NOT NULL,
	PasswordHash	VARCHAR(200) NOT NULL
)
GO
CREATE TABLE Projects(
	ProjectID		INT IDENTITY (1, 1) PRIMARY KEY,
	ProjectName		VARCHAR(50) UNIQUE NOT NULL,
	SpecialistID	INT REFERENCES Persons (PersonID) NOT NULL,
	ProjectStatus	VARCHAR(20) NOT NULL,
	ProjectDescription VARCHAR(250) NULL,
	ClientName		VARCHAR(50) NULL,
	ProjectLocation VARCHAR(50) NULL,	
	EstimatedHours	INT NULL,			-- for completing the work
	PricePerHour	DECIMAL NULL		-- hourly rate
)
GO
CREATE TABLE ProjectLogEntries( -- table for logging information about projects, not yet used!
	ProjectLogEntryID	INT IDENTITY (1, 1) PRIMARY KEY,
	ProjectID			INT REFERENCES Projects (ProjectID) NOT NULL,
	TimeOfStatus		DATETIME NOT NULL,
	ProjectStatus		VARCHAR(20) NOT NULL
)
GO
CREATE TABLE Parts(
		PartID				INT IDENTITY (1, 1) PRIMARY KEY,
		PartName			VARCHAR(50) UNIQUE NOT NULL,
		PartDescription		VARCHAR(250) NULL,
		CountPerCompartment INT NOT NULL, -- how many parts fit in a compartment
		CurrentPrice		DECIMAL NULL  -- can be NULL if the price is not known
)
GO
CREATE TABLE Inventory( -- with this table we only store parts that are actually in the storage
	PartID				INT PRIMARY KEY REFERENCES Parts (PartID) NOT NULL,
	NumInStorage		INT NOT NULL 
)
GO
CREATE TABLE Storage(
	StorageRow				INT NOT NULL,
	StorageColumn			INT NOT NULL,
	StorageLevel			INT NOT NULL,
	PartID					INT REFERENCES Parts (PartID) NULL, -- what part is stored in the compartment, NULL if the compartment is empty
	PartCount				INT NOT NULL, -- number of parts in the compartment
	CONSTRAINT PK_storage PRIMARY KEY (StorageRow, StorageColumn, StorageLevel),
	CONSTRAINT chk_partcount_notnegative CHECK (PartCount >= 0)
)
GO
CREATE TABLE Orders(
	OrderID			INT IDENTITY (1, 1) PRIMARY KEY,
	ProjectID		INT REFERENCES Projects (ProjectID) NOT NULL,
	DatetimeOfOrder DATETIME 
)
GO
CREATE TABLE OrderEntries(
	OrderID					INT REFERENCES Orders(OrderID) NOT NULL,	
	PartID					INT REFERENCES Parts (PartID) NOT NULL,	
	PartCount				INT NULL,				-- number of parts ordered
	OrderEntryStatus		INT NOT NULL			-- can be RESERVED or MISSING
	CONSTRAINT PK_orderEntries PRIMARY KEY (OrderID, PartID, OrderEntryStatus) 
	-- note: can we can have 2 entries of the same solar panel part if we were able to reserve some number of parts and some amount is missing from the storage
)
GO
