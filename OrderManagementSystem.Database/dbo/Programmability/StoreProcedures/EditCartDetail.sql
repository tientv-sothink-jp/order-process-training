CREATE PROCEDURE EditCartDetail
(
	@Id as UNIQUEIDENTIFIER
	,@CartDetail as [dbo].[CartDetailType] READONLY
)
AS
BEGIN
	UPDATE dbo.CartDetail
	SET 
	CartId = C.CartId,
	ProductId = C.ProductId,
	ProductPrice = C.ProductPrice,
	Quantity = C.Quantity,
	UpdatedTime = GETDATE()
	FROM @CartDetail as C
	WHERE dbo.CartDetail.Id = @Id
END
GO