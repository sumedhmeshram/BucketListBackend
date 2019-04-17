using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BucketList.Entity.Model.Auth
{
    public class AppUser : IdentityUser
    {
        public DateTime JoinDate { get; set; }
        public DateTime JobTitle { get; set; }
        public string Contract { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
