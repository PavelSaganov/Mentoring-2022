--TABLE DATA
GO

INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'4', N'2', N'Gomel', N'gg454g2g')
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'Good st.', N'Mozyr', N'1', N'232')
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'Wordsworth Road', N'Amble', N'1', N'12f43g4')
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'St Andrew''s Road', N'Red Bluff', N'2', N'213543231')
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'Nightingale Road', N'Suffolk', N'2', N'gr3t4gr')
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'Windermere Avenue', N'Amesbury', N'2', N'sdasf32')
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'Essex Road', N'Forest Hills', N'1', N'dsfg21')
INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (N'Oak Road', N'NULLNowra-Bomaderry', N'2', N'4543ref')

GO

INSERT INTO [dbo].[Company] ([Name], [AddressId]) VALUES (N'Lakeman Associates', 1)
INSERT INTO [dbo].[Company] ([Name], [AddressId]) VALUES (N'Sparrow And Gump', 2)
INSERT INTO [dbo].[Company] ([Name], [AddressId]) VALUES (N'Lakeman of Ireland', 3)
INSERT INTO [dbo].[Company] ([Name], [AddressId]) VALUES (N'Gump Unlimited', 4)
INSERT INTO [dbo].[Company] ([Name], [AddressId]) VALUES (N'Mail Mail Mail', 5)

GO

INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Eleanor', N'Hernandez')
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Mary', N'Ward')
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Mia', N'Perry')
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Elizabeth', N'Wells')
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Millie', N'Fisher')
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Becca', N'Webb')
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Jess', N'Young')
INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (N'Ella', N'Cox')

GO

INSERT INTO [dbo].[Employee] ([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES (0, 0, N'Lakeman Associates', N'Pos1', N'Eleanor')
INSERT INTO [dbo].[Employee] ([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES (1, 1, N'Sparrow And Gump', N'Pos2', N'Mary')
INSERT INTO [dbo].[Employee] ([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES (2, 2, N'Lakeman of Ireland', N'Pos2', N'Mia')