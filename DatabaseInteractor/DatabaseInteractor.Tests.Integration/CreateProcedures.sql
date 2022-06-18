use [ProductDB]

IF NOT EXISTS (SELECT * 
FROM sys.objects
WHERE object_id = object_id('FilterBy'))
BEGIN
EXEC('
CREATE PROCEDURE [dbo].[FilterBy]
(
    @Status int = -1,
    @CreatedDate datetime = NULL,
    @UpdatedDate datetime = NULL,
    @ProductId int = -1
)
 AS

SELECT [Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]
FROM [dbo].[Order]

WHERE ([Status] = @Status OR @Status = -1) 
    AND([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL) 
    AND([UpdatedDate] = @UpdatedDate OR @UpdatedDate IS NULL) 
    AND([ProductId] = @ProductId OR @ProductId = -1)')
    END
