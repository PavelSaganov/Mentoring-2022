CREATE TRIGGER [EmployeeInsertTrigger]
ON Employee
FOR INSERT
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO Company ([Name], [AddressId]) VALUES (0, N'Lakeman Associates', 1)
		SELECT I.CompanyName, I.AddressId
		FROM INSERTED I
END
