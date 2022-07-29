--Use Northwind database. All questions are based on assumptions described by the Database Diagram sent to you yesterday. When inserting, make up info if necessary. Write query for each step. Do not use IDE. BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.
--1.Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.
CREATE VIEW view_product_order_Zhu
AS
SELECT p.ProductName, SUM(od.Quantity) TotalOrderedQuantity
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY P.ProductName

--SELECT * FROM view_product_order_Zhu

--2.Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and total quantities of order as output parameter.
CREATE PROC sp_product_order_quantity_Zhu
@ProductID INT,
@TotalOrderedQuantity INT OUT
AS
SELECT @TotalOrderedQuantity = SUM(od.Quantity)
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
WHERE P.ProductID = @ProductID

DECLARE @TotalOrderedQuantity INT 
EXEC sp_product_order_quantity_Zhu 2, @TotalOrderedQuantity OUT
SELECT @TotalOrderedQuantity TotalQty

--DROP PROCEDURE dbo.sp_product_order_quantity_Zhu

--3.Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input 
--and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.
CREATE PROC sp_product_order_city_Zhu
@ProductName varchar(20),
@City varchar(20) OUT,
@TotalOrderedQty INT OUT
AS
SELECT TOP 5 o.ShipCity, SUM(od.Quantity)
FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p on p.ProductID = od.ProductID
WHERE p.ProductName = @ProductName 
GROUP BY o.ShipCity, p.ProductName
ORDER BY SUM(od.Quantity) DESC

DECLARE @City varchar(20), @TotalOrderedQty INT
EXEC sp_product_order_city_Zhu [Alice Mutton], @City OUT, @TotalOrderedQty OUT

--4.Create 2 new tables “people_your_last_name” “city_your_last_name”. 
--City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
CREATE TABLE people_Zhu
(Id INT, Name VARCHAR(20), City INT)
INSERT INTO people_Zhu VALUES(1, 'Aaron Rodgers', 2)
INSERT INTO people_Zhu VALUES(2, 'Russell Wilson', 1)
INSERT INTO people_Zhu VALUES(3, 'Jody Nelson', 2)

CREATE TABLE city_Zhu
(Id INT, City VARCHAR(20))
INSERT INTO city_Zhu VALUES(1, 'Seattle')
INSERT INTO city_Zhu VALUES(2, 'Green Bay')

--Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. 
IF EXISTS (SELECT p.Id FROM people_Zhu p WHERE p.City IN (SELECT c.Id FROM city_Zhu c WHERE c.City = 'Seattle'))
UPDATE city_Zhu
SET City = 'Madison' 
WHERE City = 'Seattle'

--Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. 
CREATE VIEW Packers_Chris_Zhu
AS 
SELECT p.Name 
FROM people_Zhu p
WHERE p.City = (SELECT c.Id FROM city_Zhu c WHERE c.City = 'Green Bay') 

--SELECT * FROM Packers_Chris_Zhu

--(after test) Drop both tables and view.
DROP TABLE people_Zhu 
DROP TABLE city_Zhu
DROP VIEW Packers_Chris_Zhu

--5.Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.
CREATE PROC sp_birthday_employees_Zhu
AS
SELECT LastName, FirstName, BirthDate
FROM Employees 
WHERE MONTH(BirthDate) = 2
--EXEC sp_birthday_employees_Zhu
DROP PROCEDURE dbo.sp_birthday_employees_Zhu

--6.How do you make sure two tables have the same data?
--There are two tables Table_A and Table_B, first we should remove the duplicates from Table_A and Table_B by using DISTINCT, then we use Union to JOIN these two tables. IF count(row_result_set) from the result set equals to count(row_TableA) + count(row_TableB), it means there is no same data in these two tables. If not, it means there is same data in there two tables. 

