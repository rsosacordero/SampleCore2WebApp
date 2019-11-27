using System;
using System.Collections.Generic;

namespace EF_WWT.Data
{
    public partial class PhoneNumberType
    {
        public int PhoneNumberTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
