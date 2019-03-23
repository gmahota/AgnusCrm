using AgnusCrm.Models;
using AgnusCrm.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IAgnusCrmService AgnusCrmService)
        {
            context.Database.EnsureCreated();

            //check for users
            if (context.ApplicationUser.Any())
            {
                return; //if user is not empty, DB has been seed
            }

            //init app with super admin user
            await AgnusCrmService.CreateDefaultSuperAdmin();

            //init crm
            await AgnusCrmService.InitCRM();

        }
    }
}
