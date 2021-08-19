--- Assignment Day 3

--- ¡± Answer following quesions:
-- <Q 1>
/*
	I prefer using join than subquery. Although sometimes it is more readable using subquery, join makes use of less resources than the subquery. 
*/
-- <Q 2>
/*
	CTE stands for the Common TABLE Expression, is a temporary result set that you can reference within another SELECT, INSERT, UPDATE, or DELETE statement.
*/	
-- <Q 3>
/*
	The table variable is a special data type that can be used to store temporary data, it is like a temporary table.
	The scope of SQL table variable is within the batch, stored procedure and function.
	Lastly, table variables are stored in the tempdb database.
*/
-- <Q 4>
/*
	Delete: is a DML command, it removes single, some or all rows in a table.
	Truncate: is a DDL command, and is used to remove all the rows from the table.
	TRUNCATE command is faster than DELETE command, since the TRUNCATE command does not log entries for each deleted row in the transaction log.
	While in the DELETE command, a tuple is locked before removing it.
*/
-- <Q 5>
/*
	IDENTITY column is a special type of column that is used to automatically generate key values based on a provided seed (starting point) and increment.
	While using DELETE, it retains the identity and does not reset it to the seed value. Wheras TRUNCATE command reset the identity to its seed value.
*/
-- <Q 6>
/*
	DELETE without the WHERE clause will remove the whole rows, and TRUNCATE the table will also remove the whole data in table.
	In the DELETE command, for each row a tuple is locked before removing it.
	While in TRUNCATE command, data page is locked before removing the table data. Hence, TRUNCATE command is faster than DELETE command.
*/

--- ¡± Write queries:
USE Northwind
GO
-- <Q 1> List all cities that have both Employees and Customers.
SELECT DISTINCT City
FROM Employees
INTERSECT
SELECT DISTINCT City
FROM Customers

-- <Q 2> List all cities that have Customers but no Employee.
-- a. use subquery
SELECT	DISTINCT c.City
FROM	Customers c
WHERE	c.City NOT IN (SELECT e.City 
					   FROM Employees e)

-- b. not use subquery
SELECT		DISTINCT c.City
FROM		Customers c
LEFT JOIN	Employees e ON c.City = e.City
WHERE		e.City IS NULL

-- <Q 3> List all products and their total order quantities throughout all orders.
SELECT		od.ProductID, p.ProductName,
			sum(od.Quantity) AS TotalOrderQuantity
FROM		Orders o 
INNER JOIN	[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN	Products p		   ON od.ProductID = p.ProductID
GROUP BY	od.ProductID, p.ProductName
ORDER BY	2 DESC

-- <Q 4> List all Customer Cities and total products ordered by that city.
SELECT		c.City AS CustomerCity,
			sum(od.Quantity) AS TotalProductsOrderd
FROM		Customers c
LEFT JOIN	Orders o		   ON	c.CustomerID = o.CustomerID
INNER JOIN	[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN	Products p         ON od.ProductID = p.ProductID
GROUP BY	c.CustomerID, c.City
ORDER BY	2 DESC, 1

-- <Q 5> List all Customer Cities that have at least two customers.
/*
SELECT   City
FROM     Customers
GROUP BY City
HAVING   COUNT(*) >= 2
*/
-- Use Union  
SELECT    City
FROM	  Customers
GROUP BY  City
HAVING    COUNT(*) > 2
UNION
SELECT    City
FROM	  Customers
GROUP BY  City
HAVING    COUNT(*) = 2

-- Use subquery and no Union
SELECT	DISTINCT c1.City
FROM	Customers c1
WHERE	c1.City		IN (SELECT c2.City
						FROM Customers c2
						GROUP BY c2.City
						HAVING COUNT(c2.City) >= 2
						)

-- <Q 6> List all Customer Cities that have ordered at least two different kinds of products.
SELECT		c.City AS CustomerCity,
			COUNT(p.ProductID) AS KindsOfProducts
FROM		Customers c
LEFT JOIN	Orders o			ON	c.CustomerID = o.CustomerID
INNER JOIN	[Order Details] od  ON o.OrderID = od.OrderID
INNER JOIN	Products p			ON od.ProductID = p.ProductID
GROUP BY	c.City
HAVING		COUNT(p.ProductID) >= 2
ORDER BY	2

-- <Q 7> List all Customers who have ordered products, but have the ¡¥ship city¡¦ on the order different from their own customer cities.
SELECT	   DISTINCT c.CustomerID, c.ContactName, c.City, o.ShipCity
FROM	   Orders o 
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE	   o.ShipCity <> c.City

-- <Q 8> List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
with cte1 AS(
SELECT		TOP 5 od.ProductID, p.ProductName,
			sum(od.Quantity) AS TotalQuantity,
			AVG(od.UnitPrice) AS AvgPrice
FROM		Orders o 
INNER JOIN	[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN	Products p		   ON od.ProductID = p.ProductID
GROUP BY	od.ProductID, p.ProductName
ORDER BY	3 DESC
),
	cte2 AS(		
SELECT		
			od.ProductID, p.ProductName,
			SUM(od.Quantity) AS TotalProductQuantity,
			DENSE_RANK() OVER(PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS RNK,
			c.City
FROM		Orders o 
INNER JOIN	[Order Details] od ON o.OrderID = od.OrderID
INNER JOIN	Products p		   ON od.ProductID = p.ProductID
INNER JOIN  Customers c        ON o.CustomerID = c.CustomerID
GROUP BY	od.ProductID, c.City, p.ProductName
)
SELECT     cte1.ProductName, cte1.AvgPrice, cte2.City AS MostOrderCity
FROM	   cte1 
INNER JOIN cte2 ON cte1.ProductID = cte2.ProductID
WHERE	   cte2.RNK = 1
ORDER BY   cte1.TotalQuantity DESC

-- <Q 9> List all cities that have never ordered something but we have employees there.
-- Use sub-query
WITH OrderCityCTE AS(
SELECT		 DISTINCT c.City 
FROM		 Orders o
INNER JOIN   Customers c ON o.CustomerID = c.CustomerID
)
SELECT DISTINCT e.City
FROM   Employees e
WHERE  e.City NOT IN (SELECT * FROM OrderCityCTE)

-- Do not use sub-query
SELECT DISTINCT City
FROM   Employees e
EXCEPT
SELECT DISTINCT City
FROM   Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID



-- <Q 10> List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is,
--        and also the city of most total quantity of products ordered from. (tip: join  sub-query)
WITH cte AS(
SELECT		COUNT(o.EmployeeID) AS MostOrder, o.EmployeeID, e.FirstName
FROM		Orders o
INNER JOIN  Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY    o.EmployeeID, e.FirstName
), cte2 AS(
SELECT		o.EmployeeID, e.FirstName, c.City,
			COUNT(o.OrderID) NumOrder, 
			RANK() OVER(PARTITION BY o.EmployeeID ORDER BY COUNT(o.OrderID) DESC) AS RNK
FROM		Orders o
INNER JOIN  Customers c        ON o.CustomerID = c.CustomerID
INNER JOIN  Employees e		   ON o.EmployeeID = e.EmployeeID
WHERE		o.EmployeeID = (SELECT EmployeeID FROM cte WHERE MostOrder = (SELECT MAX(MostOrder) FROM cte))
GROUP BY    o.EmployeeID, e.FirstName, c.City
)
SELECT *
FROM cte2
WHERE RNK = 1

-- <Q 11>
/*
	We can remove the duplicates by using distinct after the SELECT or using UNION to combine itself.
*/

-- <Q 12>  Find employees who do not manage anybody.
WITH empHierarchyCTE
AS
(
SELECT		empID, mgrID, 1 LVL 
FROM		Employee 
WHERE		mgrid IS NULL
UNION ALL
SELECT		e.empID, e.mgrID, cte.LVL + 1
FROM		Employee e 
INNER JOIN	empHierarchyCTE cte ON e.mgrID = cte.empID
)
SELECT * 
FROM	empHierarchyCTE
WHERE	LVL = (SELECT MAX(LVL)
			   FROM  empHierarchyCTE)

-- <Q 13> Find departments that have maximum number of employees.
SELECT		temp.depName,
			temp.CountEmployee
			
FROM 
(
SELECT		d.depID, 
			d.depName,
			RANK() OVER(PARTITION BY d.depID ORDER BY COUNT(*) DESC) AS NumEmployeeRNK,
			COUNT(*) AS CountEmployee
FROM		Employee e
INNER JOIN  Dept d  ON e.depID = d.detID
GROUP BY    d.depID, d.depName
) temp
WHERE		NumEmployeeRNK = 1
ORDER BY    1

-- <Q 14> Find top 3 employees (salary based) in every department
SELECT   temp.depName, 
		 e1.empID,
		 e1.Salary,
FROM	 Employee    e1
JOIN	 (SELECT		d.depName,
					    e.empID,
					    RANK() OVER(PARTITION BY d.depID ORDER BY e.Salary DESC) AS SalaryRNK
		 FROM		    Employee e
		 JOIN		    Dept     d   ON e.depID = d.detID
		 GROUP BY       d.depName, e.empID
		 ) temp
ON		 e1.empID = temp.empID
WHERE    SalaryRNK <= 3
ORDER BY 1, 3 DESC
