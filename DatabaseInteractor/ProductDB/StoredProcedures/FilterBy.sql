--CREATE PROCEDURE [dbo].[FilterBy]
--    @Status int = NULL,
--    @CreatedDate datetime = NULL,
--    @UpdatedDate datetime = NULL,
--    @ProductId int = NULL
-- AS
-- SET NOCOUNT ON 
-- SET XACT_ABORT ON  
            
--SELECT [Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]
--FROM [dbo].[Order]

--WHERE ([Status] = @Status OR @Status IS NULL) 
--    AND([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL) 
--    AND([UpdatedDate] = @UpdatedDate OR @UpdatedDate IS NULL) 
--    AND([ProductId] = @ProductId OR @ProductId IS NULL)