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
           // ApplicationDbContext actx = new ApplicationDbContext();
        }
        protected override void Seed(ApplicationDbContext context)
        {
            //Random r = new Random();
            PasswordHasher ps = new PasswordHasher();

            var manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(c => c.Name,
                new IdentityRole { Name = "Admin" }
                );
            context.Roles.AddOrUpdate(c => c.Name,
               new IdentityRole { Name = "Student" }
               );
            context.Roles.AddOrUpdate(c => c.Name,
               new IdentityRole { Name = "Lecturer" }
               );

            context.Users.AddOrUpdate(a => new { a.FirstName, a.SecondName },
               new ApplicationUser[] {
                   new ApplicationUser
                    {
                        UserName = "powell.paul@itsligo.ie",
                        Email = "powell.paul@itsligo.ie",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed = true,
                        FirstName = "Paul",
                        SecondName = "Powell",
                        PasswordHash = ps.HashPassword("Ppowell$1")
                    }
               });
            context.SaveChanges();

            // Assign Roles
            ApplicationUser ChosenAdmin = manager.FindByEmail("powell.paul@itsligo.ie");
            if (ChosenAdmin != null)
            {
                manager.AddToRoles(ChosenAdmin.Id, new string[] { "Admin" });
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}