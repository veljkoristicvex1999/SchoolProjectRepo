
using BusinessObjectModel.QueryModels;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3.DataAccessTests.UnitTests.FaculltyQueryModel
{
    public class FaculltyQueryRepositoryTest
    {
        private readonly Mock<IFacultyQueryModelRepository> _sup;

        public FaculltyQueryRepositoryTest()
        {
            _sup = new Mock<IFacultyQueryModelRepository>();
        }

        [Fact]
        public void Should_Get_All_Professors()
        {
            var students = MyStudentsList();
            _sup.Setup(x => x.GetAllStudents()).Returns(students);
            var students2 = _sup.Object.GetAllStudents();
            Assert.Equal(students.Count, students2.Count);

        }

        [Fact]
        public void Should_Get_All_Professors_With_Searching()
        {
            List<FacultyQueryModel> professors = MyStudentsList().Where(x => x.Name == "Sneza").ToList();
            _sup.Setup(x => x.Search("Sneza")).Returns(professors);
            var professors2 = _sup.Object.Search("Sneza");
            Assert.Equal(professors.Count, professors2.Count);

        }

        public List<FacultyQueryModel> MyStudentsList()
        {
            List<FacultyQueryModel> list = new List<FacultyQueryModel>();
            FacultyQueryModel facultyStudent = new FacultyQueryModel();
            facultyStudent.Id = 200;
            facultyStudent.Name = "Sneza";
            facultyStudent.Lastname = "Snezic";
            facultyStudent.BornDate = new DateTime(1999, 7, 10);
            facultyStudent.Address = "bg";
            list.Add(facultyStudent);
            return list;
        }
    }
}
