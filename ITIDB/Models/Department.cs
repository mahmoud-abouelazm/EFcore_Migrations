using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITIDB.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string  Location { get; set; }
        //
        [ForeignKey(nameof(Dept_Manager))]
        public int? Dept_ManagerId { get; set; }
        public virtual Instructor? Dept_Manager { get; set; }
        //

        //
        public ICollection<Student> Students { get; set; }
        public ICollection<Instructor> Instructors{ get; set; }
        //
        public DateTime Manager_hiredate { get; set; }
    }
}
