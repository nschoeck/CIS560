CREATE OR ALTER PROCEDURE CIS560.GetAddress
   @AddressID INT
AS

SELECT A.Line1, A.Line2, A.City, A.[State], A.Zip
FROM CIS560.[Address] A
WHERE A.AddressID = @AddressID;
GO
