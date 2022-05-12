GO

INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (0, N'4', N'2', N'Gomel', N'gg454g2g')
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (1, N'Good st.', N'Mozyr', N'1', N'232')
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (2, N'Wordsworth Road', N'Amble', N'1', N'12f43g4')
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (3, N'St Andrew''s Road', N'Red Bluff', N'2', N'213543231')
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (4, N'Nightingale Road', N'Suffolk', N'2', N'gr3t4gr')
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (5, N'Windermere Avenue', N'Amesbury', N'2', N'sdasf32')
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (6, N'Essex Road', N'Forest Hills', N'1', N'dsfg21')
INSERT INTO [dbo].[Address] ([Id], [Street], [City], [State], [ZipCode]) VALUES (7, N'Oak Road', N'NULLNowra-Bomaderry', N'2', N'4543ref')

GO

INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (0, N'Lakeman Associates', 1)
INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (1, N'Sparrow And Gump', 2)
INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (2, N'Lakeman of Ireland', 3)
INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (3, N'Gump Unlimited', 4)
INSERT INTO [dbo].[Company] ([Id], [Name], [AddressId]) VALUES (4, N'Mail Mail Mail', 5)

GO

INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (0, N'Eleanor', N'Hernandez')
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (1, N'Mary', N'Ward')
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (2, N'Mia', N'Perry')
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (3, N'Elizabeth', N'Wells')
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (4, N'Millie', N'Fisher')
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (5, N'Becca', N'Webb')
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (6, N'Jess', N'Young')
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (7, N'Ella', N'Cox')

GO

INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES (1, 0, 0, N'Lakeman Associates', N'Pos1', N'Eleanor')
INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES (2, 1, 1, N'Sparrow And Gump', N'Pos2', N'Mary')
INSERT INTO [dbo].[Employee] ([Id], [AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES (3, 2, 2, N'Lakeman of Ireland', N'Pos2', N'Mia')
