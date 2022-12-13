using BusinessObjectModel.QueryModels;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3.DataAccessTests.UnitTests.HighSchoolStudentsQueryModel
{
    public class HighSchoolQueryRepositoryTest
    {
        private readonly Mock<IHighSchoolQueryRepository> _sup;

        public HighSchoolQueryRepositoryTest()
        {
            _sup = new Mock<IHighSchoolQueryRepository>();
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
            List<HighSchoolQueryModel> students = MyStudentsList().Where(x => x.Name == "Sneza").ToList();
            _sup.Setup(x => x.Search("Sneza")).Returns(students);
            var students2 = _sup.Object.Search("Sneza");
            Assert.Equal(students.Count, students2.Count);

        }

        public List<HighSchoolQueryModel> MyStudentsList()
        {
            List<HighSchoolQueryModel> list = new List<HighSchoolQueryModel>();
            HighSchoolQueryModel highSchoolStudents = new HighSchoolQueryModel();
            highSchoolStudents.Id = 200;
            highSchoolStudents.Name = "Sneza";
            highSchoolStudents.Lastname = "Snezic";
            highSchoolStudents.BornDate = new DateTime(1999, 7, 10);
            highSchoolStudents.Address = "bg";
            list.Add(highSchoolStudents);
            return list;
        }
    }
}
