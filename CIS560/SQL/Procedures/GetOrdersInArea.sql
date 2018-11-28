CREATE OR ALTER PROCEDURE CIS560.GetOrdersInZip
   @Zip INT
AS

SELECT O.CustomerID, O.DriverID, O.AddressID, O.CreatedOn
FROM CIS560.[Order] O
	INNER JOIN CIS560.[Address] A ON A.AddressID = O.AddressID
		AND A.Zip = @Zip
GO


CREATE OR ALTER PROCEDURE CIS560.GetOrdersInState
   @State NVARCHAR(256)
AS

SELECT O.CustomerID, O.DriverID, O.AddressID, O.CreatedOn
FROM CIS560.[Order] O
	INNER JOIN CIS560.[Address] A ON A.AddressID = O.AddressID
		AND A.[State] = @State
GO


CREATE OR ALTER PROCEDURE CIS560.GetOrdersInCity
   @City NVARCHAR(256)
AS

SELECT O.CustomerID, O.DriverID, O.AddressID, O.CreatedOn
FROM CIS560.[Order] O
	INNER JOIN CIS560.[Address] A ON A.AddressID = O.AddressID
		AND A.[City] = @City
GO
