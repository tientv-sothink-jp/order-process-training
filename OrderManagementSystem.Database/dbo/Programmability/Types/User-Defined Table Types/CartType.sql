CREATE TYPE [dbo].[CartType] AS TABLE (
	[Id] [uniqueidentifier]
	,[UserId] [uniqueidentifier]
	,[CreatedTime] [datetime] NOT NULL
	,[UpdatedTime] [datetime] NULL
	)
