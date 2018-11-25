CREATE OR ALTER PROCEDURE CIS560.CreateMenuItem
	@RestaurantID INT,
	@Name NVARCHAR(256),
	@Price MONEY,
	@MenuItemID INT OUTPUT
AS

INSERT CIS560.MenuItem(RestaurantID, Name, Price)
VALUES(@RestaurantID, @Name, @Price);

SET @MenuItemID = SCOPE_IDENTITY();
GO
