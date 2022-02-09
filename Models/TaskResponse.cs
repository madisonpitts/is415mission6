﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission6.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }
        
        public int CategoryID { get; set; }
        public Category CategoryName { get; set; }


    }
}
