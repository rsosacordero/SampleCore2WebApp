USE [EFWWT]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[GetContactByName]  
	                    @FirstName nvarchar(50),
	                    @LastName nvarchar(50)
                    AS
					BEGIN
		SELECT BE.BusinessEntityID, 
               FirstName AS FirstName, 
               LastName AS LastName, 
               CONCAT(AddressLine1, ', ', City, ', ', SP.Name, ' ', PostalCode) AS Address
        FROM [Person].[BusinessEntity] AS BE
             INNER JOIN [Person].[BusinessEntityAddress] AS BEA ON BEA.BusinessEntityID = BE.BusinessEntityID
             INNER JOIN [Person].[Address] AS A ON A.AddressID = BEA.AddressID
             INNER JOIN [Person].[StateProvince] AS SP ON SP.StateProvinceID = A.StateProvinceID
             INNER JOIN [Person].[Person] AS P ON P.BusinessEntityID = BE.BusinessEntityID
        WHERE P.FirstName = @FirstName
              AND P.LastName = @LastName
END