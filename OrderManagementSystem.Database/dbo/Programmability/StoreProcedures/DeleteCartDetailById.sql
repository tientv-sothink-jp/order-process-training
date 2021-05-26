CREATE PROCEDURE [dbo].[DeleteCartDetailById] @Id VARCHAR(MAX) AS
DELETE FROM
	dbo.CartDetail
WHERE
	[dbo].[CartDetail].[Id] IN (
		SELECT
			CAST(value AS UNIQUEIDENTIFIER)
		FROM
			string_split(@Id, ',')
	) RETURN 0