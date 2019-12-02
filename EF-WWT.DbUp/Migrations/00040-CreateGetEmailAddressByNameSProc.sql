CREATE OR ALTER PROCEDURE dbo.GetEmailAddressByName
	@FirstName varchar(50)
	,@LastName varchar(50)
AS
BEGIN
	SELECT 
		P.BusinessEntityId as BusinessEntityID
		,P.FirstName as FirstName
		,P.LastName as LastName
		,EA.EmailAddress as EmailAddress
	FROM Person.EmailAddress EA
		INNER JOIN Person.Person P ON P.BusinessEntityID = EA.BusinessEntityID
	WHERE P.FirstName = @FirstName
		AND P.LastName = @LastName
END
