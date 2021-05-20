CREATE PROCEDURE EditOrder
    @Id UNIQUEIDENTIFIER,
    @Order AS [dbo].[OrderType] READONLY
AS
    UPDATE dbo.[Order]
    SET
        [Id] = @Id,
        [DateDelivered] = O.DateDelivered,
        [Discount] = O.Discount,
        [OrderStatusId] = O.OrderStatusId
    FROM @Order AS O
    WHERE dbo.[Order].Id = @Id
    GO
GO