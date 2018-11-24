CREATE OR ALTER PROCEDURE CIS560.GetRestaurant
   @RestaurantID INT
AS

SELECT R.Name, R.AddressID
FROM CIS560.Restaurant R
WHERE R.RestaurantID = @RestaurantID;
GO
