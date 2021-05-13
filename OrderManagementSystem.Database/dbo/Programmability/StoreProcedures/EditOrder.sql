CREATE PROCEDURE EditOrder
    @Id UNIQUEIDENTIFIER,
    @DateDelivered DATETIME,
    @Discount DECIMAL(18,2),
    @OrderStatusId INT,
    @CustomerName NVARCHAR(250),
    @CustomerPhone CHAR(15),
    @CustomerEmail CHAR(150),
    @CustomerAddress NVARCHAR(250)
AS

UPDATE dbo.[Order]
SET
    [Id] = @Id,
    [DateDelivered] = @DateDelivered,
    [Discount] = @Discount,
    [OrderStatusId] = @OrderStatusId,
    [CustomerName] = @CustomerName,
    [CustomerPhone]= @CustomerPhone,
    [CustomerEmail] =@CustomerEmail,
    [CustomerAddress]= @CustomerAddress
WHERE dbo.[Order].Id = @Id
RETURN 0