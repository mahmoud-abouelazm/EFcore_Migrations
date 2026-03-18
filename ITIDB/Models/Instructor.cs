using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace ITIDB.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public decimal Salary { get; set; }

        //
        [ForeignKey(nameof(Department))]
        public int deptId { get; set; }
        public virtual Department? Department { get; set; }
        //
        public virtual ICollection<Department>DepartmentsManaged { get; set; }

        //
        public virtual ICollection<Ins_Course> Ins_Courses { get; set; }
        //
    }
}
