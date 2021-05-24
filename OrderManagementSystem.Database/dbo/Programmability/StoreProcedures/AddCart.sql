CREATE PROCEDURE AddCart (@Cart AS dbo.CartType READONLY)
AS
BEGIN
	INSERT INTO dbo.[Cart] (UserId)
	OUTPUT inserted.Id
	SELECT UserId
	FROM @Cart
END
GO


