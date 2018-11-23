CREATE TABLE CIS560.Address
(
	AddressID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Line1 nvarchar(256) NOT NULL,
	Line2 nvarchar(256) NOT NULL,
	City nvarchar(256) NOT NULL,
	State nvarchar(256) NOT NULL,
	Zip int NOT NULL,

	UNIQUE(Line1, Line2, Zip)
);

CREATE TABLE CIS560.Customers
(
	CustomerID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(256) NOT NULL,
	LastName nvarchar(256) NOT NULL,
	PrimaryAddressID int NOT NULL,
	Email nvarchar(256) NOT NULL,
	PhoneNumber int NOT NULL,

	UNIQUE(Email),

	CONSTRAINT FK_CIS560_Primary_Address_ID FOREIGN KEY(PrimaryAddressID)
	REFERENCES CIS560.Address(AddressID)
);

CREATE TABLE CIS560.Restaurant
(
	RestaurantID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(256) NOT NULL,
	AddressID int NOT NULL,

	CONSTRAINT FK_CIS560_Address_id FOREIGN KEY(AddressID)
	REFERENCES CIS560.Address(AddressID)
);

CREATE TABLE CIS560.MenuItem
(
	MenuItemID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	RestaurantID int NOT NULL,
	Name nvarchar(256) NOT NULL,
	Price money NOT NULL,

	UNIQUE(RestaurantID, Name, Price),

	CONSTRAINT FK_CIS560_RestaurantID FOREIGN KEY (RestaurantID)
	REFERENCES CIS560.Restaurant(RestaurantID)
);

CREATE TABLE CIS560.Drivers
(
	DriverID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(256) NOT NULL,
	LastName nvarchar(256) NOT NULL,
	DriversLicenseNumber nvarchar(256) NOT NULL
);

CREATE TABLE CIS560.[Order]
(
	OrderID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	CustomerID int NOT NULL,
	DriverID int NOT NULL,
	AddressID int NOT NULL,
	CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())

	CONSTRAINT FK_CIS560_CustomerID FOREIGN KEY (CustomerID)
	REFERENCES CIS560.Customers(CustomerID),

	CONSTRAINT FK_CIS560_DriverID FOREIGN KEY (DriverID)
	REFERENCES CIS560.Drivers(DriverID),

	CONSTRAINT FK_CIS560_AddressID FOREIGN KEY (AddressID)
	REFERENCES CIS560.Address(AddressID)
);

CREATE TABLE CIS560.OrderMenuItem
(
	OrderID int NOT NULL,
	MenuItemID int NOT NULL,
	MenuItemQuantity int NOT NULL,

	CONSTRAINT FK_CIS560_OrderID FOREIGN KEY (OrderID)
	REFERENCES CIS560.[Order] (OrderID),

	CONSTRAINT FK_CIS560_MenuItemID FOREIGN KEY (MenuItemID)
	REFERENCES CIS560.MenuItem(MenuItemID),

	CONSTRAINT PK_OrderID_MenuItemID PRIMARY KEY (OrderID, MenuItemID)
);