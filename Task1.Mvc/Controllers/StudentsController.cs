using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Core.Services;
using Task1.Infrastructure.Data;
using Task1.Infrastructure.Data.DataAccess;
using Task1.Mvc.Models;

namespace Task1.Mvc.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index(int page = 1)
        {
            StudentsModel studentsModel = new StudentsModel(new StudentsService(new StudentsRepository(new StudentsContext())), page);

            studentsModel.HandleRequest();

            return View("Students", studentsModel);
        }

        [HttpPost]
        public ActionResult Index(StudentsModel studentsModel)
        {
            studentsModel.StudentsService = new StudentsService(new StudentsRepository(new StudentsContext()));

            studentsModel.HandleRequest();
            ModelState.Clear();

            return View("Students", studentsModel);
        }

        public ActionResult Details(int id)
        {
            StudentsModel studentsModel = new StudentsModel(new StudentsService(new StudentsRepository(new StudentsContext())));
            var studentViewModel = studentsModel.GetStudentById(id);

            return View("StudentDetails", studentViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentsModel studentsModel = new StudentsModel(new StudentsService(new StudentsRepository(new StudentsContext())));
            var studentViewModel = studentsModel.GetStudentById(id);

            return View("EditStudent", studentViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentModel)
        {
            StudentsModel studentsModel = new StudentsModel(new StudentsService(new StudentsRepository(new StudentsContext())));

            var updatedStudent = studentsModel.UpdateStudent(studentModel);

            return View("StudentDetails", updatedStudent);
        }

        [HttpGet]
        public ActionResult Add()
        {
            StudentsModel studentsModel = new StudentsModel(new StudentsService(new StudentsRepository(new StudentsContext())));

            var newStudent = studentsModel.CreateNewStudent();

            return View("AddStudent", newStudent);
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel studentModel)
        {
            StudentsModel studentsModel = new StudentsModel(new StudentsService(new StudentsRepository(new StudentsContext())));

            var createdStudent = studentsModel.AddStudent(studentModel);

            return View("StudentDetails", createdStudent);
        }
    }
}