using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgnusCrm.Web.Helpers
{
    public static class IdentityHelper
    {
        public static int CurrentUserID(this ClaimsPrincipal claim)
        {
            var userID = claim.Claims.ToList().Find(r => r.Type == "UserID").Value;
            return Convert.ToInt32(userID);
        }

        public static string CurrentUserRole(this ClaimsPrincipal claim)
        {
            var role = claim.Claims.ToList().Find(r => r.Type == "Role").Value;
            return role;
        }
    }
}
