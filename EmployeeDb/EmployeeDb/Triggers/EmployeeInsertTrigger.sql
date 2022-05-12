CREATE TRIGGER [EmployeeInsertTrigger]
ON Employee
INSTEAD OF INSERT
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO Company ([Name], [AddressId])
		SELECT I.CompanyName, I.AddressId
		FROM INSERTED I

	INSERT INTO Employee ([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
		SELECT I.AddressId, I.PersonId, I.CompanyName, I.Position, I.EmployeeName
		FROM INSERTED I
END
