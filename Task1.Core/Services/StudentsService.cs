using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.Entities;
using Task1.Core.Interfaces;
using Task1.Infrastructure.Data;

namespace Task1.Core.Services
{
    public class StudentsService : IStudentsService
    {
        private IStudentsRepository studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public int GetStudentsCount()
        {
            return this.studentsRepository.Students.Count<Student>();
        }

        public IEnumerable<Student> Get(int pageSize, int page = 1)
        {
            IEnumerable<Student> result;

            if (page > 1)
            {
                result = this.studentsRepository.Students                    
                    .OrderBy<Student, string>(s => s.FirstName)
                    .OrderBy<Student, string>(s => s.Surname)
                    .Skip<Student>((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList<Student>();
            }
            else
            {
                result = this.studentsRepository.Students                    
                    .OrderBy<Student, string>(s => s.FirstName)
                    .OrderBy<Student, string>(s => s.Surname)
                    .Take<Student>(pageSize)
                    .ToList<Student>();
            }
            return result;
        }

        public int GetSearchCount(string searchCriteria)
        {
            return this.Search(searchCriteria).Count<Student>();
        }

        public IEnumerable<Student> Get(string searchCriteria)
        {
            return this.Search(searchCriteria).ToList<Student>();
        }

        private IEnumerable<Student> Search(string searchCriteria)
        {
            return this.studentsRepository.Students
                .Where<Student>(s => s.FirstName.ToLower().Contains(searchCriteria.ToLower()) ||
                    s.Surname.ToLower().Contains(searchCriteria.ToLower()))
                .OrderBy<Student, string>(s => s.FirstName)
                .OrderBy<Student, string>(s => s.Surname);
        }

        public Student FindById(int id)
        {
            return this.studentsRepository.Students.FirstOrDefault<Student>(s => s.Id == id);
        }

        public Course FindCourseById(int id)
        {
            return this.studentsRepository.Courses.FirstOrDefault<Course>(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var student = this.FindById(id);
            if (student != null)
            {
                this.studentsRepository.DeleteStudent(student);
            }
        }

        public Student UpdateStudent(
            int id,
            string name,
            string surname,
            string gender,
            DateTime DOB,
            string address1,
            string address2,
            string address3)
        {
            var student = this.FindById(id);
            if (student != null)
            {
                student.FirstName = name;
                student.Surname = surname;
                student.Gender = gender;
                student.DOB = DOB;
                student.Address1 = address1;
                student.Address2 = address2;
                student.Address3 = address3;

                this.studentsRepository.SaveChanges();
            }
            else
            {
                throw new Exception("The student you are trying to update was not found.");
            }

            return student;
        }

        public Student CreateStudent(
            string name,
            string surname,
            string gender,
            DateTime DOB,
            string address1,
            string address2,
            string address3) 
        {
            var student = new Student
            {
                FirstName = name,
                Surname = surname,
                Gender = gender,
                DOB = DOB,
                Address1 = address1,
                Address2 = address2,
                Address3 = address3
            };

            this.studentsRepository.AddStudent(student);

            return student;
        }
    }
}
