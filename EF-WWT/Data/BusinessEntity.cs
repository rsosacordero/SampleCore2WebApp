using System;
using System.Collections.Generic;

namespace EF_WWT.Data
{
    public partial class BusinessEntity
    {
        public int BusinessEntityId { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
