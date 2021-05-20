CREATE PROCEDURE EditCart (
	@Id AS UNIQUEIDENTIFIER,
	@Cart AS dbo.CartType READONLY
)
AS
BEGIN
	UPDATE dbo.Cart 
	SET 
		UserId = C.UserId
		,UpdatedTime = GETDATE()
    FROM @Cart AS C
	WHERE dbo.Cart.Id = @Id
END
GO