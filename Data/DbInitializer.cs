using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bangazon.Data
{
    public static class DbInitializer
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context), null, null, null, null, null);
                var store = new RoleStore<IdentityRole>(context);
                var userstore = new UserStore<ApplicationUser>(context);
                var usermanager = new UserManager<ApplicationUser>(userstore, null, new PasswordHasher<ApplicationUser>(null), null, null, null, null, null, null);

                if (!context.Roles.Any(r => r.Name == "Administrator"))
                {
                    var role = new IdentityRole { Name = "Administrator" };
                    await roleManager.CreateAsync(role);
                }

                if (!context.Roles.Any(r => r.Name == "Member"))
                {
                    var role = new IdentityRole { Name = "Member" };
                    await roleManager.CreateAsync(role);
                }

                // if (!context.ApplicationUser.Any(u => u.FirstName == "admin"))
                // {
                //     //  This method will be called after migrating to the latest version.
                //     var passwordHash = new PasswordHasher<ApplicationUser>(null);
                //     ApplicationUser user = new ApplicationUser {
                //         FirstName = "admin",
                //         LastName = "admin",
                //         StreetAddress = "123 Infinity Way",
                //         UserName = "admin@admin.com",
                //         Email = "admin@admin.com"
                //     };
                //     var result = await usermanager.CreateAsync(user, "Password@123");
                //     // context.Users.Add(user);
                //     // context.SaveChanges();

                //     // var result = await usermanager.AddPasswordAsync(user, "Password@123");
                //     // context.Users.Update(user);
                //     // context.SaveChanges();

                //     if (result.Succeeded)
                //     {
                //         await usermanager.AddToRoleAsync(user, "ADMINISTRATOR");
                //     }


                //     // string password = passwordHash.HashPassword(user, "Password@123");
                //     // user.PasswordHash = password;
                // }

              // Look for any products.
              if (context.ProductType.Any())
              {
                  return;   // DB has been seeded
              }

              var productTypes = new ProductType[]
              {
                  new ProductType { 
                      Label = "Electronics"
                  },
                  new ProductType { 
                      Label = "Appliances"
                  },
                  new ProductType { 
                      Label = "Housewares"
                  },
              };

              foreach (ProductType i in productTypes)
              {
                  context.ProductType.Add(i);
              }
              context.SaveChanges();

                




          }
       }
    }
}