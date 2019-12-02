using EF_WWT.Data;
using EF_WWT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_WWT.Mappers
{
    public class ContactProfileMapper : IMapper<List<GetContactByName>, List<Contact>>
    {
        public List<Contact> MapDestination(List<GetContactByName> destination)
        {
            var result = new List<Contact>(); 
            foreach (var item in destination ?? new List<GetContactByName>())
            {
                var resultItem = result.FirstOrDefault(c => c.Id == item.BusinessEntityID);
                if (resultItem == null)
                {
                    var newItem = new Contact(item.BusinessEntityID, item.FirstName, item.LastName, new List<string> (), new List<string>() { item.Address });
                    result.Add(newItem);
                }
                else
                {
                    resultItem.Addresses.Add(item.Address);
                }
            }
            return result; 
        }

        public List<GetContactByName> MapSource(List<Contact> source)
        {
            throw new NotImplementedException();
        }
    }
}
