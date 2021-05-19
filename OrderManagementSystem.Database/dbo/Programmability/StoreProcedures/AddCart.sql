CREATE PROCEDURE AddCart 
	(@Cart AS dbo.CartType READONLY)
AS
BEGIN
	INSERT INTO dbo.[Cart] (
		UserId
		,ProductId
		,ProductImageUrl
		,ProductName
		,ProductPrice
		,Quantity
		)
	SELECT 
		UserId
		,ProductId
		,ProductImageUrl
		,ProductName
		,ProductPrice
		,Quantity
	FROM @Cart
END
GO


