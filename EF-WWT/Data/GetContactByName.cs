using System;

namespace EF_WWT.Data
{
    public class GetContactByName
    {
        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
