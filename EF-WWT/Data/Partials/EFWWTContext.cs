using Microsoft.EntityFrameworkCore;

namespace EF_WWT.Data
{
    public partial class EFWWTContext
    {
        public virtual DbQuery<GetContactByName> GetContactByName { get; set; }
        public virtual DbQuery<GetEmailAddressByName> GetEmailAddressByName { get; set; }
    }
}
