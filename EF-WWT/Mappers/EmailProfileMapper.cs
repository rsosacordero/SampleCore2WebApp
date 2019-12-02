using EF_WWT.Data;
using EF_WWT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_WWT.Mappers
{
    public class EmailProfileMapper : IMapper<List<GetEmailAddressByName>, List<Contact>>
    {
        public List<Contact> MapDestination(List<GetEmailAddressByName> destination)
        {
            var result = new List<Contact>();
            foreach (var item in destination ?? new List<GetEmailAddressByName>())
            {
                var resultItem = result.FirstOrDefault(c => c.Identifier == item.Identifier);
                if (resultItem == null)
                {
                    var newItem = new Contact(item.Identifier, item.FirstName, item.LastName, new List<string>() { item.EmailAddress }, new List<string>());
                    result.Add(newItem);
                }
                else
                {
                    resultItem.EmailAddresses.Add(item.EmailAddress);
                }
            }
            return result;
        }

        public List<GetEmailAddressByName> MapSource(List<Contact> source)
        {
            throw new NotImplementedException();
        }
    }
}
