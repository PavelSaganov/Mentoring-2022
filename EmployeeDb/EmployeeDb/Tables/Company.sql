CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL IDENTITY(0,1) PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [AddressId] INT NULL, 
    CONSTRAINT [FK_Company_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
