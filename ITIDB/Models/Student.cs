using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITIDB.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        //
        [ForeignKey(nameof(Department))]
        public int? DeptId { get; set; }
        public Department? Department { get; set; }
        //
        
        //
        [ForeignKey(nameof(Super))]
        public int St_super { get; set; }
        public Student Super { get; set; }
        //
        public virtual ICollection<Student> StudentsSupervised { get; set; } = new HashSet<Student>();
        //

    }
}
