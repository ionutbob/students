using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.Entities;
using Task1.Infrastructure.Data;
using Task1.Infrastructure.Data.DataAccess;

namespace Task1.Tests
{
    [TestFixture]
    public class StudentsRepositoryTests
    {
        [Test]
        public void AddStudent_calls_StudentsContext_Add_and_StudentContext_SaveChanges()
        {
            var contextMock = new Mock<StudentsContext>();
            var studentsSetMock = new Mock<DbSet<Student>>();
            contextMock.Setup(c => c.Students).Returns(studentsSetMock.Object);

            var studentsRepository = new StudentsRepository(contextMock.Object);
            Student newStudent = new Student();
            studentsRepository.AddStudent(newStudent);

            studentsSetMock.Verify(ss => ss.Add(newStudent), Times.Once());
        }
    }
}
