CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL IDENTITY(0,1) PRIMARY KEY, 
    [AddressId] INT NULL, 
    [PersonId] INT NULL, 
    [CompanyName] NVARCHAR(20) NULL, 
    [Position] NVARCHAR(30) NULL, 
    [EmployeeName] NVARCHAR(100) NULL,
    CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id]),
    CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])

)
