﻿-------------------------------------------------
use master
use SolarPanelInstallationDatabase
GO
------------------------------------------------
------------------------------------------------
------------------------------------------------
------------------------------------------------
------------------------------------------------
------------------------------------------------
-- IMPORTANT: This proc has to run at least once!
-- WARNING: This deletes all content from the database!
DROP PROC IF EXISTS HardResetAndSetupDatabase
GO
CREATE OR ALTER PROCEDURE HardResetAndSetupDatabase
AS
BEGIN
	-- WARNING: Hard reset of all tables in the db
	DELETE FROM OrderEntries
	DELETE FROM Orders
	DELETE FROM ProjectLogEntries
	DELETE FROM Projects
	DELETE FROM Inventory
	DELETE Storage
	DELETE FROM Parts
	DELETE FROM LoginInformation
	DELETE FROM Persons
	UPDATE Inventory SET NumInStorage = 0
	EXEC SetupStorage
	-- inserting admin to the database
	-- PARAMETERS: first name, last name, job, email, password hash
	-- IMPORTANT: 3rd parameter has to be Capialized name of "Admin"!
	EXEC InsertPersonAndLoginInformation 'admin', 'admin', 'Admin', 'admin@nomail.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'
	-- HELP: Random solar panel part information (generated by ChatGPT 3.5)
	EXEC InsertNewPart 'Solar Panel', '300W 24V Solar Panel', 50, 150
	EXEC InsertNewPart 'Inverter', '2000W 24VDC to 230VAC Inverter', 30, 400
	EXEC InsertNewPart 'Battery', '12V 100Ah Deep Cycle Battery', 100, 200
	EXEC InsertNewPart 'Solar Cable', '10 AWG Solar Cable', 500, 0.5
	EXEC InsertNewPart 'Battery Cable', '2 AWG Battery Cable', 200, 1
	EXEC InsertNewPart 'Solar Panel Mounting Kit', 'Solar Panel Mounting Kit for Flat Roofs', 20, 100
	EXEC InsertNewPart 'Solar System Design Manual', 'Guide for Solar System Design', 10, 25
END
GO
-- EXECUTE HARD RESET!
--EXEC HardResetAndSetupDatabase
-- GO
-- Verify the DB after Hard reset!
SELECT * FROM Persons p INNER JOIN LoginInformation li ON p.PersonID = li.PersonID
SELECT * FROM Projects
SELECT * FROM ProjectLogEntries
SELECT * FROM Orders
SELECT * FROM OrderEntries
SELECT * FROM Parts
SELECT * FROM Inventory
SELECT * FROM Storage
GO
------------------------------------------------
------------------------------------------------
------------------------------------------------
------------------------------------------------
------------------------------------------------
------------------------------------------------
------------------------------------------------
-- SP/SetupStorage
-- Setting up information about the compartment system in the storage
DROP PROC IF EXISTS SetupStorage
GO
CREATE OR ALTER PROCEDURE SetupStorage
    @StorageRow INT = 10,
    @StorageColumn INT = 4,
    @StorageLevel INT = 6
AS
BEGIN
    DECLARE @CurrentRow INT = 1;
    DECLARE @CurrentColumn INT;
    DECLARE @CurrentLevel INT;
	TRUNCATE TABLE Storage
    WHILE @CurrentRow <= @StorageRow
    BEGIN
        SET @CurrentColumn = 1;
        WHILE @CurrentColumn <= @StorageColumn
        BEGIN
            SET @CurrentLevel = 1;
            WHILE @CurrentLevel <= @StorageLevel
            BEGIN
				INSERT Storage(StorageRow, StorageColumn, StorageLevel, PartID, PartCount)
				VALUES(@CurrentRow, @CurrentColumn, @CurrentLevel, NULL, 0) -- NULL means the compartment on the shelf is empty
				-- debugging info
                PRINT CONCAT('Current Row = ', @CurrentRow, ', Current Column = ', @CurrentColumn, ', Current Level = ', @CurrentLevel); 
                SET @CurrentLevel = @CurrentLevel + 1;
            END
            SET @CurrentColumn = @CurrentColumn + 1;
        END
        SET @CurrentRow = @CurrentRow + 1;
    END
END
GO
-- SP/InsertPersonAndLoginInformation
-- Inserting new user and login information into the database
DROP PROC IF EXISTS InsertPersonAndLoginInformation
GO
CREATE OR ALTER PROCEDURE InsertPersonAndLoginInformation
    @FirstName VARCHAR(20),
    @LastName VARCHAR(20),
    @Job VARCHAR(20),
    @Email VARCHAR(50),
    @PasswordHash VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @PersonID INT;
	DECLARE @msg VARCHAR(100);
    IF EXISTS (SELECT * FROM LoginInformation WHERE Email = @Email) -- Check if email already exists in LoginInformation table
    BEGIN
		DECLARE @ErrorMessage varchar(100) = 'Email address already registered!'
		RAISERROR(@ErrorMessage, 16, 1)
        RETURN;
    END;
    INSERT INTO Persons (FirstName, LastName, Job) VALUES (@FirstName, @LastName, @Job);
    SET @PersonID = SCOPE_IDENTITY();
    INSERT INTO LoginInformation (PersonID, Email, PasswordHash) VALUES (@PersonID, @Email, @PasswordHash);
	SET @msg = 'Successful';
	SELECT @PersonID as PersonID;
END
GO
-- TEST/InsertPersonAndLoginInformation
--EXEC InsertPersonAndLoginInformation 'storage', 'worker', 'Storage_Worker', 'sw@nomail.com', '7865b7e6b9d241d744d330eec3b3a0fe4f9d36af75d96291638504680f805bfd' -- pw = sw
---- duplicate email => error!
--EXEC InsertPersonAndLoginInformation 'storage', 'worker2', 'Storage_Worker', 'sw@nomail.com', 'otherHash__________5435fgkjsgfkjhgfskdasdfaljh3ru983u329f' 
--EXEC InsertPersonAndLoginInformation 'storage', 'manager', 'Storage_Manager', 'sm@nomail.com', '5af308bec132bd499660594a6c127c57f910a25c18968eb4f9b976f48df8cb49' -- pw = sm
--EXEC InsertPersonAndLoginInformation 'specialist', 'specialist', 'Specialist', 'sp@nomail.com', 'be18b85f77fc024db379acf19e8a1ce62307ab7bb1bca395389ecfc2dafaf741' -- pw = sp
---- verifying newly inserted Persons
--SELECT * 
--	FROM Persons p 
--    INNER JOIN LoginInformation li 
--	ON p.PersonID = li.PersonID
--GO
-- SP/CheckLoginInformation
-- validating attempted login
DROP PROC IF EXISTS CheckLoginInformation
GO
CREATE OR ALTER PROCEDURE CheckLoginInformation
    @Email VARCHAR(50),
    @PasswordHash VARCHAR(200),
    @Msg_UserID INT OUTPUT,
	@Msg_Job VARCHAR(20) OUTPUT
AS
BEGIN
    IF (SELECT COUNT(*) FROM LoginInformation WHERE Email = @Email AND PasswordHash = @PasswordHash) > 0
		BEGIN
			SELECT @msg_userID = Persons.PersonID, @msg_job = Persons.Job
				FROM LoginInformation 
				INNER JOIN Persons ON Persons.PersonID = LoginInformation.PersonID 
				WHERE Email = @Email AND PasswordHash = @PasswordHash
			-- debugging info
			PRINT CONCAT('DEBUG: The ID of the user: ', @msg_userID) 
			PRINT CONCAT('DEBUG: The job of the user: ', @msg_job)
		END
    ELSE
		BEGIN
			DECLARE @ErrorMessage varchar(100) = 'Error! The email or password is not correct!';
			RAISERROR(@ErrorMessage, 16, 1)
		END
END
GO
-- TEST/CheckLoginInformation
--DECLARE @lmsg_userID INT = 1
--DECLARE @lmsg_job VARCHAR(100) = 'JOB'
---- Correct login infomartion!
--EXEC CheckLoginInformation 
--	'sm@nomail.com', 
--	'5af308bec132bd499660594a6c127c57f910a25c18968eb4f9b976f48df8cb49' , 
--	@msg_userID = @lmsg_userID OUTPUT ,
--	@msg_job = @lmsg_job OUTPUT
---- Incorrect login infomartion!
--EXEC CheckLoginInformation 
--	'sm2@othermail.com', 
--	'5af308bec132bd499660594a6c127c57f910a25c18968eb4f9b976f48df8cb49' , 
--	@msg_userID = @lmsg_userID OUTPUT, 
--	@msg_job = @lmsg_job OUTPUT
--GO
-------- Helper Function to View Storage ------
DROP PROC IF EXISTS ViewStorage
GO
CREATE OR ALTER PROCEDURE ViewStorage
AS
BEGIN
	SELECT StorageRow, StorageColumn, StorageLevel, PartCount, ISNULL(p.PartName, '') as [PartName]
		FROM Storage s
		LEFT JOIN Parts p ON s.PartID = p.PartID
		ORDER BY StorageRow ASC, StorageColumn ASC, StorageLevel ASC
END
GO
-------- SP's of Person/Specialist (A#) -------- 
------------------------------------------------
-- REQ/A1: SP/InsertNewProject
DROP PROCEDURE IF EXISTS InsertNewProject
GO
CREATE OR ALTER PROCEDURE InsertNewProject
	@ProjectName VARCHAR(50), 
	@SpecialistID INT, 
	@ProjectDescription VARCHAR(250), 
	@ClientName	VARCHAR(50), 
	@ProjectLocation VARCHAR(50),
	@EstimatedHours INT,
	@PricePerHour	DECIMAL
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT 1 FROM Projects WHERE ProjectName = @ProjectName)
		BEGIN
			DECLARE @ErrorMessage varchar(100) = 'Error! Project with name ' + @ProjectName + ' already exists!'
			RAISERROR(@ErrorMessage, 16, 1)
			RETURN
		END
	-- New Project
	INSERT INTO Projects 
			   (ProjectName, SpecialistID, ProjectStatus, ProjectDescription, ClientName, ProjectLocation, EstimatedHours, PricePerHour)
		VALUES (@ProjectName, @SpecialistID, 'NEW', @ProjectDescription, @ClientName, @ProjectLocation, @EstimatedHours, @PricePerHour)
	DECLARE @NewProjectID INT = SCOPE_IDENTITY()
	-- New Project Log Entry about the creation of the project
	INSERT INTO ProjectLogEntries 
		   (ProjectID, TimeOfStatus, ProjectStatus)
			VALUES (@NewProjectID, GETDATE(), 'NEW')
	SELECT @NewProjectID AS ProjectID
END
GO
-- REQ/A1: TEST/InsertNewProject
--EXEC InsertNewProject'TestProject_no1', 3, '', '','', 20, 500
---- ProjectName, SpecialistID, ProjectDescription, ClientName, ProjectLocation, EstimatedHour, PricePerHour
---- WARNING: Look up and use proper parameters for testing!
--EXEC InsertNewProject'TestProject_no1', 1, '', '','', 20, 500 
--EXEC ListAllProjectsOfSpecialist 1
--GO
-- REQ/A2: SP/ListAllProjectsOfSpecialist
DROP PROC IF EXISTS ListAllProjectsOfSpecialist
GO
CREATE OR ALTER PROCEDURE ListAllProjectsOfSpecialist
	@PersonID INT
AS
	BEGIN
		if((SELECT Job FROM Persons WHERE PersonID = @PersonID) != 'Specialist')
			BEGIN
				DECLARE @ErrorMessage VARCHAR(100) = 'Error! User is not a Specialist!'
				RAISERROR(@ErrorMessage, 16, 1)
				RETURN
			END
		SELECT ProjectID, ProjectName, SpecialistID, ProjectStatus, ProjectDescription, ClientName, ProjectLocation, EstimatedHours, PricePerHour
			FROM Projects
			WHERE SpecialistID = @PersonID
	END
GO
-- REQ/A2: TEST/ListAllProjectsOfSpecialist
--SELECT * FROM Persons
--SELECT * FROM Projects
--EXEC InsertNewProject 'TestProject_no2', 10, '', '', '', 20, 500
--EXEC ListAllProjectsOfSpecialist 1 -- WARNING: Look up and use proper parameters for testing!
--EXEC ListAllProjectsOfSpecialist 2 -- ERROR: User is not a specialist! WARNING: Use an ID that doesn't belong to a Specialist for testing!
--GO
-- REQ/A6/: SP/GetProjectStatus - Helper SP
-- WARNING: If we want to test the "My Projects' button in the GUI this sp is needed!
DROP PROC IF EXISTS GetProjectStatus
GO
CREATE OR ALTER PROCEDURE GetProjectStatus
    @ProjectID INT
AS
BEGIN
    SELECT ProjectStatus
    FROM Projects
    WHERE ProjectID = @ProjectID
END
GO
-- REQ/A3: SP/ListAllPartsAndInventory
DROP PROC IF EXISTS ListAllPartsAndInventory
GO
CREATE OR ALTER PROCEDURE ListAllPartsAndInventory
AS
BEGIN
	SELECT p.PartID, p.PartName, p.PartDescription, p.CountPerCompartment, p.CurrentPrice, i.NumInStorage
		FROM Parts p
		INNER JOIN Inventory i ON p.PartID = i.PartID
END
GO
-- REQ/A3: TEST/ListAllPartsAndInventory
--EXEC ListAllPartsAndInventory
--GO
-- REQ/A4/a: SP/AddOrderToProject
-- WARNING: The next 2 SP'S after this are needed if we want to add the Order to a project in the GUI!
DROP PROC IF EXISTS AddOrderToProject
GO
CREATE OR ALTER PROCEDURE AddOrderToProject
	@ProjectID INT
AS
 BEGIN
	INSERT 
		INTO Orders (ProjectID, DatetimeOfOrder)
		VALUES (@projectID, GETDATE())
	SELECT @@ROWCOUNT AS 'RowsAffected'
END
GO
-- REQ/A4/a: TEST/AddOrderToProject
--SELECT * FROM Projects
--SELECT * FROM Orders
--EXEC AddOrderToProject 1 -- WARNING: look up and use a proper ProjectID
---- DELETE FROM Orders WHERE OrderID = 1 -- WARNING: use the newly inserted order's ID
--GO
-- REQ/A4/a: SP/ListOrderEntriesOfOrder - Helper SP
-- WARNING: This SP is needed if we want to add Order to a project in the GUI!
DROP PROC IF EXISTS ListOrderEntriesOfOrder
GO
CREATE OR ALTER PROCEDURE ListOrderEntriesOfOrder
    @OrderID INT
AS
BEGIN
	SELECT p.PartName, oe.PartCount, oe.OrderEntryStatus
		FROM OrderEntries oe
		INNER JOIN Parts p ON oe.PartID = p.PartID
		WHERE OrderID = @OrderID
END
-- TEST/ListOrderEntriesOfOrder
--EXEC ListOrderEntriesOfOrder 1 -- OrderID => WARNING: look up and use proper parameters
--GO
-- SP/GetOrderIDOfProject
-- WARNING: This SP is needed if we want to add Order to a project in the GUI!
DROP PROC IF EXISTS GetOrderIDOfProject
GO
CREATE OR ALTER PROCEDURE GetOrderIDOfProject
	@ProjectID INT
AS	
BEGIN
	DECLARE @OrderID INT = (SELECT OrderID FROM Orders WHERE ProjectID = @ProjectID)
	IF @OrderID IS NULL
		BEGIN
			SET @OrderID = -1
		END
	SELECT @OrderID AS 'OrderID'
END
GO
-- TEST/GetOrderIDOfProject
--EXEC GetOrderIDOfProject 1 -- ProjectID => WARNING: look up and use proper parameters
--SELECT * FROM Orders
--GO
-- REQ/A4/b: SP/AddOrderEntryToOrder
-- WARNING SP/UpdateProjectStatus is needed to use this feature in the GUI!
DROP PROC IF EXISTS AddOrderEntryToOrder
GO
CREATE OR ALTER PROCEDURE AddOrderEntryToOrder
	@OrderId INT,
	@PartID INT,
	@PartCount INT
AS
 BEGIN
	DECLARE @CurrentInventory INT = (SELECT NumInStorage FROM Inventory i WHERE PartID = @PartID)
	IF (@PartCount <= @CurrentInventory)
		BEGIN
			INSERT 
				 INTO OrderEntries(orderID, partID, PartCount, OrderEntryStatus)
				 VALUES(@OrderID, @PartID, @PartCount, 0)
			UPDATE Inventory
				SET NumInStorage = NumInStorage - @PartCount
				WHERE PartID = @PartID
			SELECT @@ROWCOUNT AS 'RowsAffected'
		END
	ELSE 
		BEGIN
			DECLARE @diff INT = ABS(@CurrentInventory - @PartCount)
			INSERT 
				INTO OrderEntries(orderID, partID, PartCount, OrderEntryStatus)
				VALUES (@OrderID, @PartID, @CurrentInventory, 0) -- reserve any amount of the part that is left in the storage (status = 0)
			INSERT 
				INTO OrderEntries(orderID, partID, PartCount, OrderEntryStatus)
				VALUES (@OrderID, @PartID, @diff, 1) -- preorder the remaining amount we need (status = 1)
			UPDATE Inventory
				SET NumInStorage = 0
				WHERE PartID = @PartID
			SELECT @@ROWCOUNT AS 'RowsAffected'
		END
END
GO
-- REQ/A4/b: TEST/AddOrderEntryToOrder
--EXEC AddOrderEntryToOrder 1, 1, 10 -- OrderID, PartID, Count => WARNING: look up and use proper parameters
--SELECT * FROM Inventory
--GO
-- REQ/A5/a: SP/UpdateProjectEstimatedHours
DROP PROC IF EXISTS UpdateProjectEstimatedHours
GO
CREATE OR ALTER PROCEDURE UpdateProjectEstimatedHours
	@ProjectID INT,
	@EstimatedHours INT
AS
BEGIN
	if(@EstimatedHours < 1)
		BEGIN
			DECLARE @ErrorMessage varchar(100) = 'Error! The estimated time for the project has to be at least 1 hour!'
			RAISERROR(@ErrorMessage, 16, 1)
			RETURN;
		END
	UPDATE Projects
		SET EstimatedHours = @EstimatedHours 
		WHERE ProjectID = @ProjectID
	SELECT @@ROWCOUNT AS 'RowsAffected'
END
GO
-- REQ/A5/a: TEST/UpdateProjectEstimatedHours
--EXEC UpdateProjectEstimatedHours 1, 10 -- ProjectID, EstimatedHours => WARNING: look up and use proper parameters
--GO
-- REQ/A5/b: SP/UpdateProjectPricePerHour
DROP PROC IF EXISTS UpdateProjectPricePerHour
GO
CREATE OR ALTER PROCEDURE UpdateProjectPricePerHour
	@ProjectID INT,
	@NewPricePerHour DECIMAL
AS
	BEGIN
		UPDATE Projects
			SET PricePerHour = @newPricePerHour
			WHERE ProjectID = @projectID
		SELECT @@ROWCOUNT AS 'RowsAffected'
	END
GO
-- REQ/A5/b: TEST/UpdateProjectPricePerHour 
--EXEC UpdateProjectPricePerHour 1, 10 -- ProjectID, NewPricePerHour => WARNING: look up and use proper parameters
--SELECT * FROM Projects
--GO
-- REQ/A6/: SP/CalculatePriceOfOrder
-- Calculates price of the order once every solar panel part is available 
-- "Wait" = Part(s) are missing from the storage, "Scheduled" = Every part is available => price can be calculated
DROP PROC IF EXISTS CalculatePriceOfOrder
GO
CREATE OR ALTER PROCEDURE CalculatePriceOfOrder
	@OrderID INT,
	@ProjectID INT
AS
	BEGIN
			DECLARE @status Varchar(50) = (SELECT ProjectStatus FROM Orders o INNER JOIN Projects p ON o.ProjectID = p.ProjectID WHERE o.OrderID = @OrderID)
			PRINT(CONCAT('DEBUG: Status = ', @status)) 
			IF (@status = 'WAIT') 
				BEGIN
					DECLARE @ErrorMessage varchar(100) = 'There are solar panel parts that are not in the storage!'
					RAISERROR(@ErrorMessage, 16, 1)
					RETURN
				END
			SET NOCOUNT ON;
			DECLARE @TotalValue INT;
			SELECT @TotalValue = SUM(ISNULL(p.CurrentPrice, 0) * oe.PartCount)
				FROM Orders o
				INNER JOIN OrderEntries oe ON o.OrderID = oe.OrderID
				INNER JOIN Parts p ON oe.PartID = p.PartID
				WHERE o.OrderID = @OrderID;
			SELECT @TotalValue AS OrderValue;
	END
GO
-- REQ/A6: TEST/CalculatePriceOfOrder
--SELECT ProjectStatus FROM Orders o INNER JOIN Projects p ON o.ProjectID = p.ProjectID WHERE o.OrderID = 2
--UPDATE Projects
--	SET ProjectStatus = 'NEW'
--	WHERE ProjectID = 1
--SELECT * FROM Orders
--SELECT * FROM OrderEntries
--TRUNCATE TABLE OrderEntries
--DELETE FROM Orders
--	WHERE OrderID = 1
--SELECT * FROM Projects
--EXEC CalculatePriceOfOrder 2, 1 -- ProjectID, OrderID => WARNING: look up and use proper parameters
--GO
-- REQ/A7: SP/UpdateProjectStatus
DROP PROC IF EXISTS UpdateProjectStatus
GO
CREATE OR ALTER PROCEDURE UpdateProjectStatus
	@ProjectID INT,
	@NewStatus INT
AS
	BEGIN
		IF (@NewStatus >= 0  AND  @NewStatus <= 6)
		BEGIN
			UPDATE Projects
			SET ProjectStatus = CASE @NewStatus
										WHEN 0 THEN 'NEW'
										WHEN 1 THEN 'DRAFT'
										WHEN 2 THEN 'WAIT'
										WHEN 3 THEN 'SCHEDULED'
										WHEN 4 THEN 'INPROGRESS'
										WHEN 5 THEN 'COMPLETED'
										WHEN 6 THEN 'FAILED'
									END
			WHERE ProjectID = @ProjectID
			SELECT @@ROWCOUNT AS 'RowsAffected'
		END
		ELSE
			BEGIN
				DECLARE @ErrorMessage varchar(100) = 'Error! Incorrect project status name provided!'
				RAISERROR(@ErrorMessage, 16, 1)
				RETURN;
			END
	END
GO
-- REQ/A7: TEST/UpdateProjectStatus
--EXEC UpdateProjectStatus 1, 2 -- ProjectID, NewStatus => WARNING: look up and use proper parameters
--SELECT * FROM projects
--GO
-------- SP's of Person/StoreManager (B#) --------
-- REQ/B1: SP/InsertNewPart
-- Adds a new part to the registry of all parts
DROP PROC IF EXISTS InsertNewPart
GO
CREATE OR ALTER PROCEDURE InsertNewPart
	@PartName VARCHAR(50), 
	@PartDescription  VARCHAR(250),
	@CountPerCompartment INT, 
	@CurrentPrice DECIMAL 
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT 1 FROM Parts WHERE PartName = @PartName)
		BEGIN
			DECLARE @ErrorMessage varchar(100) = 'Error! Part with name ' + @PartName + ' already exists!'
			RAISERROR(@ErrorMessage, 16, 1)
			RETURN
		END
	INSERT INTO PARTS (PartName, PartDescription, CountPerCompartment, CurrentPrice)
		VALUES (@PartName, @PartDescription, @CountPerCompartment, @CurrentPrice)
	DECLARE @NewPartID INT = SCOPE_IDENTITY()
	INSERT INTO Inventory (PartID, NumInStorage)	
		VALUES (@NewPartID, 0)
	SELECT @NewPartID AS PartID
END
GO
-- REQ/B2: SP/UpdatePartPrice
DROP PROC IF EXISTS UpdatePartPrice
GO
CREATE OR ALTER PROCEDURE UpdatePartPrice
	@PartID INT, 
	@NewPrice DECIMAL
AS
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT 1 FROM Parts WHERE PartID = @PartID)
		BEGIN
			DECLARE @ErrorMessage varchar(100) = 'Error! Part with ID ' + @PartID + ' does not exist!'
			RAISERROR(@ErrorMessage, 16, 1)
				-- msg_id or msg_str: Either the ID of the message to be raised or the actual message text to be raised. If a msg_id is specified, 
					-- it must be a user-defined message that has been defined using the sp_addmessage system stored procedure. 
					-- If a msg_str is specified, it must be enclosed in quotes.
				-- severity: The severity level of the error. This can be any value from 0 to 25. A severity level of 0 means no error; it is purely informational.
				-- state: An optional parameter that can be used to help identify the error. This can be any value from 1 to 127.
			RETURN
		END
	UPDATE Parts
		SET CurrentPrice = @NewPrice
		WHERE PartID = @PartID
	SELECT @@ROWCOUNT AS 'RowsAffected'
GO
-- REQ/B2: TEST/UpdatePartPrice
--EXEC UpdatePartPrice 1, 10 -- PartID, NewPrice => WARNING: look up and use proper parameters
--EXEC ListAllPartsAndInventory 
--GO
-- REQ/B3: SP/ListAllPartsNotInStorage
DROP PROC IF EXISTS ListAllPartsNotInStorage
GO
CREATE OR ALTER PROCEDURE ListAllPartsNotInStorage
AS
    BEGIN
        SELECT * FROM Parts p
			INNER JOIN Inventory i ON p.PartID = i.PartID
			WHERE NumInStorage IS NULL OR NumInStorage = 0
    END
GO
-- REQ/B4: SP/ListAllPartsPreordered
-- Preordered parts
DROP PROC IF EXISTS ListAllPartsPreordered
GO
CREATE OR ALTER PROCEDURE ListAllPartsPreordered
AS
    BEGIN
        SELECT pa.PartName, pr.ProjectName, oe.PartCount FROM OrderEntries oe 
			INNER JOIN Orders o ON oe.OrderID = o.OrderID
			INNER JOIN Projects pr ON pr.ProjectID = o.ProjectID
			INNER JOIN Parts pa ON oe.PartID = pa.PartID
			INNER JOIN Inventory i ON pa.PartID = i.PartID
			WHERE OrderEntryStatus = 1
    END
GO
-- REQ/B5+B6 - SP/SupplyParts
-- Helper SP'S --> the SupplyParts SP literally executes the 2 helper SP's,
	-- 1.) UpdatePartPreordersAndInventory
	-- 2.) PlacePartsInStorage
-- so in step 1.) the invertory gets updated and here any preorders are verified. If new parts are supplied to the storage
-- the first thing to do is to check any preorders and fullfill them (adjusting order entries of orders), then  if 
-- all preorders are fullfilled the remaing parts are added to the storage and the inventory gets updated!
---------------------------------------------------------------------------
-- REQ/B5+B6/a: SP/UpdatePartPreordersAndInventory
-- NOTE: all PRINT statements are for debugging!
DROP PROC IF EXISTS UpdatePartPreordersAndInventory
GO
CREATE OR ALTER PROCEDURE UpdatePartPreordersAndInventory
    @PartID INT,
    @SupplyPartCount INT
AS
    BEGIN
		DECLARE @PreorderPartCount INT = 0, @IterationCounter INT = 1
        WHILE @SupplyPartCount > 0 AND @PreorderPartCount IS NOT NULL
            BEGIN
                SET @PreorderPartCount = (SELECT TOP 1 PartCount FROM OrderEntries WHERE OrderEntryStatus = 1 AND PartID = @partID)
				-- debugging info
				PRINT CONCAT('DEBUG: Iteration #', @IterationCounter, ': SupplyPartCount = ', @SupplyPartCount, ' and PreorderPartCount = ', @PreorderPartCount)
				IF @PreorderPartCount IS NOT NULL AND @SupplyPartCount > 0
					BEGIN
						DECLARE @OrderID INT = (SELECT TOP 1 OrderID FROM OrderEntries WHERE OrderEntryStatus = 1 AND PartID = @partID)
						IF(@SupplyPartCount >= @PreorderPartCount)
							BEGIN
								UPDATE OrderEntries SET PartCount = PartCount + @PreorderPartCount WHERE OrderID = @OrderID AND PartID = @PartID AND OrderEntryStatus = 0
								DELETE FROM OrderEntries WHERE OrderID = @orderID AND PartID = @partID AND OrderEntryStatus = 1
								SET @supplyPartCount = @supplyPartCount - @preorderPartCount
							END
						ELSE
							BEGIN
								UPDATE OrderEntries SET PartCount = PartCount + @supplyPartCount WHERE OrderID = @orderID AND PartID = @partID AND OrderEntryStatus = 0
								UPDATE OrderEntries SET PartCount = PartCount - @supplyPartCount WHERE OrderID = @orderID AND PartID = @partID AND OrderEntryStatus = 1
								SET @supplyPartCount = 0
							END
					END
                SET @IterationCounter = @IterationCounter + 1
            END
        IF @SupplyPartCount > 0 -- if all preorders are fullfiled and any parts remain, they are placed in the storage
            BEGIN
                UPDATE Inventory
					SET NumInStorage = NumInStorage + @supplyPartCount
					WHERE PartID = @partID
            END
		SELECT @@ROWCOUNT AS 'RowsAffected'
    END
GO
-- REQ/B5+B6/a: TEST/UpdatePartPreordersAndInventory
-- WARNING: Resets Inventory
--UPDATE Inventory SET NumInStorage = 50 WHERE PartID = 1 -- setting the inventory of all parts to 50
--EXEC ListAllPartsAndInventory -- verifying inventory
----EXEC AddOrderToProject 1
----EXEC AddOrderToProject 2
---- DELETE FROM OrderEntries --> deletes the content of all orders
--SELECT * FROM OrderEntries
---- adding order entries of the same solar panel part to different projects, this way we can test the handling of multiple preorders
--EXEC AddOrderEntryToOrder 1, 1, 80  -- OrderID, PartID
--EXEC AddOrderEntryToOrder 2, 1, 20  -- Ordering a total of 100 pieces of part x, and there is only 50 of it in the storage => 50 preorders set!
---- verifying orders
--SELECT * FROM Orders
--SELECT * FROM OrderEntries
--SELECT * FROM Projects
---- testing the SP --> the part has to be the same ID as the preordered part's ID, 
---- if the number of parts supplied is bigger than 50 all preorders will be fullfiled and the preorders updated
--EXEC UpdatePartPreordersAndInventory 1, 100
--GO
-- REQ/B5+B6/b: SP/PlacePartsInStorage
-- After checking preorders, if the inventory got updated the Parts have to be placed in the storage itself
-- NOTE: if no parts left to distribute in the storage than the @PartCount argument is 0 and the main loop doesn't execute at all
-- also, all PRINT statements here are for debugging!
DROP PROC IF EXISTS PlacePartsInStorage
GO
CREATE OR ALTER PROCEDURE PlacePartsInStorage
    @PartID INT,
    @PartCount INT
AS
BEGIN
	DECLARE @PartCountDiff INT, @CountPerCompartment INT, @NumOfResults INT, @NumOfPartsToBePlaced INT, @NumOfPartsThatCanBePlaced INT, @IterationCounter INT = 0
	DECLARE @ErrorMessage VARCHAR(100)
	DECLARE @cur_row INT, @cur_col INT, @cur_lvl INT, @cur_partID INT, @cur_partCount INT 
	SELECT @CountPerCompartment = CountPerCompartment
		FROM Parts
		WHERE PartID = @PartID -- look up how many of this part can be placed in one compartment
	PRINT(concat('DEBUG: Part ID: ', @PartID, ', Count Per Compartment: ', @CountPerCompartment))
	WHILE @PartCount > 0 -- in every iteration we place some amount of the parts in a compartment
		BEGIN 
			SET @IterationCounter = @IterationCounter + 1
			PRINT(CONCAT('DEBUG: ', @IterationCounter,'. Iteration'))
			SELECT @NumOfResults = Count(*)
				FROM Storage
				WHERE PartID = @PartID AND PartCount < @CountPerCompartment -- check if the part is in any compartment of the storage and there is still space for it!
			IF @NumOfResults = 0 -- if not we try to find an empty compartment
				BEGIN
					PRINT('DEBUG: No compartment where we store this part and there is still space!')
					DECLARE @NumOfEmpty INT
					SELECT @NumOfEmpty = Count(*) 
						FROM Storage
						WHERE PartID IS NULL -- check to see if there is an empty compartment at all!
					IF @NumOfEmpty = 0 -- NO EMPTY COMPARTMENT!
						BEGIN
							PRINT('ERROR: No empty compartments found!')
							SET @ErrorMessage = 'Error! No empty compartments found!'
							RAISERROR(@ErrorMessage, 16, 1)
							RETURN;
						END
					SET @NumOfPartsThatCanBePlaced = @CountPerCompartment
					DECLARE cur CURSOR FOR
						SELECT StorageRow, StorageColumn, StorageLevel, PartID, PartCount
							FROM Storage
							WHERE PartID IS NULL -- find the first empty compartment
				END
			ELSE
				BEGIN
					PRINT('DEBUG: There is a compartment for this part and there is still space in it!')
					SELECT @NumOfPartsThatCanBePlaced = @CountPerCompartment - Storage.PartCount
						FROM Storage
						WHERE  PartID = @PartID AND PartCount < @CountPerCompartment
					DECLARE cur CURSOR FOR
						SELECT StorageRow, StorageColumn, StorageLevel, PartID, PartCount
							FROM Storage
							WHERE  PartID = @PartID AND PartCount < @CountPerCompartment
				END
			OPEN cur
			FETCH NEXT FROM cur INTO @cur_row, @cur_col, @cur_lvl, @cur_partID, @cur_partCount
			IF @@FETCH_STATUS = 0
				BEGIN 
					IF @PartCount <  @NumOfPartsThatCanBePlaced -- check if the number of parts we want to place in the storage can fit into one compartment
						BEGIN
								PRINT('DEBUG: All parts fit into one compartment!')
								SET @NumOfPartsToBePlaced = @PartCount
						END
					ELSE -- a whole compartment was filled with the part
						BEGIN 
								PRINT('DEBUG: Parts cannot be placed in one compartment!')
								SET @NumOfPartsToBePlaced = @NumOfPartsThatCanBePlaced
						END
					UPDATE Storage
						SET PartID = @PartID, PartCount = PartCount + @NumOfPartsToBePlaced
						WHERE CURRENT OF cur 
					SET @PartCount = @PartCount - @NumOfPartsToBePlaced
				END
			CLOSE cur
			DEALLOCATE cur
		END
END
GO
-- REQ/B5+B6/b: TEST/PlacePartsInStorage
-- WARNING: Reseting storage
--DELETE FROM Storage
--EXEC SetupStorage
--SELECT * FROM Storage
--EXEC PlacePartsInStorage 9, 50 -- PartID, NumOfParts => WARNING: look up and use proper parameters
--SELECT * FROM Parts
--GO
-- REQ/B5+B6/c: SP/SupplyParts
DROP PROC IF EXISTS SupplyParts
GO
CREATE OR ALTER PROCEDURE SupplyParts
    @PartID INT,
    @NumOfParts INT OUTPUT
AS
BEGIN
	DECLARE @NumOfPreorders INT = (SELECT COUNT(*) FROM OrderEntries WHERE PartID = @PartID AND OrderEntryStatus = 1)
	EXEC UpdatePartPreordersAndInventory @PartID, @NumOfParts
	IF @NumOfPreorders > 0
		BEGIN -- if we had preorderes we complete them and place in the storage
			DECLARE @NumOfPartsToPlaceInStorage	INT = (SELECT NumInStorage FROM Inventory WHERE PartID = @PartID)
			EXEC PlacePartsInStorage @PartID, @NumOfPartsToPlaceInStorage
		END
	ELSE -- if there were no preorderes all parts go directly to the storage
		BEGIN
			EXEC PlacePartsInStorage @PartID, @NumOfParts
		END
END
GO
-- REQ/B5+B6/c: TEST/SupplyParts
---- WARNING: Reseting storage
--DELETE Storage
--EXEC SetupStorage
--UPDATE Inventory SET NumInStorage = 0
--UPDATE Inventory SET NumInStorage = 23 WHERE PartID = 8
--UPDATE Storage SET PartCount = 21 WHERE PartID = 9 AND PartCount = 10
--SELECT * FROM Storage
--SELECT * FROM Parts
--SELECT * FROM Inventory
--EXEC ListAllPartsAndInventory
---- first, order parts and add order entries to the order!
--EXEC ListOrderEntriesOfOrder 7 -- WARNING: Use valid order number
--SELECT * FROM Orders
--SELECT * FROM OrderEntries
--EXEC SupplyParts 14, 17
--GO
-------- SP's of Person/StorageWorker (C#) --------
-- REQ/C1: SP/ListAllProjects
DROP PROC IF EXISTS ListAllProjects
GO
CREATE OR ALTER PROCEDURE ListAllProjects
AS
	BEGIN
		SELECT * FROM Projects
	END
GO
-- REQ/C1: TEST/ListAllProjects
--EXEC ListAllProjects
--GO
-- REQ/C2: SP/ListPartsOfOrderInStorage
-- Listing all parts of a given order and where they are in the storage (row, column, level, compartment)
	-- the location (row, column, level) has to be returned as a string: 
DROP PROC IF EXISTS ListPartsOfOrderInStorage 
GO
CREATE OR ALTER PROCEDURE ListPartsOfOrderInStorage 
	@OrderID INT
AS
	BEGIN
		SELECT p.PartID, p.PartName, s.StorageRow, s.StorageColumn, s.StorageLevel, s.PartCount
		FROM Orders o JOIN OrderEntries oe on o.OrderID=oe.OrderID 
			JOIN Parts p on oe.PartID = p.PartID JOIN Inventory i on p.PartID = i.PartID 
			JOIN Storage s on s.PartID = p.PartID
			WHERE oe.OrderID = @OrderID
	END
GO
-- REQ/C2: TEST/ListPartsOfOrderInStorage
--SELECT * FROM Orders
--SELECT * FROM OrderEntries
--EXEC ListPartsOfOrderInStorage 2
-- REQ/C3: SP/ListPartsOfOrderInStorage
-- NOTE: No concrete implementation of this requirement
--GO
-- REQ/C4: SP/FullfillOrder
DROP PROCEDURE IF EXISTS FullfillOrder
GO
CREATE OR ALTER PROCEDURE FullfillOrder
	@OrderID INT
AS
BEGIN
	DECLARE @PartID INT
	DECLARE @Finished INT
	DECLARE @ProjectID INT = (SELECT ProjectID FROM Orders WHERE OrderID = @OrderID)
	IF (SELECT COUNT(*) FROM OrderEntries WHERE OrderID = @OrderID AND OrderEntryStatus = 1) > 0
	BEGIN
		DECLARE @ErrorMessage varchar(100) = 'Error! Order cannot be fullfilled, waiting for preorder(s)!'
		RAISERROR(@ErrorMessage, 16, 1)
		RETURN
	END
	DECLARE OrderEntryCursor CURSOR FOR
		SELECT PartID
		FROM OrderEntries
		WHERE OrderID = @OrderID
	OPEN OrderEntryCursor
	FETCH NEXT FROM OrderEntryCursor INTO @PartID
	WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE @Quantity INT = (SELECT PartCount FROM OrderEntries WHERE PartID = @PartID AND OrderID = @OrderID), -- choose the order and the num of parts ordered
					@IterationCounter INT = 1,
					@NumOfPartsToTakeOut INT,
					@cur_row INT, @cur_col INT, @cur_lvl INT
			WHILE @Quantity > 0
				BEGIN
					PRINT CONCAT('DEBUG: PartID: ', @PartID ,' - Iteration #', @IterationCounter)
					DECLARE CompartmentCursor CURSOR FOR
						SELECT StorageRow, StorageColumn, StorageLevel
						FROM Storage
						WHERE PartID = @PartID
					OPEN CompartmentCursor
					FETCH NEXT FROM CompartmentCursor INTO @cur_row, @cur_col, @cur_lvl
					DECLARE	@NumInCompartment INT = (SELECT PartCount FROM Storage WHERE StorageRow = @cur_row AND StorageColumn = @cur_col AND StorageLevel = @cur_lvl) -- find the first compartment that holds this solar panel part
					IF @Quantity > @NumInCompartment
						BEGIN
							PRINT CONCAT('DEBUG: Quantity: ', @Quantity, ' > NumInCompartment: ', @NumInCompartment)
							SET @NumOfPartsToTakeOut = @NumInCompartment
						END
					ELSE
						BEGIN
							PRINT CONCAT('DEBUG: Quantity: ', @Quantity, ' <= NumInCompartment: ', @NumInCompartment)
							SET @NumOfPartsToTakeOut = @Quantity
						END
					UPDATE Storage
						SET PartCount = PartCount - @NumOfPartsToTakeOut
						WHERE CURRENT OF CompartmentCursor
					IF (SELECT PartCount FROM Storage WHERE StorageRow = @cur_row AND StorageColumn = @cur_col AND StorageLevel = @cur_lvl) = 0
						BEGIN 
							UPDATE Storage
							SET PartID = NULL
							WHERE CURRENT OF CompartmentCursor
						END
					SET @Quantity = @Quantity - @NumOfPartsToTakeOut
					SET @IterationCounter = @IterationCounter + 1
					CLOSE CompartmentCursor
					DEALLOCATE CompartmentCursor
				END
				FETCH NEXT FROM OrderEntryCursor INTO @PartID
		END
	CLOSE OrderEntryCursor;
	DEALLOCATE OrderEntryCursor;
	SELECT @@ROWCOUNT AS 'RowsAffected'
END
GO
-- REQ/C4: TEST/FullfillOrder
--EXEC FullfillOrder 1 -- OrderID => WARNING: look up and use proper parameters
--EXEC ListAllPartsAndInventory
--SELECT * FROM Orders
--SELECT * FROM OrderEntries
--EXEC ListAllPartsAndInventory
--SELECT * FROM Storage
--GO
----------------------- FUNCTIONS NOT IN REQUIREMENTS ----------------------- 
-------------------------------- SPECIALIST ---------------------------------
-- SP/DeleteProject
DROP PROC IF EXISTS DeleteProject
GO
CREATE OR ALTER PROCEDURE DeleteProject
	@ProjectID INT
AS
	BEGIN
		DELETE FROM Projects
		WHERE ProjectID = @ProjectID
	END
GO
-- TEST/DeleteProject
--SELECT * FROM ProjectLogEntries
--EXEC DeleteProject 1 -- ProjectID => WARNING: look up and use proper parameters
--GO
-- SP/UpdateProjectDescription
DROP PROC IF EXISTS UpdateProjectDescription
GO
CREATE OR ALTER PROCEDURE UpdateProjectDescription
	@ProjectID INT,
	@NewDescription VARCHAR(100)
AS
	BEGIN
		IF @NewDescription = ''
			BEGIN
				DECLARE @ErrorMessage varchar(100) = 'Error! A non-empty description is needed!'
				RAISERROR(@ErrorMessage, 16, 1)
				RETURN;
			END
		UPDATE Projects
			SET ProjectDescription = @NewDescription
			WHERE ProjectID = @projectID
		SELECT @@ROWCOUNT AS 'RowsAffected'
	END
GO
-- TEST/UpdateProjectDescription
--EXEC UpdateProjectPojectDescription 1, 'new description' -- ProjectID, NewDescription => WARNING: look up and use proper parameters
--EXEC UpdateProjectPojectDescription 1, '' -- ERROR: Empty description
--SELECT * FROM Projects
--GO
----------------------------- STORAGE MANAGER -------------------------------
-- SP/UpdatePartCountPerCompartment
DROP PROC IF EXISTS UpdatePartCountPerCompartment
GO
CREATE OR ALTER PROCEDURE UpdatePartCountPerCompartment
	@PartID INT,
	@NewCountPerCompartment INT
AS
	BEGIN
		IF @newCountPerCompartment < 1
			BEGIN
				DECLARE @ErrorMessage varchar(100) = 'Error! Count per compartment has to be at least 1!'
				RAISERROR(@ErrorMessage, 16, 1)
				RETURN
			END
		UPDATE Parts
			SET CountPerCompartment = @newCountPerCompartment
			WHERE PartID = @partID
		SELECT @@ROWCOUNT AS 'RowsAffected'
	END
--GO
-- TEST/UpdatePartCountPerCompartment
--EXEC UpdatePartCountPerCompartment 1, 10 -- PartID, NewCountPerCompartment => WARNING: look up and use proper parameters
--EXEC ListAllPartsAndInventory
--GO