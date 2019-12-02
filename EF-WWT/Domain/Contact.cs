using System.Collections.Generic;

namespace EF_WWT.Domain
{
    public class Contact
    {
        public Contact(int id, string firstName, string lastName, List<string> emailAddresses, List<string> addresses)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddresses = emailAddresses;
            Addresses = addresses;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> EmailAddresses { get; set; }
        public List<string> Addresses { get; set; }
    }
}
