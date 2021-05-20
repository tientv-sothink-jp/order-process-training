CREATE PROCEDURE AddCartDetail 
    (@CartDetail AS [dbo].[CartDetailType] READONLY)
AS
BEGIN
    INSERT INTO dbo.[CartDetail] ([CartId], [ProductId], [ProductPrice], [Quantity])
    SELECT [CartId], [ProductId], [ProductPrice], [Quantity] FROM @CartDetail
END
GO