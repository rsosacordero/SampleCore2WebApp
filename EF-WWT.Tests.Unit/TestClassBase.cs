using EF_WWT.Data;
using Microsoft.EntityFrameworkCore;

namespace EF_WWT.Tests.Unit
{
    public class TestClassBase
    {
        protected EFWWTContext _context; 
        public TestClassBase()
        {
            //Copy data from our local database
            var sourceOptions = new DbContextOptionsBuilder<EFWWTContext>();
            sourceOptions.UseSqlServer("Server=localhost;Database=EFWWT;Integrated Security=True;Pooling=False");
            var sourceContext = new EFWWTContext(sourceOptions.Options); 

            //Create In-Memory database
            var options = new DbContextOptionsBuilder<EFWWTContext>();
            options.UseInMemoryDatabase("mydb");
            
            _context = new EFWWTContext(options.Options);

            _context.PhoneNumberType.AddRange(sourceContext.PhoneNumberType);
            _context.AddressType.AddRange(sourceContext.AddressType);
            _context.StateProvince.AddRange(sourceContext.StateProvince);
            _context.Territory.AddRange(sourceContext.Territory);

            _context.CountryRegion.AddRange(sourceContext.CountryRegion);
            _context.ContactType.AddRange(sourceContext.ContactType);
            _context.BusinessEntity.AddRange(sourceContext.BusinessEntity);
            _context.BusinessEntityAddress.AddRange(sourceContext.BusinessEntityAddress);
            _context.BusinessEntityContact.AddRange(sourceContext.BusinessEntityContact);

            _context.Person.AddRange(sourceContext.Person);
            _context.PersonPhone.AddRange(sourceContext.PersonPhone);
            _context.EmailAddress.AddRange(sourceContext.EmailAddress);
            _context.Password.AddRange(sourceContext.Password);
            _context.Address.AddRange(sourceContext.Address);

            sourceContext.Dispose();

            _context.SaveChanges(); 
        }
    }
}
