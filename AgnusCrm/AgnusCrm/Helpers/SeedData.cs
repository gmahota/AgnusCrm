using AgnusCrm.Data;
using AgnusCrm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgnusCrm.Helpers
{
    public class SeedData
    {
        //public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        //{
        //    using (var context = new ApplicationDbContext(
        //        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        //    {
        //        // For sample purposes seed both with the same password.
        //        // Password is set with the following:
        //        // dotnet user-secrets set SeedUserPW <pw>
        //        // The admin user can do anything

        //        //var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@contoso.com");
        //        //await EnsureRole(serviceProvider, adminID, Constants.ContactAdministratorsRole);

        //        ////// allowed user can create and edit contacts that they create
        //        //var managerID = await EnsureUser(serviceProvider, testUserPw, "guimaraesmahota@gmail.com");
        //        //await EnsureRole(serviceProvider, managerID, Constants.ContactManagersRole);

        //        //SeedDB(context, adminID);
        //    }
        //}

        //private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
        //                                            string testUserPw, string UserName)
        //{
        //    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

        //    var user = await userManager.FindByNameAsync(UserName);
        //    if (user == null)
        //    {
        //        user = new IdentityUser { UserName = UserName };
        //        await userManager.CreateAsync(user, testUserPw);
        //    }

        //    return user.Id;
        //}

        //private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
        //                                                              string uid, string role)
        //{
        //    IdentityResult IR = null;
        //    var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

        //    if (roleManager == null)
        //    {
        //        throw new Exception("roleManager null");
        //    }

        //    if (!await roleManager.RoleExistsAsync(role))
        //    {
        //        IR = await roleManager.CreateAsync(new IdentityRole(role));
        //    }

        //    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

        //    var user = await userManager.FindByIdAsync(uid);

        //    IR = await userManager.AddToRoleAsync(user, role);

        //    return IR;
        //}

        //public static void SeedDB(ApplicationDbContext context, string adminID)
        //{
        //    if (context.Contact.Any())
        //    {
        //        return;   // DB has been seeded
        //    }

        //    context.Contact.AddRange(
        //        new Contact
        //        {
        //            firstName = "Guimarães",
        //            lastName = "Mahota",
        //            email = "debra@example.com",
        //            Status = ContactStatus.Approved,
        //            userId = adminID
        //        }
        //    );
        //}
    }
}
