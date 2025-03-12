using Demo.Core.Helper;
using Demo.DataModel.Data;
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

           
        }


    }
}
