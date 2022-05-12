CREATE PROCEDURE [dbo].[InsertEmployee]
	@EmployeeName int = 0,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@CompanyName nvarchar(50),
	@Position nvarchar(50),
	@Street nvarchar(50),
	@City nvarchar(50),
	@State nvarchar(50),
	@ZipCode nvarchar(50)
AS
	DECLARE @NormalizedCompanyName nvarchar(20)
	DECLARE @AddressInsertedId int

	IF ((LTRIM(@FirstName) IS NOT NULL AND RTRIM(@FirstName) IS NOT NULL) OR
		(LTRIM(@LastName) IS NOT NULL AND RTRIM(@LastName) IS NOT NULL) OR
		(LTRIM(@EmployeeName) IS NOT NULL AND RTRIM(@EmployeeName) IS NOT NULL))
	BEGIN
		SET @NormalizedCompanyName = (SUBSTRING(@FirstName, 1, 20))
		INSERT INTO [dbo].[Address] ([Street], [City], [State], [ZipCode]) VALUES (@Street, @City, @State, @ZipCode)
		SET @AddressInsertedId = SCOPE_IDENTITY()
		
		INSERT INTO [dbo].[Company] ([Name], [AddressId]) VALUES (@NormalizedCompanyName, SCOPE_IDENTITY())
		INSERT INTO [dbo].[Person] ([FirstName], [LastName]) VALUES (@FirstName, @LastName)
		INSERT INTO [dbo].[Employee] ([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName]) VALUES (@AddressInsertedId, SCOPE_IDENTITY(), @NormalizedCompanyName, @Position, @EmployeeName)
	END
RETURN 0
