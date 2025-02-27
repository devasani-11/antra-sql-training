USE AdventureWorks2019
GO

-- 1. How many products can you find in the Production.Product table?
SELECT COUNT(*) AS TotalProducts  
FROM Production.Product;

/* 2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
 The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory. */
SELECT COUNT(*) AS ProductsWithSubcategory  
FROM Production.Product  
WHERE ProductSubcategoryID IS NOT NULL;

/*  3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
 ProductSubcategoryID CountedProducts */
SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts  
FROM Production.Product  
GROUP BY ProductSubcategoryID;

-- 4. How many products that do not have a product subcategory.
SELECT COUNT(*) AS ProductsWithoutSubcategory  
FROM Production.Product  
WHERE ProductSubcategoryID IS NULL;

-- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) AS TotalQuantity  
FROM Production.ProductInventory;

/* 6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 
 and limit the result to include just summarized quantities less than 100.
   ProductID    TheSum */
SELECT ProductID, SUM(Quantity) AS TheSum  
FROM Production.ProductInventory  
WHERE LocationID = 40  
GROUP BY ProductID  
HAVING SUM(Quantity) < 100;

/* 7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and 
LocationID set to 40 and limit the result to include just summarized quantities less than 100
    Shelf      ProductID    TheSum */
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum  
FROM Production.ProductInventory  
WHERE LocationID = 40  
GROUP BY Shelf, ProductID  
HAVING SUM(Quantity) < 100;

/* 8. Write the query to list the average quantity for products where 
column LocationID has the value of 10 from the table Production.ProductInventory table. */
SELECT AVG(Quantity) AS AvgQuantity  
FROM Production.ProductInventory  
WHERE LocationID = 10;

/* 9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
    ProductID   Shelf      TheAvg */
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg  
FROM Production.ProductInventory  
GROUP BY ProductID, Shelf;

/* 10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A 
in the column Shelf from the table Production.ProductInventory
    ProductID   Shelf      TheAvg */
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg  
FROM Production.ProductInventory  
WHERE Shelf <> 'N/A'  
GROUP BY ProductID, Shelf;

/* 11. List the members (rows) and average list price in the Production.Product table. 
This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
    Color                        Class              TheCount          AvgPrice */
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice  
FROM Production.Product  
WHERE Color IS NOT NULL AND Class IS NOT NULL  
GROUP BY Color, Class;

/*12.  Write a query that lists the country and province names from person. CountryRegion and person. 
StateProvince tables. Join them and produce a result set similar to the following.
    Country                        Province */
SELECT c.Name AS Country, s.Name AS Province  
FROM Person.CountryRegion c  
JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode;

/* 13. Write a query that lists the country and province names from person. CountryRegion and person. 
StateProvince tables and list the countries filter them by Germany and Canada. 
Join them and produce a result set similar to the following.
    Country                        Province */
SELECT c.Name AS Country, s.Name AS Province  
FROM Person.CountryRegion c  
JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode  
WHERE c.Name IN ('Germany', 'Canada');

-- 14.  List all Products that has been sold at least once in last 27 years. 
SELECT DISTINCT p.ProductID, p.Name  
FROM Production.Product p  
JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID  
JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID  
WHERE soh.OrderDate >= DATEADD(YEAR, -27, GETDATE());


-- 15.  List top 5 locations (Zip Code) where the products sold most. 
SELECT TOP 5 a.PostalCode, COUNT(sod.ProductID) AS TotalProductsSold  
FROM Sales.SalesOrderHeader soh  
JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID  
JOIN Person.Address a ON soh.ShipToAddressID = a.AddressID  
GROUP BY a.PostalCode  
ORDER BY COUNT(sod.ProductID) DESC;



-- 16.  List top 5 locations (Zip Code) where the products sold most in last 27 years. 
SELECT TOP 5 a.PostalCode, COUNT(sod.ProductID) AS TotalProductsSold  
FROM Sales.SalesOrderHeader soh  
JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID  
JOIN Person.Address a ON soh.ShipToAddressID = a.AddressID  
WHERE soh.OrderDate >= DATEADD(YEAR, -27, GETDATE())  
GROUP BY a.PostalCode  
ORDER BY COUNT(sod.ProductID) DESC;


-- 17.   List all city names and number of customers in that city.     
SELECT a.City, COUNT(c.CustomerID) AS NumberOfCustomers  
FROM Sales.Customer c  
JOIN Person.BusinessEntityAddress bea ON c.CustomerID = bea.BusinessEntityID  
JOIN Person.Address a ON bea.AddressID = a.AddressID  
GROUP BY a.City  
ORDER BY NumberOfCustomers DESC;


-- 18.  List city names which have more than 2 customers, and number of customers in that city 
SELECT a.City, COUNT(c.CustomerID) AS NumberOfCustomers  
FROM Sales.Customer c  
JOIN Person.BusinessEntityAddress bea ON c.CustomerID = bea.BusinessEntityID  
JOIN Person.Address a ON bea.AddressID = a.AddressID  
GROUP BY a.City  
HAVING COUNT(c.CustomerID) > 2  
ORDER BY NumberOfCustomers DESC;



-- 19.  List the names of customers who placed orders after 1/1/98 with order date. 
SELECT DISTINCT c.CustomerID, p.FirstName, p.LastName, soh.OrderDate  
FROM Sales.Customer c  
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID  
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID  
WHERE soh.OrderDate > '1998-01-01'  
ORDER BY soh.OrderDate;



-- 20.  List the names of all customers with most recent order dates 
SELECT c.CustomerID, p.FirstName, p.LastName, MAX(soh.OrderDate) AS MostRecentOrderDate  
FROM Sales.Customer c  
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID  
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID  
GROUP BY c.CustomerID, p.FirstName, p.LastName  
ORDER BY MostRecentOrderDate DESC;



-- 21.  Display the names of all customers  along with the  count of products they bought 
SELECT c.CustomerID, p.FirstName, p.LastName, COUNT(sod.ProductID) AS TotalProductsBought  
FROM Sales.Customer c  
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID  
JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID  
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID  
GROUP BY c.CustomerID, p.FirstName, p.LastName  
ORDER BY TotalProductsBought DESC;


-- 22.  Display the customer ids who bought more than 100 Products with count of products. 
SELECT c.CustomerID, COUNT(sod.ProductID) AS TotalProductsBought  
FROM Sales.Customer c  
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID  
JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID  
GROUP BY c.CustomerID  
HAVING COUNT(sod.ProductID) > 100  
ORDER BY TotalProductsBought DESC;



/* 23.  List all of the possible ways that suppliers can ship their products. Display the results as below
    Supplier Company Name                Shipping Company Name */
SELECT v.Name AS SupplierCompanyName, sm.Name AS ShippingCompanyName  
FROM Purchasing.Vendor v  
CROSS JOIN Purchasing.ShipMethod sm  
ORDER BY SupplierCompanyName, ShippingCompanyName;



-- 24.  Display the products order each day. Show Order date and Product Name.
SELECT soh.OrderDate, p.Name AS ProductName  
FROM Sales.SalesOrderHeader soh  
JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID  
JOIN Production.Product p ON sod.ProductID = p.ProductID  
ORDER BY soh.OrderDate, ProductName;


-- 25.  Displays pairs of employees who have the same job title.
SELECT e1.BusinessEntityID AS Employee1, e2.BusinessEntityID AS Employee2, e1.JobTitle  
FROM HumanResources.Employee e1  
JOIN HumanResources.Employee e2  
ON e1.JobTitle = e2.JobTitle AND e1.BusinessEntityID < e2.BusinessEntityID  
ORDER BY e1.JobTitle;



-- 26.  Display all the Managers who have more than 2 employees reporting to them.
SELECT m.BusinessEntityID AS ManagerID, m.JobTitle, COUNT(e.BusinessEntityID) AS NumEmployees  
FROM HumanResources.Employee e  
JOIN HumanResources.Employee m ON e.OrganizationNode = m.OrganizationNode  
GROUP BY m.BusinessEntityID, m.JobTitle  
HAVING COUNT(e.BusinessEntityID) > 2  
ORDER BY NumEmployees DESC;



-- 27.  Display the customers and suppliers by city. The results should have the following columns
SELECT a.City, c.AccountNumber AS Name, p.FirstName + ' ' + p.LastName AS ContactName, 'Customer' AS Type  
FROM Sales.Customer c  
JOIN Person.BusinessEntityAddress bea ON c.CustomerID = bea.BusinessEntityID  
JOIN Person.Address a ON bea.AddressID = a.AddressID  
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID  

UNION  

SELECT a.City, v.Name AS Name, NULL AS ContactName, 'Supplier' AS Type  
FROM Purchasing.Vendor v  
JOIN Person.BusinessEntityAddress bea ON v.BusinessEntityID = bea.BusinessEntityID  
JOIN Person.Address a ON bea.AddressID = a.AddressID  

ORDER BY City, Type;










