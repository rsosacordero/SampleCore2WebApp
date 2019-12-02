using System;
using System.Collections.Generic;

namespace EF_WWT.Domain
{
    public class Contact
    {
        public Contact(Guid identifier, string firstName, string lastName, List<string> emailAddresses, List<string> addresses)
        {
            Identifier = identifier;
            FirstName = firstName;
            LastName = lastName;
            EmailAddresses = emailAddresses;
            Addresses = addresses;
        }

        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> EmailAddresses { get; set; }
        public List<string> Addresses { get; set; }
    }
}
