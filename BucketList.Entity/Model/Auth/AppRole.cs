using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.Entity.Model.Auth
{
     public class AppRole : IdentityRole
    {
        public string Description { get; set; }

    }
}
