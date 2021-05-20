CREATE PROCEDURE AddOrder
    (@Order AS [dbo].[OrderType] READONLY)
AS
-- Insert rows into table 'TableName'
INSERT INTO dbo.[Order]
    ( -- columns to insert data into
        [Discount], [OrderStatusId]
    )
    SELECT [Discount], [OrderStatusId] FROM @Order
	