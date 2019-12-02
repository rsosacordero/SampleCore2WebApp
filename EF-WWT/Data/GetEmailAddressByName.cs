using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_WWT.Data
{
    public class GetEmailAddressByName
    {
        public int BusinessEntityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
