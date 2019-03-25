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
            // Seed_db_Students(context);

            context.Modules.AddOrUpdate(new Module[]
            {
                new Module
                {
                    Name = "Software Development",
                    Desription = "Programming"
                },
                new Module
                {
                    Name = "Games Development",
                    Desription = "Programming"
                }
            });


            context.Students.AddOrUpdate(new Student[]
            {
                new Student
                {
                    StudentID = "S00167749",
                    FirstName = "Arif",
                    SecondName ="Matin"
                },
                new Student
                {
                    StudentID = "S00167750",
                    FirstName = "John",
                    SecondName = "Matin"
                }
            });

            context.Lecturers.AddOrUpdate(new Lecturer[]
                {
                new Lecturer
                {
                    ID = 1,
                    FirstName = "Paul",
                    SecondName = "Diddy"
                },
                new Lecturer
                {

                    FirstName = "John",
                    SecondName = "Jones"
                }
             });

            //Seed_db_Students(context);
            //Seed_db_Assigments(context);
            //Seed_db_AssigmentResults(context);
            //Seed_db_Attendance(context);
            //Seed_db_Modules(context);

            context.SaveChanges();
            base.Seed(context);
        }

        private void Seed_db_Students(StudentAssigmentContext context)
        {
            List<Student> students = new List<Student>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            string resourceName = "RADProject.DataDomain.CSVData.StudentList1.csv";
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
        private void Seed_db_Assigments(StudentAssigmentContext assigmentContext)
        {
            List<Assignment> assigments = new List<Assignment>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "RADProject.DataDomain.CSVData.Assigments.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.MissingFieldFound = null;
                    assigments = csvReader.GetRecords<Assignment>().ToList();
                    foreach (var item in assigments)
                    {
                        assigmentContext.Assignments.AddOrUpdate(item);
                    }
                }
            }
            assigmentContext.SaveChanges();
        }
        private void Seed_db_AssigmentResults(StudentAssigmentContext assigmentresContext)
        {
            List<AssignmentResult> assigmentresults = new List<AssignmentResult>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "RADProject.DataDomain.CSVData.AssigmentResults.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.MissingFieldFound = null;
                    assigmentresults = csvReader.GetRecords<AssignmentResult>().ToList();
                    foreach (var item in assigmentresults)
                    {
                        assigmentresContext.AssignmentResults.AddOrUpdate(item);
                    }
                }
            }
            assigmentresContext.SaveChanges();
        }
        private void Seed_db_Attendance(StudentAssigmentContext attendanceContext)
        {
            List<Attendance> attendances = new List<Attendance>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "RADProject.DataDomain.CSVData.Attendance.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.MissingFieldFound = null;
                    attendances = csvReader.GetRecords<Attendance>().ToList();
                    foreach (var item in attendances)
                    {
                        attendanceContext.Attendances.AddOrUpdate(item);
                    }
                }
            }
            attendanceContext.SaveChanges();
        }
        private void Seed_db_Modules(StudentAssigmentContext Modulescontext)
        {
            List<Module> modules = new List<Module>();
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "RADProject.DataDomain.CSVData.Modules.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.MissingFieldFound = null;
                    modules = csvReader.GetRecords<Module>().ToList();
                    foreach (var item in modules)
                    {
                        Modulescontext.Modules.AddOrUpdate(item);
                    }
                }
            }
            Modulescontext.SaveChanges();
        }

    }
}
