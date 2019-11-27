using System;
using System.Collections.Generic;

namespace EF_WWT.Data
{
    public partial class ContactType
    {
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
