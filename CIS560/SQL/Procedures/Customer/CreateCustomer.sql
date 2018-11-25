CREATE OR ALTER PROCEDURE CIS560.CreateCustomer
	@FirstName NVARCHAR(256),
	@LastName NVARCHAR(256),
	@PrimaryAddressID INT,
	@Email NVARCHAR(256),
	@PhoneNumber INT,
	@CustomerID INT OUTPUT
AS

INSERT CIS560.Customer(FirstName, LastName, PrimaryAddressID, Email, PhoneNumber)
VALUES(@FirstName, @LastName, @PrimaryAddressID, @Email, @PhoneNumber);

SET @CustomerID = SCOPE_IDENTITY();
GO
