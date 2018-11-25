CREATE OR ALTER PROCEDURE CIS560.CreateOrder
	@CustomerID INT,
	@DriverID INT,
	@AddressID INT,
	@OrderID INT OUTPUT
AS

INSERT CIS560.[Order](CustomerID, DriverID, AddressID)
VALUES(@CustomerID, @DriverID, @AddressID);

SET @OrderID = SCOPE_IDENTITY();
GO
