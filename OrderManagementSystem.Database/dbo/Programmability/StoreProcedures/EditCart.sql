CREATE PROCEDURE EditCart (
	@Id AS UNIQUEIDENTIFIER,
	@Cart AS dbo.CartType READONLY
)
AS
BEGIN
	UPDATE dbo.Cart 
	SET 
		UserId = C.UserId
		,ProductId = c.ProductId
		,ProductImageUrl  = C.ProductImageUrl 
		,ProductName = C.ProductName
		,ProductPrice = C.ProductPrice
		,Quantity = C.Quantity
		,UpdatedTime = GETDATE()
    FROM @Cart AS C
	WHERE dbo.Cart.Id = @Id
END
GO