use ProductDB

SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [Name], [Description], [Weight], [Height], [Width], [Length]) VALUES (1, N'Prod1', N'Desc1', 3, 3, 5, 5)
INSERT INTO [dbo].[Product] ([Id], [Name], [Description], [Weight], [Height], [Width], [Length]) VALUES (2, N'Prod2', N'Desc2', 2, 2, 2, 2)
INSERT INTO [dbo].[Product] ([Id], [Name], [Description], [Weight], [Height], [Width], [Length]) VALUES (3, N'Prod3', N'', 3, 3, 3, 3)
INSERT INTO [dbo].[Product] ([Id], [Name], [Description], [Weight], [Height], [Width], [Length]) VALUES (4, N'Prod4', N'Desc4', 4, 4, 4, 4)
INSERT INTO [dbo].[Product] ([Id], [Name], [Description], [Weight], [Height], [Width], [Length]) VALUES (5, N'Prod5', N'', 5, 5, 5, 5)
SET IDENTITY_INSERT [dbo].[Product] OFF

SET IDENTITY_INSERT [dbo].[Order] ON
INSERT INTO [dbo].[Order] ([Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]) VALUES (1, 2, N'1998-01-02 00:00:00', N'1998-01-02 00:00:00', 1)
INSERT INTO [dbo].[Order] ([Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]) VALUES (2, 1, N'1998-01-02 00:00:00', N'1998-01-02 00:00:00', 2)
INSERT INTO [dbo].[Order] ([Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]) VALUES (3, 4, N'1998-01-02 00:00:00', N'1998-01-02 00:00:00', 3)
INSERT INTO [dbo].[Order] ([Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]) VALUES (4, 2, N'1998-01-02 00:00:00', N'1998-01-02 00:00:00', 1)
INSERT INTO [dbo].[Order] ([Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]) VALUES (5, 3, N'1998-01-02 00:00:00', N'1998-01-02 00:00:00', 1)
INSERT INTO [dbo].[Order] ([Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]) VALUES (6, 4, N'1998-01-02 00:00:00', N'1998-01-02 00:00:00', 4)
INSERT INTO [dbo].[Order] ([Id], [Status], [CreatedDate], [UpdatedDate], [ProductId]) VALUES (7, 3, N'1998-01-02 00:00:00', N'1998-01-02 00:00:00', 4)
SET IDENTITY_INSERT [dbo].[Order] OFF
