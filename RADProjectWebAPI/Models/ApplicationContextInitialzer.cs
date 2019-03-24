using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RADProject.DataDomain;
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
                manager.AddToRoles(ChosenAdmin.Id, new string[] { "Admin", "Student", "Lecturer" });
            }

            SeedStudentsApplicationUsers(manager, context);
            SeedLecturersApplicationUsers(manager,context);

            context.SaveChanges();
            base.Seed(context);
        }

        //assigns all students a student role
        private void SeedStudentsApplicationUsers(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            List<Student> students;
            // Create Application Logins for all seeded students 
            StudentAssigmentContext studentAssigmentContext = new StudentAssigmentContext();

            students = studentAssigmentContext.Students.ToList();

            PasswordHasher ps = new PasswordHasher();
            foreach (var student in students)
            {
                context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        Email = student.FirstName+student.SecondName + "@itsligo.ie",
                        UserName = student.FirstName + student.SecondName + "@itsligo.ie",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = ps.HashPassword("Pass123$1")
                    });
                context.SaveChanges();

                ApplicationUser addedUser = manager.FindByEmail(student.FirstName + student.SecondName + "@itsligo.ie");
                if (addedUser != null)
                {
                    manager.AddToRole(addedUser.Id, "Student");
                }
                context.SaveChanges();

            }
            context.SaveChanges();
        }

        //assigns all lecturers a lecturer role
        private void SeedLecturersApplicationUsers(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            List<Lecturer> lecturers;
            // Create Application Logins for all seeded Lecturers 
            StudentAssigmentContext studentAssigmentContext = new StudentAssigmentContext();

            lecturers = studentAssigmentContext.Lecturers.ToList();

            PasswordHasher ps = new PasswordHasher();
            foreach (var lecturer in lecturers)
            {
                context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        Email = lecturer.FirstName + lecturer.SecondName + "@itsligo.ie",
                        UserName = lecturer.FirstName + lecturer.SecondName + "@itsligo.ie",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = ps.HashPassword("Pass123$1")
                    });
                context.SaveChanges();

                ApplicationUser addedUser = manager.FindByEmail(lecturer.FirstName + lecturer.SecondName + "@itsligo.ie");
                if (addedUser != null)
                {
                    manager.AddToRole(addedUser.Id, "Lecturer");
                }
                context.SaveChanges();

            }
            context.SaveChanges();
        }
    }
}