CREATE PROCEDURE AddOrderDetail (@OrderDetail AS [dbo].[OrderDetailType] READONLY)
AS
BEGIN
	INSERT INTO dbo.OrderDetail (
		[OrderId]
		,[ProductId]
		,[ProductPrice]
		,[Quantity]
		)
	SELECT [OrderId]
		,[ProductId]
		,[ProductPrice]
		,[Quantity]
	FROM @OrderDetail
END
GO


