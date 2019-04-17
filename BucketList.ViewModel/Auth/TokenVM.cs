using BucketList.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketList.ViewModel.Auth
{
    public class TokenVM
    {
        public UserVM UserInfo { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
