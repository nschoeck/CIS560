CREATE OR ALTER PROCEDURE CIS560.CreateDriver
	@FirstName NVARCHAR(256),
	@LastName NVARCHAR(256),
	@DriversLicenseNumber NVARCHAR(256),
	@DriverID INT OUTPUT
AS

INSERT CIS560.Driver(FirstName, LastName, DriversLicenseNumber)
VALUES(@FirstName, @LastName, @DriversLicenseNumber);

SET @DriverID = SCOPE_IDENTITY();
GO
