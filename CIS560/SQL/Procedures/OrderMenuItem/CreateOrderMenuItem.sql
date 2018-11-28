CREATE OR ALTER PROCEDURE CIS560.CreateOrderMenuItem
	@OrderID INT,
	@MenuItemID INT,
	@MenuItemQuantity INT
AS

INSERT CIS560.OrderMenuItem(OrderID, MenuItemID, MenuItemQuantity)
VALUES(@OrderID, @MenuItemID, @MenuItemQuantity);
GO
