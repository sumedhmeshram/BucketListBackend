using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BucketList.API.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            //var userId = user.Claims?.FirstOrDefault(c => c.Type == "sub")?.Value;
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.Claims?.FirstOrDefault(c => c.Type == "name")?.Value;
        }
    }
}
