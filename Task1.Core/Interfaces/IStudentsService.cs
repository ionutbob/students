using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.Entities;

namespace Task1.Core.Interfaces
{
    public interface IStudentsService
    {
        int GetStudentsCount();
        IEnumerable<Student> Get(int pageSize, int page = 0);

        int GetSearchCount(string searchCriteria);
        IEnumerable<Student> Get(string searchCriteria);

        Student FindById(int id);

        void Delete(int id);

        Course FindCourseById(int id);

        Student UpdateStudent(
            int id,
            string name,
            string surname,
            string gender,
            DateTime DOB,
            string address1,
            string address2,
            string address3);

        Student CreateStudent(
            string name,
            string surname,
            string gender,
            DateTime DOB,
            string address1,
            string address2,
            string address3);
    }
}
