CREATE PROCEDURE EditCartDetail (
	@Id AS UNIQUEIDENTIFIER
	,@CartDetail AS [dbo].[CartDetailType] READONLY
	)
AS
BEGIN
	UPDATE dbo.CartDetail
	SET CartId = C.CartId
		,ProductId = C.ProductId
		,ProductPrice = C.ProductPrice
		,Quantity = C.Quantity
		,UpdatedTime = GETDATE()
	FROM @CartDetail AS C
	WHERE dbo.CartDetail.Id = @Id
END
GO


