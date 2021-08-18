USE AdventureWorks2019
GO
-- Assignment Day 1
-- <Q 1>
SELECT ProductID, Name, Color, ListPrice		
FROM   Production.Product

-- <Q 2>
-- the rows that ListPrice is 0
SELECT ProductID, Name, Color, ListPrice
FROM   Production.Product
WHERE  ListPrice = 0
-- exclude the rows that ListPrice is 0
SELECT ProductID, Name, Color, ListPrice
FROM   Production.Product
WHERE  ListPrice != 0		-- WHERE ListPrice <> 0

-- <Q 3>
SELECT ProductID, Name, Color, ListPrice
FROM   Production.Product
WHERE  Color IS NULL

-- <Q 4>
SELECT ProductID, Name, Color, ListPrice
FROM   Production.Product
WHERE  Color IS NOT NULL		-- WHERE NOT Color IS NULL

-- <Q 5>
SELECT ProductID, Name, Color, ListPrice
FROM   Production.Product
WHERE  color IS NOT NULL
       AND listprice > 0 

-- <Q 6>
SELECT Name + ' ' + Color AS Concatenation
FROM   Production.Product
WHERE  color IS NOT NULL

-- <Q 7>
SELECT 'NAME:' +  Name + ' -- ' + 'COLOR:' + Color AS [Name And Color]
FROM   Production.Product
WHERE  color IS NOT NULL

-- <Q 8>
SELECT ProductID, Name
FROM   Production.Product
WHERE  ProductID BETWEEN 400 AND 500

-- <Q 9>
SELECT ProductID, Name, Color
FROM   Production.Product
WHERE  Color IN ('black', 'blue')

-- <Q 10>
SELECT Name
FROM   Production.Product
WHERE  Name LIKE 'S%'

-- <Q 11>
SELECT Name, ListPrice
FROM   Production.Product
WHERE  Name LIKE 'S%'
ORDER BY 1		-- ORDER BY Name

-- <Q 12>
SELECT Name, ListPrice
FROM   Production.Product
WHERE  Name LIKE 'S%' OR Name LIKE 'A%'		-- WHERE  Name LIKE '[AS]%'		-- WHERE  Name LIKE '[A,S]%'
ORDER BY Name

-- <Q 13>
SELECT   Name, ListPrice
FROM     Production.Product
WHERE    Name LIKE 'SPO[^K]%'
ORDER BY Name

-- <Q 14>
SELECT   DISTINCT Color
FROM     Production.Product
ORDER BY 1 DESC

-- <Q 15>
SELECT  DISTINCT ProductSubcategoryID, Color
FROM    Production.Product 
WHERE   ProductSubcategoryID IS NOT NULL AND
		Color IS NOT NULL

-- <Q 16>
-- The question can be intrepreted in many ways, here I only extract the rows with ProductSubcategoryID = 1
SELECT	  ProductSubcategoryID,
		  LEFT([Name], 35) AS [Nmae],
		  Color,
		  ListPrice
FROM	  Production.Product
WHERE	  (Color NOT IN ('red', 'black') OR ListPrice BETWEEN 1000 AND 2000) AND
		  ProductSubcategoryID = 1
ORDER BY  1, 3, 4