CREATE OR ALTER PROCEDURE CIS560.CreateRestaurant
	@Name NVARCHAR(256),
	@AddressID INT,
	@RestaurantID INT OUTPUT
AS

INSERT CIS560.Restaurant(Name, AddressID)
VALUES(@Name, @AddressID);

SET @RestaurantID = SCOPE_IDENTITY();
GO
