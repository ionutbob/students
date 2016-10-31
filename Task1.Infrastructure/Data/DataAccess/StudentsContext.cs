using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.Entities;

namespace Task1.Infrastructure.Data.DataAccess
{
    public class StudentsContext : DbContext
    {
        public StudentsContext()
            : base("DefaultConnection")
        { 
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }
    }
}
