using System;

namespace EF_WWT.Data
{
    public partial class Password
    {
        public int BusinessEntityId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
