-- Create the stored procedure in the specified schema
CREATE PROCEDURE DeleteProduct @Id UNIQUEIDENTIFIER
AS
	DELETE
	FROM dbo.Product
	WHERE dbo.Product.Id = @Id
RETURN 0


