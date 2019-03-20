using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADProject.DataDomain
{
    [Table("LecturerModules")]
    public class LecturerModule
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("associatedLectuer")]
        public int LecturerID { get; set; }

        [ForeignKey("associatedModule")]
        public int ModuleID { get; set; }

        public virtual Lecturer associatedLectuer { get; set; }
        public virtual Module associatedModule { get; set; }
    }
}
