﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_WWT.Data
{
    public partial class EFWWTContext
    {
        public virtual DbQuery<GetContactByName> GetContactByName { get; set; }
        public virtual DbQuery<GetEmailAddressByName> GetEmailAddressByName { get; set; }
    }
}
