using System;
using System.Collections.Generic;

namespace EF_WWT.Data
{
    public partial class Territory
    {
        public Territory()
        {
            StateProvince = new HashSet<StateProvince>();
        }

        public int TerritoryId { get; set; }
        public string TerritoryCode { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<StateProvince> StateProvince { get; set; }
    }
}
