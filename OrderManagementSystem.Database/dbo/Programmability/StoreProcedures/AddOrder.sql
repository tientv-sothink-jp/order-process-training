CREATE PROCEDURE AddOrder @DateDelivered DATETIME
	,@Discount DECIMAL(18, 2)
	,@OrderStatusId INT
	,@CustomerName NVARCHAR(250)
	,@CustomerPhone CHAR(15)
	,@CustomerEmail CHAR(150)
	,@CustomerAddress NVARCHAR(250)
AS
INSERT INTO dbo.[Order] (
	[DateDelivered]
	,[Discount]
	,[OrderStatusId]
	,[CustomerName]
	,[CustomerPhone]
	,[CustomerEmail]
	,[CustomerAddress]
	)
VALUES (
	@DateDelivered
	,@Discount
	,@OrderStatusId
	,@CustomerName
	,@CustomerPhone
	,@CustomerEmail
	,@CustomerAddress
	)
RETURN 0


