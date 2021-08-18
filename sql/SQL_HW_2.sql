-- Assignment Day 2
-- Question Part:
-- <Q 1> What is a result set?
/*
	A result set is the resulting query stored in a result table, it contains a set of rows from a database and metadata.
*/

-- <Q 2> What is the difference between Union and Union All?
/*
  Both the UNION and UNION ALL command combines the result set of two or more SELECT statements.
  UNION ALL keeps all of the records from each of the original data sets, UNION removes any duplicate records.
*/
 
-- <Q 3> What are the other Set Operators SQL Server has?
/*
  In Set Operators, MS SQL Server also has EXCEPT and INTERSECT.
*/

-- <Q 4> What is the difference between Union and Join?
/*
	Union is used to combine multiple SELECT statements. It combines data into new rows
	Join is used to combine multiple relational tables with primary key and foriegn key. It combines data into new columns.
	To UNION two SELECT statement, the number of columns must be the same and must be of the same data type in order for both select statements.
	Wheras in Join, number of columns selected from each table may not be same and Datatypes of corresponding columns selected from each table can be different.
*/

-- <Q 5> What is the difference between INNER JOIN and FULL JOIN?
/*
  INNER JOIN returns rows when there is a match in both tables.
  A Full Join returns all the rows from the joined tables, whether they are matched or not.
*/

-- <Q 6> What is difference between left join and outer join
/*
	'LEFT JOIN' is a short hand for 'LEFT OUTER JOIN'. We can claim that left join is one kind of outer join.
	In an outer join, unmatched rows in one or both tables can be returned.
	There are three types of outher join, that is, 'left outer join', 'right outer join', and 'full outer join'.

*/

-- <Q 7> What is cross join?
/*
	CROSS JOIN returns the Cartesian product of rows from the joined tables.
	Simply put, CROSS JOIN is used when you need to find out all the possibilities of combining two tables. 

*/

-- <Q 8> What is the difference between WHERE clause and HAVING clause?
/*
  Both WHERE and HAVING are used as filters, the differences are listed as below:
				Where						|			  	Having
---------------------------------------------------------------------------------
Applies to indivudual rows					| Applies only to groups as a whole
Implements before aggregatoin				| Implements after aggregatoin	
Can be used in SELECT / UPDATE statement    | Can be only used in SELECT statement
*/

-- <Q 9> Can there be multiple group by columns?
/*
  Yes, we can have multiple columns in GROUP BY clause,
  it will group by the data in the order of the columns we write from left to the right in the GROUP BY clause. 
*/



USE AdventureWorks2019
GO
-- Query Part:
-- <Q 1>
SELECT  COUNT (DISTINCT ProductID) AS num_of_products
FROM	Production.Product

-- <Q 2>
SELECT  COUNT (DISTINCT ProductID) AS num_of_products
FROM	Production.Product
WHERE   ProductSubcategoryID IS NOT NULL

-- <Q 3>
SELECT    ProductSubcategoryID, COUNT (*) AS CountedProducts
FROM	  Production.Product
GROUP BY  ProductSubcategoryID
HAVING    ProductSubcategoryID IS NOT NULL

/*
SELECT    ProductSubcategoryID, COUNT (ProductSubcategoryID) AS CountedProducts
FROM	  Production.Product
WHERE     ProductSubcategoryID IS NOT NULL
GROUP BY  ProductSubcategoryID
*/

-- <Q 4>
SELECT  COUNT (*) AS num_of_products_withoutSubCategory
FROM	Production.Product
WHERE   ProductSubcategoryID IS NULL

-- <Q 5>
SELECT  SUM(Quantity) AS sum_of_product_quantity
FROM	Production.ProductInventory

-- <Q 6>
SELECT   ProductID, SUM(Quantity) AS TheSum
FROM	 Production.ProductInventory
WHERE    LocationID = 40
GROUP BY ProductID
HAVING   SUM(Quantity) < 100
ORDER BY ProductID

-- <Q 7>
SELECT   Shelf, ProductID, SUM(Quantity) AS TheSum
FROM	 Production.ProductInventory
WHERE    LocationID = 40
GROUP BY Shelf, ProductID 
HAVING   SUM(Quantity) < 100

-- <Q 8>
SELECT  AVG(Quantity) AS avg_of_product_quantity
FROM	Production.ProductInventory
WHERE   LocationID = 10

-- <Q 9>
SELECT   ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM	 Production.ProductInventory
GROUP BY ProductID, Shelf

-- <Q 10>
SELECT   ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM	 Production.ProductInventory
GROUP BY ProductID, Shelf
HAVING   Shelf != 'N/A'

-- <Q 11>
SELECT   Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM     Production.Product
WHERE    Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class 

-- <Q 12>
SELECT  DISTINCT pc.Name AS Country, ps.Name AS Province 
FROM Person.CountryRegion pc
LEFT JOIN Person.StateProvince ps on pc.CountryRegionCode = ps.CountryRegionCode
ORDER BY 1, 2

-- <Q 13>
SELECT  DISTINCT pc.Name AS Country, ps.Name AS Province 
FROM Person.CountryRegion pc
LEFT JOIN Person.StateProvince ps on pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.Name IN ('Germany', 'Canada')
ORDER BY 1, 2


-- Using another database
USE Northwind
GO

SELECT *
FROM dbo.Products

SELECT *
FROM dbo.[Order Details]

SELECT *
FROM dbo.Orders

SELECT *
FROM dbo.Customers

-- <Q 14> 
SELECT DISTINCT p.ProductID, p.ProductName
FROM   dbo.Orders o
JOIN   dbo.[Order Details] od ON o.OrderID = od.OrderID
JOIN   dbo.Products p ON od.ProductID = p.ProductID
WHERE  YEAR(GETDATE()) - YEAR(o.OrderDate) < 25
ORDER BY 1

-- <Q 15> 
SELECT     TOP 5 c.PostalCode AS ZipCode, sum(od.Quantity) AS NumProductBought
FROM	   dbo.Orders o
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
GROUP BY   c.PostalCode
HAVING	   c.PostalCode IS NOT NULL
ORDER BY   2 DESC

-- <Q 16> 
SELECT     TOP 5 c.PostalCode AS ZipCode, sum(od.Quantity) AS NumProductBought
FROM	   dbo.Orders o
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
WHERE      YEAR(GETDATE()) - YEAR(o.OrderDate) < 25
GROUP BY   c.PostalCode
HAVING	   c.PostalCode IS NOT NULL
ORDER BY   2 DESC

-- <Q 17>
SELECT   City, COUNT(*) AS NumCustomer
FROM     dbo.Customers
GROUP BY City
ORDER BY 2 DESC, 1 ASC

-- <Q 18>
SELECT   City, COUNT(*) AS NumCustomer
FROM     dbo.Customers
GROUP BY City
HAVING   COUNT(*) > 2 
ORDER BY 2 DESC, 1 ASC

-- <Q 19>
SELECT     DISTINCT c.ContactName
FROM	   dbo.Orders o
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
WHERE      YEAR(OrderDate) >= 1998

-- <Q 20> 
SELECT     c.ContactName AS CustomerName,
		   MAX(o.OrderDate) AS MostRecentOrderDate
FROM	   dbo.Orders o
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
GROUP BY   c.ContactName
ORDER BY   2 DESC, 1 ASC

-- <Q 21>
SELECT     c.ContactName, sum(od.Quantity) AS NumProductBought
FROM	   dbo.Orders o
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
GROUP BY   c.ContactName
ORDER BY   2 DESC, 1 ASC

-- <Q 22>
SELECT     c.CustomerID, sum(od.Quantity) AS NumProductBought
FROM	   dbo.Orders o
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN dbo.Customers c ON o.CustomerID = c.CustomerID
GROUP BY   c.CustomerID
HAVING	   sum(od.Quantity) > 100
ORDER BY   2 DESC, 1 ASC

-- <Q 23>
SELECT     sup.CompanyName AS 'Supplier Company Name',
	       shi.CompanyName AS 'Shipping Company Name'
FROM       dbo.Shippers shi
CROSS JOIN dbo.Suppliers sup
ORDER BY   1, 2

-- <Q 24>
SELECT     o.OrderDate, p.ProductName
FROM       dbo.Orders o
INNER JOIN dbo.[Order Details] od ON o.OrderID = od.OrderID 
INNER JOIN dbo.Products p ON od.ProductID = p.ProductID 
GROUP BY   o.OrderDate, p.ProductName
ORDER BY   1

-- <Q 25>
SELECT e1.EmployeeID, e1.FirstName + ' ' + e1.LastName AS FullName, e1.Title,
	   e2.EmployeeID, e2.FirstName + ' ' + e2.LastName AS FullName, e2.Title
	 
FROM   dbo.Employees e1, dbo.Employees e2 
WHERE  e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID


-- <Q 26>
SELECT   m.FirstName + ' ' + m.LastName AS Manager, count(*) as NumOfEmployee
FROM     dbo.Employees e
JOIN     dbo.Employees m ON e.ReportsTo = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING   count(*) > 2

-- <Q 27>
SELECT City AS CityName, ContactName, 'Customer' AS Type
FROM   dbo.Customers
UNION
SELECT City AS CityName, ContactName, 'Supplier' AS Type
FROM   dbo.Suppliers
ORDER BY 3, 1, 2

-- <Q 28>
/*
SELECT      T1.F1 AS col1, T2.F2 AS col2
FROM        T1 
INNER JOIN  T2 ON T1.F1 = T2.F2
*/
-- The result will like:
-- col1		col2
--  2         2
--  3         3

-- <Q 29>
/*
SELECT      T1.F1 AS col1, T2.F2 AS col2
FROM        T1 
LEFT JOIN   T2 ON T1.F1 = T2.F2
*/
-- The result will like:
-- col1		col2
--  1       null
--  2         2
--  3         3