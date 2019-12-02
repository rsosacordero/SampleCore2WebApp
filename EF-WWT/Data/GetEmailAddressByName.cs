using System;

namespace EF_WWT.Data
{
    public class GetEmailAddressByName
    {
        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
