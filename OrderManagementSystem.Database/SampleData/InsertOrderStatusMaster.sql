DELETE
FROM dbo.OrderStatusMaster

INSERT INTO dbo.OrderStatusMaster (
	[Id]
	,[Name]
	)
VALUES (
	0
	,'cancel'
	)

INSERT INTO dbo.OrderStatusMaster (
	[Id]
	,[Name]
	)
VALUES (
	1
	,'approve'
	)
