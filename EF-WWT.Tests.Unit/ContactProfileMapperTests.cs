using EF_WWT.Data;
using EF_WWT.Mappers;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using FluentAssertions;
using System;

namespace EF_WWT.Tests.Unit
{
    public class ContactProfileMapperTests
    {
        private ContactProfileMapper _mapper; 

        public ContactProfileMapperTests()
        {
            _mapper = new ContactProfileMapper(); 
        }

        [Fact]
        public void MapDestination_ValidDataWithMultipleAddressesPerContact_ListMappedToDestination()
        {
            var identifier1 = Guid.NewGuid();
            var identifier2 = Guid.NewGuid();
            var identifier3 = Guid.NewGuid();

            var listData = new List<GetContactByName>() { 
                new GetContactByName(){ Identifier = identifier1, Address ="Address 1", FirstName = "FN1", LastName = "LN" },
                new GetContactByName(){ Identifier = identifier1, Address ="Address 2", FirstName = "FN1", LastName = "LN" },
                new GetContactByName(){ Identifier = identifier2, Address ="Address 543", FirstName = "FN4", LastName = "LN5" },
                new GetContactByName(){ Identifier = identifier3, Address ="Address 400", FirstName = "FN7", LastName = "LN7" },
            };
            var result = _mapper.MapDestination(listData);
            result.Should().HaveCount(3);
            result.Where(c => c.Identifier == identifier1).Should().HaveCount(1);
            result.First(c => c.Identifier == identifier1).Addresses.Should().HaveCount(2);

            result.Where(c => c.Identifier == identifier2).Should().HaveCount(1);
            result.Where(c => c.Identifier == identifier3).Should().HaveCount(1);
        }

        [Fact]
        public void MapDestination_NullData_EmptyListReturned()
        {
            var listData = (List<GetContactByName>)null;
            var result = _mapper.MapDestination(listData);
            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }

        [Fact]
        public void MapDestination_EmptyData_EmptyListReturned()
        {
            var listData = new List<GetContactByName>();
            var result = _mapper.MapDestination(listData);
            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }
    }
}
