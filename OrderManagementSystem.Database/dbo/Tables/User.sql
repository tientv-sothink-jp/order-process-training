CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(500) NOT NULL,
    [Name] NVARCHAR(500) NOT NULL,
    [Phone] CHAR(15) NOT NULL,
    [Email] CHAR(150) NOT NULL,
    [Address] NVARCHAR(500) NOT NULL,
    [Token] CHAR(250) NULL ,
    [RefreshToken] CHAR(250) NULL ,
    [IsActive] BIT NOT NULL DEFAULT 1 ,
    [CreatedTime] DATETIME NOT NULL DEFAULT GETDATE(), 
    [UpdatedTime] DATETIME NULL,
)
