using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task1.Core.Entities;
using Task1.Core.Interfaces;

namespace Task1.Mvc.Models
{
    public class StudentsModel
    {      
        public StudentsModel()
        {           
        }

        public StudentsModel(IStudentsService studentsService, int currentPage=1)
        {
            this.StudentsService = studentsService;
            this.Pager = new Pager(studentsService.GetStudentsCount(), currentPage, 10);
            this.EventCommand = "list";
        }

        public string EventCommand { get; set; }

        public string EventArgument { get; set; }

        public IStudentsService StudentsService { get; set; }

        public string SearchCriteria { get; set; }
        public Pager Pager { get; set; }
        public IEnumerable<StudentViewModel> Students { get; private set; }

        internal void HandleRequest()
        {
            switch (this.EventCommand.ToLower())
            { 
                case "list":
                    this.Students = this.GetStudents();
                    break;
                case "resetsearch":
                    this.Pager = new Pager(this.StudentsService.GetStudentsCount(), 1, 10);
                    this.Students = this.GetStudents();
                    this.SearchCriteria = string.Empty;
                    break;
                case "search":
                    this.Students = this.GetStudents(this.SearchCriteria);                    
                    break;
                case "delete":
                    if (!string.IsNullOrEmpty(this.EventArgument))
                    {
                        this.StudentsService.Delete(Convert.ToInt32(this.EventArgument));
                        this.EventArgument = string.Empty;
                    }
                    if (string.IsNullOrEmpty(this.SearchCriteria))
                    {
                        this.Pager = new Pager(this.StudentsService.GetStudentsCount(), 1, 10);
                        this.Students = this.GetStudents();
                    }
                    else
                    {
                        this.Students = this.GetStudents(this.SearchCriteria); 
                    }
                    break;
            }
        }

        internal StudentViewModel GetStudentById(int id)
        {
            var student = this.StudentsService.FindById(id);

            return MapStudentToViewModel(student);
        }

        public StudentViewModel UpdateStudent(StudentViewModel studentViewModel)
        {
            var updatedStudent = this.StudentsService.UpdateStudent(
                studentViewModel.Id,
               studentViewModel.FirstName,
                studentViewModel.Surname,
                studentViewModel.Gender,
                studentViewModel.DOB,
                studentViewModel.Address1,
                studentViewModel.Address2,
                studentViewModel.Address3);

            return this.MapStudentToViewModel(updatedStudent);
        }

        public object AddStudent(StudentViewModel studentViewModel)
        {
            var createdStudent = this.StudentsService.CreateStudent(
               studentViewModel.FirstName,
                studentViewModel.Surname,
                studentViewModel.Gender,
                studentViewModel.DOB,
                studentViewModel.Address1,
                studentViewModel.Address2,
                studentViewModel.Address3);

            return this.MapStudentToViewModel(createdStudent);
        }

        public StudentViewModel CreateNewStudent()
        {
            return new StudentViewModel();
        }

        public void DeleteStudent(int id)
        {
            this.StudentsService.Delete(id);
        }

        private IEnumerable<StudentViewModel> GetStudents(string searchCriteria)
        {
            return this.StudentsService.Get(searchCriteria)
                .Select<Student, StudentViewModel>(
                s => MapStudentToViewModel(s));
        }

        private IEnumerable<StudentViewModel> GetStudents()
        {
            return this.StudentsService.Get(this.Pager.PageSize, this.Pager.CurrentPage)
                .Select<Student, StudentViewModel>(
                s => MapStudentToViewModel(s));
        }

        private StudentViewModel MapStudentToViewModel(Student student)
        {
            if (student != null)
            {
                return new StudentViewModel
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    Surname = student.Surname,
                    Gender = student.Gender,
                    DOB = student.DOB,
                    Address1 = student.Address1,
                    Address2 = student.Address2,
                    Address3 = student.Address3,
                    Courses = student.Courses.Select<Course, CourseViewModel>(
                    c => MapCourseToViewModel(c)).ToList<CourseViewModel>()
                };
            }

            return null;
        }

        private CourseViewModel MapCourseToViewModel(Course course)
        {
            if (course != null)
            {
                return new CourseViewModel
                {
                    Id = course.Id,
                    Name = course.Name
                };
            }

            return null;
        }        
    }
}