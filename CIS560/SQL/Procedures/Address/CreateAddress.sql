CREATE OR ALTER PROCEDURE CIS560.CreateAddress
	@Line1 NVARCHAR(256),
	@Line2 NVARCHAR(256),
	@City NVARCHAR(256),
	@State NVARCHAR(256),
	@Zip int,
	@AddressID INT OUTPUT
AS

INSERT CIS560.Address(Line1, Line2, City, State, Zip)
VALUES(@Line1, @Line2, @City, @State, @Zip);

SET @AddressID = SCOPE_IDENTITY();
GO