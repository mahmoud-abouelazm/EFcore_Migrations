using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITIDB.Models
{
    public class Course
    {
        [Key]
        public int Crs_id { get; set; }

        public string Crs_Name { get; set; }
        public DateTime Duration { get; set; }
        
        //-------------------
        [ForeignKey(nameof(Topic))]
        public int Top_id { get; set; }
        public Topic Topic { get; set; }
        //-------------------


        //-------------------
        public ICollection<Std_Course> Std_Courses { get; set; } = new HashSet<Std_Course>();
        //-------------------


        //-------------------
        public ICollection<Ins_Course>Ins_Courses { get; set; }
        //-------------------



    }
}
