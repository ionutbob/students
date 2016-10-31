using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.Entities;
using Task1.Core.Interfaces;
using Task1.Infrastructure.Data.DataAccess;

namespace Task1.Infrastructure.Data
{
    public class StudentsRepository : IStudentsRepository
    {
        private StudentsContext studentsContext;
        public StudentsRepository(StudentsContext context)            
        {
            this.studentsContext = context;
        }

        public IQueryable<Student> Students
        {
            get { return studentsContext.Students; }
        }

        public IQueryable<Course> Courses
        {
            get { return studentsContext.Courses; }
        }

        public void AddStudent(Student student)
        {
            studentsContext.Students.Add(student);
            studentsContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            studentsContext.Students.Remove(student);
            this.studentsContext.SaveChanges();
        }
        public int SaveChanges()
        {
            return studentsContext.SaveChanges();
        }
    }
}
