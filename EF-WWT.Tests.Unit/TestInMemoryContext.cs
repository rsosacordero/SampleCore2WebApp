using EF_WWT.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EF_WWT.Tests.Unit
{
    public class TestInMemoryContext : IDisposable
    {
        public EFWWTContext Context { get; }
        public TestInMemoryContext()
        {
            ////Create In-Memory database
            var options = new DbContextOptionsBuilder<EFWWTContext>();
            options.UseInMemoryDatabase("mydb");
            Context = new EFWWTContext(options.Options);

            //Copy data from our local database
            var sourceOptions = new DbContextOptionsBuilder<EFWWTContext>();
            sourceOptions.UseSqlServer("Server=localhost;Database=EFWWT;Integrated Security=True;Pooling=False");
            var sourceDataContext = new EFWWTContext(sourceOptions.Options);

            Context.PhoneNumberType.AddRange(sourceDataContext.PhoneNumberType);
            Context.AddressType.AddRange(sourceDataContext.AddressType);
            Context.StateProvince.AddRange(sourceDataContext.StateProvince);
            Context.Territory.AddRange(sourceDataContext.Territory);

            Context.CountryRegion.AddRange(sourceDataContext.CountryRegion);
            Context.ContactType.AddRange(sourceDataContext.ContactType);
            Context.BusinessEntity.AddRange(sourceDataContext.BusinessEntity);
            Context.BusinessEntityAddress.AddRange(sourceDataContext.BusinessEntityAddress);
            Context.BusinessEntityContact.AddRange(sourceDataContext.BusinessEntityContact);

            Context.Person.AddRange(sourceDataContext.Person);
            Context.PersonPhone.AddRange(sourceDataContext.PersonPhone);
            Context.EmailAddress.AddRange(sourceDataContext.EmailAddress);
            Context.Password.AddRange(sourceDataContext.Password);
            Context.Address.AddRange(sourceDataContext.Address);

            sourceDataContext.Dispose();

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
