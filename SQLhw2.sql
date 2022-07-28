--Joins:
--(AdventureWorks)
--1. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables.
--Join them and produce a result set similar to the following.
--Country                        Province
SELECT c.Name Country, s.Name Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode

--2. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and 
--list the countries filter them by Germany and Canada.Join them and produce a result set similar to the following.
--Country                        Province
SELECT c.Name Country, s.Name Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Germany', 'Canada')

--Using Northwind Database: (Use aliases for all the Joins)
--3. List all Products that has been sold at least once in last 25 years.
SELECT DISTINCT p.ProductID, p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p on p.ProductID = od.ProductID
WHERE DATEDIFF(yy, o.OrderDate, GETDATE()) <= 25

--4. List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP 5 o.ShipPostalCode, COUNT(p.ProductID) as TotalSold
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p on p.ProductID = od.ProductID
WHERE DATEDIFF(yy, o.OrderDate, GETDATE()) <= 25
GROUP BY o.ShipPostalCode
ORDER BY TotalSold DESC

--5. List all city names and number of customers in that city.     
SELECT c.City, COUNT(c.CustomerID) NumOfCustomer
FROM Customers c
GROUP BY c.City
ORDER BY NumOfCustomer DESC

--6. List city names which have more than 2 customers, and number of customers in that city
SELECT c.City, COUNT(c.CustomerID) NumOfCustomer
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) > 2
ORDER BY NumOfCustomer DESC

--7. Display the names of all customers along with the count of products they bought
SELECT c.ContactName, COUNT(od.ProductID) NumOfProduct
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.ContactName
ORDER BY NumOfProduct DESC

--8. Display the customer ids who bought more than 100 Products with count of products.
SELECT o.CustomerID, COUNT(od.ProductID) NumOfProduct
FROM Orders o JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY o.CustomerID
HAVING COUNT(od.ProductID) > 100
ORDER BY NumOfProduct DESC

--9. List all of the possible ways that suppliers can ship their products. Display the results as below
--Supplier Company Name                Shipping Company Name
SELECT DISTINCT s.CompanyName [Supplier Company Name],  sh.CompanyName [Shipping Company Name]
FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID JOIN [Order Details] od ON od.ProductID = p.ProductID JOIN Orders o ON o.OrderID = od.OrderID JOIN Shippers sh ON sh.ShipperID = o.ShipVia

--10. Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON p.ProductID = od.ProductID
GROUP BY o.OrderDate, p.ProductName

--11. Displays pairs of employees who have the same job title.
SELECT e1.LastName + ' ' + e1.FirstName Employee1,  e2.LastName + ' ' + e2.FirstName Employee2
FROM Employees e1 JOIN Employees e2 ON e1.Title = e2.Title
WHERE e1.LastName + ' ' + e1.FirstName != e2.LastName + ' ' + e2.FirstName

--12. Display all the Managers who have more than 2 employees reporting to them.
SELECT m.LastName, m.FirstName, COUNT(e.EmployeeID) NumOfEmployee
FROM Employees e JOIN Employees m ON e.ReportsTo = m.EmployeeID
GROUP BY m.LastName, m.FirstName
HAVING COUNT(e.EmployeeID) > 2

--13. Display the customers and suppliers by city. The results should have the following columns
--City, Name, Contact Name, Type (Customer or Supplier)
SELECT City, CompanyName Name, ContactName [Contact Name], 'Customer' Type
FROM Customers
UNION
SELECT City, CompanyName, ContactName, 'Supplier' 
FROM Suppliers

--All scenarios are based on Database NORTHWIND.
--14. List all cities that have both Employees and Customers.
SELECT c.City
FROM Customers c JOIN Employees e ON c.City = e.City

--15. List all cities that have Customers but no Employee.
--a.Use sub-query
SELECT City  
FROM Customers
WHERE City NOT IN (
    SELECT City FROM Employees
)

--b.Do not use sub-query
SELECT c.City
FROM Customers c LEFT JOIN Employees e ON c.City = e.City
WHERE e.EmployeeID IS NULL

--16. List all products and their total order quantities throughout all orders.
SELECT ProductID, SUM(Quantity)
FROM [Order Details]
GROUP BY ProductID

--17. List all Customer Cities that have at least two customers.
--a.Use union
SELECT City, COUNT(CustomerID) NumOfCustomer
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) = 2
UNION
SELECT City, COUNT(CustomerID) NumOfCustomer
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) > 2

--b.Use no union
SELECT City, COUNT(CustomerID) NumOfCustomer
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2

--18. List all Customer Cities that have ordered at least two different kinds of products.
SELECT o.ShipCity, COUNT(od.ProductID)
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.ShipCity
HAVING COUNT(od.ProductID) >= 2
 
--19. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
SELECT TOP 5 ProductID, AVG(UnitPrice) AvgPrice, o.ShipCity
FROM [Order Details] od JOIN Orders o ON o.OrderID = od.OrderID
GROUP BY ProductID, o.ShipCity
ORDER BY SUM(Quantity) DESC

--20. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
--and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT (SELECT Top 1 e.City
FROM Orders o JOIN Employees e ON o.EmployeeID = e.EmployeeID
GROUP BY e.City, e.EmployeeID
ORDER BY COUNT(o.OrderID) DESC) SoldMostOrdersCity,
(SELECT Top 1 c.City FROM [Order Details] od JOIN Orders o ON o.OrderID = od.OrderID JOIN Customers c ON c.CustomerID = o.CustomerID
GROUP BY c.City ORDER BY SUM(od.Quantity) DESC) MostQuantityOrdersCity

--21. How do you remove the duplicates record of a table?
use ROW_NUMBER() with PARTITION BY and delete the row where ROW_NUMBER() > 1
