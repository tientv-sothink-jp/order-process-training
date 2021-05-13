-- Create the stored procedure 
CREATE PROCEDURE AddProduct @Name NVARCHAR(250)
	,@SKU NCHAR(150)
	,@Origin NVARCHAR(250)
	,@Price DECIMAL(18, 2)
	,@ImageUrl CHAR(500)
AS
INSERT INTO dbo.Product (
	[Name]
	,[SKU]
	,[Origin]
	,[Price]
	,[ImageUrl]
	)
VALUES (
	@Name
	,@SKU
	,@Origin
	,@Price
	,@ImageUrl
	)
RETURN 0


