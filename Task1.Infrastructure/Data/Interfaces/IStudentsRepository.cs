using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.Entities;

namespace Task1.Core.Interfaces
{
    public interface IStudentsRepository
    {
        IQueryable<Student> Students { get; }

        IQueryable<Course> Courses { get; }

        void DeleteStudent(Student student);

        int SaveChanges();

        void AddStudent(Student student);
    }
}
