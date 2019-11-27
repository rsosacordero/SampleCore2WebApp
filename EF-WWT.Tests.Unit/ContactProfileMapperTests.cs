using EF_WWT.Data;
using EF_WWT.Mappers;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using FluentAssertions;

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
            var listData = new List<GetContactByName>() { 
                new GetContactByName(){ BusinessEntityID = 21, Address ="Address 1", FirstName = "FN1", LastName = "LN" },
                new GetContactByName(){ BusinessEntityID = 21, Address ="Address 2", FirstName = "FN1", LastName = "LN" },
                new GetContactByName(){ BusinessEntityID = 361, Address ="Address 543", FirstName = "FN4", LastName = "LN5" },
                new GetContactByName(){ BusinessEntityID = 57, Address ="Address 400", FirstName = "FN7", LastName = "LN7" },
            };
            var result = _mapper.MapDestination(listData);
            result.Should().HaveCount(3);
            result.Where(c => c.Id == 21).Should().HaveCount(1);
            result.First(c => c.Id == 21).Addresses.Should().HaveCount(2);

            result.Where(c => c.Id == 361).Should().HaveCount(1);
            result.Where(c => c.Id == 57).Should().HaveCount(1);
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
