using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace RADProjectWebAPI.Models
{
    public class ApplicationContextInitialzer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        public ApplicationContextInitialzer()
        {
            // Will Fire when App starts up for the first time
        }
        protected override void Seed(ApplicationDbContext context)
        {
            Random r = new Random();
            PasswordHasher hasher = new PasswordHasher();

            var manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(c => c.Name,
                new IdentityRole { Name = "Admin" }
                );

            context.SaveChanges();
            base.Seed(context);
        }
    }
}