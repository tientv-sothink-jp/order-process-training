CREATE PROCEDURE [dbo].[DeleteCartDetailByCartId]
	@CartId UNIQUEIDENTIFIER
AS
	DELETE FROM dbo.CartDetail
    WHERE [CartId] = @CartId
RETURN 0
