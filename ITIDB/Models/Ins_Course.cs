using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITIDB.Models
{
    public class Ins_Course
    {
        [ForeignKey(nameof(Course))]
        public int Crs_Id { get; set; }
        [ForeignKey(nameof(Instructor))]
        public int Instructor_Id { get; set; }
        public int Grade { get; set; }

        public Instructor Instructor{ get; set; }
        public Course Course { get; set; }
    }
}
