-- Create the stored procedure in the specified schema
CREATE PROCEDURE EditProduct @Id UNIQUEIDENTIFIER
	,@Name NVARCHAR(250)
	,@SKU NCHAR(150)
	,@Origin NVARCHAR(250)
	,@Price DECIMAL(18, 2)
	,@ImageUrl CHAR(500)
AS
UPDATE dbo.Product
SET [Name] = @Name
	,[SKU] = @SKU
	,[Origin] = @Origin
	,[Price] = @Price
	,[ImageUrl] = @ImageUrl
WHERE dbo.Product.Id = @Id
RETURN 0