using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    class StudentAssignmentInitialzer : DropCreateDatabaseAlways<StudentAssigmentContext>
    {
        public StudentAssignmentInitialzer()
        {

        }
        protected override void Seed(StudentAssigmentContext context)
        {

            
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
