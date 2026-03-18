using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Department
    {
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Key]
        public int DeptId { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public override string ToString()
        {
            return $"Name : {Name} ";
        }
    }
}
