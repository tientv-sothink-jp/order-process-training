CREATE PROCEDURE AddOrder
    @DateDelivered DATETIME,
    @Discount DECIMAL(18,2),
    @OrderStatusId INT,
    @CustomerName NVARCHAR(250),
    @CustomerPhone CHAR(15),
    @CustomerEmail char(150),
    @CustomerAddress NVARCHAR(250)
AS
-- Insert rows into table 'TableName'
INSERT INTO dbo.[Order]
    ( -- columns to insert data into
        [DateDelivered], [Discount], [OrderStatusId], [CustomerName], [CustomerPhone], [CustomerEmail], [CustomerAddress]
    )
VALUES
    ( 
        @DateDelivered, @Discount, @OrderStatusId, @CustomerName, @CustomerPhone, @CustomerEmail, @CustomerAddress
	)
	