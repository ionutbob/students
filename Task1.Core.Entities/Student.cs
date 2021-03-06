﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Core.Entities
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName{get; set;}

        [Required]
        [MaxLength(255)]
        public string Surname{get; set;}

        [Required]
        [MaxLength(1)]
        public string Gender{get; set;}
        
        [Required]
        public DateTime DOB{get; set;}

        [Required]
        [MaxLength(255)]
        public string Address1{get; set;}
        
        public string Address2 {get; set;} 
        
        public string Address3 {get; set;}

        public virtual ICollection<Course> Courses { get; set; }
    }
}
