using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Student
    {
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public Guid Id{ get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return $"Name : {Name}\t , DeptName = {Department?.Name ?? "N/A"} , Age : {Age} , salary : {Salary}";
        }
    }
}
