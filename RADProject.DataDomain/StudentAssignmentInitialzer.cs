using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    class StudentAssignmentInitialzer : DropCreateDatabaseIfModelChanges<StudentAssigmentContext>
    {
        public StudentAssignmentInitialzer()
        {

        }
        protected override void Seed(StudentAssigmentContext context)
        {
            Seed_db_Students(context);

            context.Modules.AddOrUpdate(
                new Module
                {
                    
                    Name = "Software Development",
                    Desription = "Programming"

                });
            context.Modules.AddOrUpdate(
                new Module
                {

                    Name = "Games Development",
                    Desription = "Programming"

                });

            context.SaveChanges();
            base.Seed(context);
        }
        private void Seed_db_Students(StudentAssigmentContext context)
        {
            List<Student> students = new List<Student>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "RADProject.DataDomain.StudentList1.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.MissingFieldFound = null;
                    students = csvReader.GetRecords<Student>().ToList();
                    foreach (var item in students)
                    {
                        context.Students.AddOrUpdate(item);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
