CREATE PROCEDURE AddOrder (@Order AS [dbo].[OrderType] READONLY)
AS
INSERT INTO dbo.[Order] (
	[Discount]
	,[OrderStatusId]
	)
OUTPUT inserted.Id
SELECT [Discount]
	,[OrderStatusId]
FROM @Order
