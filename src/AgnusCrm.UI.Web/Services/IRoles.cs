using AgnusCrm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Services
{
    public interface IRoles
    {
        Task UpdateRoles(ApplicationUser appUser, ApplicationUser currentUserLogin);
    }
}
