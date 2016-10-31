using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Core.Entities
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
