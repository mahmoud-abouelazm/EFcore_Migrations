using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITIDB.Models
{
    public class Topic
    {
        [Key]
        public int Top_Id { get; set; }
        public string Name { get; set; }
    }
}
