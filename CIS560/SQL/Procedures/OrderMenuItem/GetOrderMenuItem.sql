CREATE OR ALTER PROCEDURE CIS560.GetOrderMenuItem
   @OrderID INT,
   @MenuItemID INT
AS

SELECT O.MenuItemQuantity
FROM CIS560.OrderMenuItem O
WHERE O.OrderID = @OrderID AND O.MenuItemID = @MenuItemID
GO
