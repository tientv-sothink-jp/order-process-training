CREATE PROCEDURE [dbo].[DeleteCartDetailById]
	@Id VARCHAR(MAX)
AS
	DELETE FROM dbo.CartDetail
    WHERE [dbo].[CartDetail].[Id] IN (SELECT value FROM string_split(@Id, ','))
RETURN 0
