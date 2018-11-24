CREATE OR ALTER PROCEDURE CIS560.GetCustomer
   @CustomerID INT
AS

SELECT C.FirstName, C.LastName, C.PrimaryAddressID, C.Email, C.PhoneNumber
FROM CIS560.Customer C
WHERE C.CustomerID = @CustomerID;
GO
