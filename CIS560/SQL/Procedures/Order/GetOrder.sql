CREATE OR ALTER PROCEDURE CIS560.GetOrder
   @OrderID INT
AS

SELECT O.CustomerID, O.DriverID, O.AddressID, O.CreatedOn
FROM CIS560.Order O
WHERE O.OrderID = @OrderID;
GO
