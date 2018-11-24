CREATE OR ALTER PROCEDURE CIS560.GetDriver
   @DriverID INT
AS

SELECT D.FirstName, D.LastName, D.DriversLicenseNumber
FROM CIS560.Drivers D
WHERE D.DriverID = @DriverID;
GO
