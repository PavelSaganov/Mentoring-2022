CREATE VIEW [dbo].[EmployeeInfo]
	AS SELECT E.Id, E.EmployeeName, 
		CONCAT(P.FirstName, ', ', P.LastName) AS EmployeeFullName,
		CONCAT(A.ZipCode, '_', A.[State], ' ', A.City, '-', A.Street) AS EmployeeFullAddress,
		CONCAT(E.CompanyName, ' (', E.Position, ')') AS EmployeeCompanyInfo
	FROM [Employee] E
	LEFT JOIN [Address] A on E.AddressId = A.Id
	LEFT JOIN [Person] P on E.PersonId = P.Id
