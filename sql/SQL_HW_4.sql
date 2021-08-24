-- Assignment Day 4
--- ¡± Answer following quesions:
-- <Q 1>
/*
	A view is a virtual table whose contents are defined by a query.
	Like a real table, a view consists of a set of named columns and rows of data
	It can simplify Data Manipulation and also customize the data.
*/
-- <Q 2>
/*
	We can modify the view with permission and there are limitations. 
*/
-- <Q 3>
/*
	A stored procedure is a prepared SQL code that you can save, so the code can be reused over and over again.
*/
-- <Q 4>
/*
	A view is a virtual table and does not accpet parameters.
	A stored procedure accepts parameters to do a function and can contain several statement like if, else, loop etc..
*/
-- <Q 5>
/*
	Stored Procedure can have select clause as well as DML.
	Function will allow only select statements and it will not allow us to use DML.
*/
-- <Q 6>
/*
	Yes, it can.
*/
-- <Q 7>
/*
	We can execute a stored procedure implicitly from within a SELECT statement,
	because that the stored procedure returns a result set
*/
-- <Q 8>
/*
	Triggers are a special type of stored procedure that get executed (fired) when a specific event happens.
	We can create four types of triggers Data Definition Language (DDL) triggers, Data Manipulation Language (DML) triggers, CLR triggers, and Logon triggers.
*/
-- <Q 9>
/*
	Triggers are automatically fired  on a event. 
	We can use to implement business rules and maintain audit record of changes

*/
-- <Q 10>
/*
	A stored procedure is nothing more than prepared SQL code that you save so you can reuse the code over and over again.

	A trigger is a stored procedure that runs automatically when various events happen (eg update, insert, delete).
*/

--- ¡± Write queries:
USE Northwind
GO
-- <Q 1> Lock tables Region, Territories, EmployeeTerritories and Employees. 
--       Insert following information into the database. In case of an error, no changes should be made to DB.
-- A new region called ¡§Middle Earth¡¨;
SELECT	*
FROM	Region

BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO Region 
		VALUES (5, 'Middle Earth')
	ROLLBACK TRANSACTION
END TRY
BEGIN CATCH
	COMMIT TRANSACTION
END CATCH

SELECT	*
FROM	Region

-- A new territory called ¡§Gondor¡¨, belongs to region ¡§Middle Earth¡¨;
SELECT	*
FROM	Territories

BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO Territories 
		VALUES (NULL, 'Gondor', 5)
	ROLLBACK TRANSACTION
END TRY
BEGIN CATCH
	COMMIT TRANSACTION
END CATCH

SELECT	*
FROM	Territories

-- A new employee ¡§Aragorn King¡¨ who's territory is ¡§Gondor¡¨.
SELECT	*
FROM	EmployeeTerritories

BEGIN TRY
	BEGIN TRANSACTION
		--INSERT INTO Employees
		--VALUES (10, 'Aragorn King')

		INSERT INTO EmployeeTerritories 
		VALUES (10, 5)
	ROLLBACK TRANSACTION
END TRY
BEGIN CATCH
	COMMIT TRANSACTION
END CATCH

SELECT	*
FROM	EmployeeTerritories

-- <Q 2> Change territory ¡§Gondor¡¨ to ¡§Arnor¡¨.
UPDATE Territories 
SET TerritoryDescription = 'Arnor'
WHERE TerritoryDescription = 'Gondor'

-- <Q 3> Delete Region ¡§Middle Earth¡¨. (tip: remove referenced data first)
-- (Caution: do not forget WHERE or you will delete everything.) In case of an error, no changes should be made to DB. Unlock the tables mentioned in question 1.

--DELETE FROM EmployeeTerritories
--WHERE  EmployeeID = 10

--DELETE FROM Employees
--WHERE  EmployeeID = 10


--DELETE FROM Territories
--WHERE  RegionID = 5

--DELETE FROM Region
--WHERE  RegionDescription = 'Middle Earth'



-- <Q 4> Create a view named ¡§view_product_order_[your_last_name]¡¨, list all products and total ordered quantity for that product.
IF EXISTS (SELECT 1 from sys.views
		   WHERE Name = 'view_product_order_Chou')
DROP VIEW view_product_order_Chou
GO

CREATE VIEW view_product_order_Chou AS
SELECT		p.ProductID, 
			SUM(od.Quantity) AS TotalOrderQuantity
FROM		[Order Details] od
INNER JOIN	Products p ON od.ProductID = p.ProductID
GROUP BY	p.ProductID;

SELECT *
FROM view_product_order_Chou
ORDER BY 2 DESC;


-- <Q 5> Create a stored procedure "sp_product_order_quantity_[your_last_name]"
--       that accept product id as an input and total quantities of order as output parameter.
-- Using OUT:
IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'sp_product_order_quantity_Chou')
DROP PROC sp_product_order_quantity_Chou  
GO

CREATE PROC sp_product_order_quantity_Chou 
			@pID INT,
			@TotalQuan INT OUT
AS
BEGIN
	SELECT  @TotalQuan = TotalOrderQuantity
	FROM	view_product_order_Chou
	WHERE   ProductID = @pID
END

DECLARE @TOQ INT
EXEC	sp_product_order_quantity_Chou 60, @TOQ OUT
PRINT   @TOQ

-- Using Return:
IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'sp_product_order_quantity_Chou_return')
DROP PROC sp_product_order_quantity_Chou_return   
GO

CREATE PROC sp_product_order_quantity_Chou_return 
			@pID INT
AS
BEGIN
	RETURN (SELECT  TotalOrderQuantity
			FROM	view_product_order_Chou
			WHERE   ProductID = @pID)

END

DECLARE @Q INT
EXEC	@Q = sp_product_order_quantity_Chou_return 60
PRINT   @Q


-- <Q 6> Create a stored procedure ¡§sp_product_order_city_[your_last_name]¡¨  that accept  
-- product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.

IF EXISTS (SELECT 1 from sys.views
		   WHERE Name = 'myTempView')
DROP VIEW myTempView
GO

CREATE VIEW myTempView
AS (
SELECT      p.ProductName, o.ShipCity, SUM(od.Quantity) AS TotalQuantity
FROM		Orders o
INNER JOIN	[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN	Products p		   ON od.ProductID = p.ProductID 
GROUP BY	p.ProductName, o.ShipCity);
GO

--SELECT	 *
--FROM	 myTempView
--ORDER BY 1, 3 DESC;

IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'sp_product_order_city_Chou')
DROP PROC sp_product_order_city_Chou
GO

CREATE PROC sp_product_order_city_Chou 
			@ProdName VARCHAR(20)
AS
BEGIN
	SELECT	 TOP 5 ShipCity, TotalQuantity
	FROM	 myTempView
	WHERE	 ProductName = @ProdName
	ORDER BY TotalQuantity DESC
END
GO

EXEC	sp_product_order_city_Chou 'Tofu'


-- <Q 7> Lock tables Region, Territories, EmployeeTerritories and Employees. 
-- Create a stored procedure ¡§sp_move_employees_[your_last_name]¡¨ that automatically find all employees in territory ¡§Tory¡¨;
-- if more than 0 found, insert a new territory ¡§Stevens Point¡¨ of region ¡§North¡¨ to the database,
-- and then move those employees to ¡§Stevens Point¡¨.
IF EXISTS (SELECT 1 from sys.views
		   WHERE Name = 'myTempView')
DROP VIEW myTempView
GO

CREATE VIEW myTempView 
AS
(
SELECT et.EmployeeID, t.TerritoryID, t.TerritoryDescription, r.RegionID, r.RegionDescription
FROM Region r
INNER JOIN Territories t on r.RegionID = t.RegionID
INNER JOIN EmployeeTerritories et on t.TerritoryID = et.TerritoryID
)
GO

IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'sp_move_employees_Chou')
DROP PROC sp_move_employees_Chou
GO

CREATE PROC sp_move_employees_Chou
AS
BEGIN TRY
	BEGIN TRANSACTION
		SELECT  *
		FROM	myTempView
		WHERE	myTempView.TerritoryDescription = 'Troy'

		DECLARE @CountOfEmp INT
		SELECT	@CountOfEmp = COUNT(*)
		FROM	myTempView
		WHERE	TerritoryDescription = 'Troy'
		GROUP BY TerritoryDescription
		IF @CountOfEmp > 0
			BEGIN
				UPDATE myTempView
				SET	   TerritoryDescription = 'Stevens Point'
				WHERE  TerritoryDescription = 'Troy'
			END
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH

--EXEC sp_move_employees_Chou

--SELECT  *
--FROM	myTempView
--WHERE  TerritoryDescription = 'Troy'


-- <Q 8> Create a trigger that when there are more than 100 employees in territory ¡§Stevens Point¡¨, move them back to Troy. 
-- (After test your code,) remove the trigger. Move those employees back to ¡§Troy¡¨, if any. Unlock the tables.
CREATE TRIGGER testTrigger
ON	 Territories
AFTER INSERT, UPDATE
AS
BEGIN
	IF 100 <= (SELECT COUNT(*)
			   FROM Territories
			   WHERE TerritoryDescription = 'Stevens Point'
			   GROUP BY TerritoryDescription)
	BEGIN
		UPDATE Territories
		SET	   TerritoryDescription = 'Troy'
		WHERE  TerritoryDescription = 'Stevens Point'
	END
END


DROP TRIGGER testTrigger



-- <Q 9> 
USE AndrewPractice
GO

CREATE TABLE city_Chou
(
ID INT PRIMARY KEY IDENTITY(1,1),
CityName VARCHAR(MAX)
)

CREATE TABLE people_Chou
(
ID INT PRIMARY KEY IDENTITY(1,1),
FullName VARCHAR(MAX),
CityID INT FOREIGN KEY REFERENCES city_Chou(ID)
)

DELETE FROM people_Chou
DELETE FROM city_Chou

INSERT INTO city_Chou 
VALUES ('Seattle'), ('Green Bay')

INSERT INTO people_Chou 
VALUES  ('Aaron Rodgers', 2), ('Russell Wilson', 1), ('Jody Nelson', 2)

SELECT		*
FROM		people_Chou pc
INNER JOIN	city_Chou cc  ON pc.CityID = cc.ID

IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'tempProc')
DROP PROC tempProc
GO


DROP VIEW Packers_Chou

CREATE PROC tempProc AS
BEGIN TRANSACTION
	BEGIN TRY

		DECLARE		@CountFromSea INT
		SELECT		@CountFromSea = COUNT(*)
		FROM		people_Chou pc
		INNER JOIN	city_Chou cc  ON pc.CityID = cc.ID
		GROUP BY	cc.CityName
		HAVING		cc.CityName = 'Seattle'
		IF @CountFromSea > 0
			BEGIN
				UPDATE city_Chou
				SET	   CityName = 'Madison'
				WHERE  CityName = 'Seattle'
			END
	    GO

		CREATE VIEW Packers_Chou
		AS
		(SELECT		pc.CityID
		 FROM		people_Chou pc
         INNER JOIN	city_Chou cc  ON pc.CityID = cc.ID
		 WHERE cc.CityName = 'Green Bay')
		 GO

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH


EXEC tempProc

-- <Q 10> Create a stored procedure ¡§sp_birthday_employees_[you_last_name]¡¨ that creates a new table ¡§birthday_employees_your_last_name¡¨
-- and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'sp_birthday_employees_Chou')
DROP PROC sp_birthday_employees_Chou
GO

CREATE PROC sp_birthday_employees_Chou (@BirthMonth INT)
AS
SELECT FirstName + ' ' + LastName AS FullName, BirthDate
FROM   Employees
WHERE  MONTH(BirthDate) =  @BirthMonth
GO

EXEC sp_birthday_employees_Chou 2


-- <Q 11> Create a stored procedure named ¡§sp_your_last_name_1¡¨ that returns all cites that have at least 2 customers who have bought no or only one kind of product. 
-- Create a stored procedure named ¡§sp_your_last_name_2¡¨ that returns the same but using a different approach. (sub-query and no-sub-query).
-- a
IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'sp_Chou_1')
DROP PROC sp_Chou_1
GO

--IF EXISTS (SELECT 1 from tempdb.sys. 
--		   WHERE Name = '#MyTempTable')
DROP TABLE IF EXISTS tempdb.dbo.#MyTempTable

SELECT      o.OrderID, od.ProductID, c.ContactName, c.City INTO #MyTempTable
FROM		Orders o
INNER JOIN	[Order Details] od ON o.OrderID = od.OrderID
RIGHT JOIN	Customers c		   ON o.CustomerID = c.CustomerID
-- ORDER BY	1, 3


CREATE PROC sp_Chou_1
AS
SELECT City
FROM (SELECT   City, ContactName, COUNT(DISTINCT ProductID) AS Kinds
	  FROM	  #MyTempTable
	  GROUP BY City, ContactName
	  HAVING COUNT(DISTINCT ProductID) <= 1) dt
GROUP BY dt.City
HAVING COUNT(*) > 2

EXEC sp_Chou_1  -- In my understanding there is no city meet the qualification



-- b  
IF EXISTS (SELECT 1 from sys.procedures
		   WHERE Name = 'sp_Chou_2')
DROP PROC sp_Chou_2
GO

CREATE PROC sp_Chou_2
WITH cte AS	(SELECT   City, ContactName, COUNT(DISTINCT ProductID) AS Kinds
		 	 FROM	  #MyTempTable
			 GROUP BY City, ContactName
			 HAVING COUNT(DISTINCT ProductID) <= 1)
SELECT City
FROM cte
GROUP BY City
HAVING COUNT(*) > 2

EXEC sp_Chou_2


-- <Q 12> How do you make sure two tables have the same data?


-- <Q 14>
SELECT [First Name] + ' ' + [Last Name] + ' ' + [Middle Name] + '.' AS 'Full Name'
FROM T14

-- <Q 15>
WITH cte(
SELECT *
FROM T15
GROUP BY Sex
HAVING Sex = 'F')
SELECT Student
FROM T15
WHERE Marks = (SELECT TOP 1 MAX(Marks) FROM cte)

-- <Q 16>
SELECT *
FROM T15
ORDER BY 3, 1 DESC, 2 ASC
