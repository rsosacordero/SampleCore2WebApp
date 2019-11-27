using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_WWT.Migrations
{
    public partial class GetContactByNamev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE [dbo].[GetContactByName] 
	                    @FirstName nvarchar(50),
	                    @LastName nvarchar(50)
                    AS
                    BEGIN	
	                    SELECT  
		                    BE.BusinessEntityID, 
		                    FirstName as FirstName,
		                    LastName as LastName,
		                    CONCAT(AddressLine1, ', ', City, ' ', PostalCode) as Address
	                    FROM [Person].[BusinessEntity] as BE 
	                    inner join [Person].[BusinessEntityAddress] as BEA on BEA.BusinessEntityID = BE.BusinessEntityID 
	                    inner join [Person].[Address] as A on A.AddressID = BEA.AddressID
	                    inner join [Person].[Person] as P on P.BusinessEntityID = BE.BusinessEntityID
	                    WHERE P.FirstName = @FirstName 
		                    AND P.LastName = @LastName
                    END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
