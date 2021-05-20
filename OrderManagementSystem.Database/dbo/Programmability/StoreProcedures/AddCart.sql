CREATE PROCEDURE AddCart 
	(@Cart AS dbo.CartType READONLY)
AS
BEGIN
	INSERT INTO dbo.[Cart] (
		UserId
		)
	SELECT 
		UserId
	FROM @Cart
END
GO


