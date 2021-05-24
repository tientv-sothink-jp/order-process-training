﻿CREATE TYPE [dbo].[OrderType] AS TABLE (
	[Id] UNIQUEIDENTIFIER NOT NULL
	,[DateDelivered] DATETIME DEFAULT GETDATE()
	,[Discount] DECIMAL(18, 2) NOT NULL
	,[OrderStatusId] INT NOT NULL
	,[CreatedTime] DATETIME
	,[UpdatedTime] DATETIME
	)
