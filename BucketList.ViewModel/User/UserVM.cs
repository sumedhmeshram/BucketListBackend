using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BucketList.ViewModel.User
{
    public class UserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
