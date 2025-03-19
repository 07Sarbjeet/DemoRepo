using Demo.Core.Helper;
using Demo.DataModel.Data;
using Demo.DataModel.Data.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Concrete
{
    public class SeedUsers
    {
        private static IServiceProvider serviceProvider;

        public static void SeedRolesData(IServiceProvider _serviceProvider)
        {

            serviceProvider = _serviceProvider;
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            string[] roles = new string[]
                {
                    Roles.SuperAdmin.ToString(),
                    Roles.Admin.ToString(),
                    Roles.User.ToString()
                };

            foreach (var role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var newRole = new IdentityRole
                {
                    Name = role,
                    NormalizedName = role.ToUpper(),
                };
                if (!context.Roles.Any(x => x.Name == role))
                {
                    var roleResult = roleStore.CreateAsync(newRole).Result;
                }
            }
            context.SaveChanges();
            var user = new ApplicationUser
            {
                Email = "supportadmin@demo.com",
                NormalizedEmail = "SUPPORTADMIN@DEMO.COM",
                UserName = "supportadmin@demo.com",
                NormalizedUserName = "SUPPORTADMIN@DEMO.COM",
                PhoneNumber = "123456789",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true,
                IsLoggedIn = true,
                SecurityStamp = Guid.NewGuid().ToString("N")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "supportdemo@123");
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(user);

                string[] rolesSuperAdmin = new string[]
                {
                    Roles.SuperAdmin.ToString()

                };
                var res = AssignRoles(serviceProvider, user.Email, rolesSuperAdmin).Result;


                context.SaveChangesAsync();
            }


        }

         public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            using var scope = services.CreateScope();

            UserManager<ApplicationUser> _userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user,roles);

            return result;
        }
    }
}
