CREATE TYPE [dbo].[CartType] AS TABLE (
	[Id] [uniqueidentifier]
	,[UserId] [uniqueidentifier]
	,[ProductId] [uniqueidentifier]
	,[ProductImageUrl] [varchar](500) NOT NULL
	,[ProductName] [nvarchar](250) NOT NULL
	,[ProductPrice] [decimal](18, 2) NOT NULL
	,[Quantity] [int] NOT NULL
	,[CreatedTime] [datetime] NOT NULL
	,[UpdatedTime] [datetime] NULL
	)
