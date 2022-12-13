using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3.DataAccessTests.UnitTests.ProfesorQueryModel
{
    public class ProfessorQueryRepositoryTest
    {
        private readonly Mock<IProfessorQueryRepository> _sup;

        public ProfessorQueryRepositoryTest()
        {
            _sup = new Mock<IProfessorQueryRepository>();
        }

        [Fact]
        public void Should_Get_All_Professors()
        {
            var professors = MyProfessorssList();
            _sup.Setup(x => x.GetAllStudents()).Returns(professors);
            var professors2 = _sup.Object.GetAllStudents();
            Assert.Equal(professors.Count, professors2.Count);
            
        }

        [Fact]
        public void Should_Get_All_Professors_With_Searching()
        {
            List<ProfessorQueryModel> professors = MyProfessorssList().Where(x=>x.Name == "Sneza").ToList();
            _sup.Setup(x => x.Search("Sneza")).Returns(professors);
            var professors2 = _sup.Object.Search("Sneza");
            Assert.Equal(professors.Count, professors2.Count);

        }

        public List<ProfessorQueryModel> MyProfessorssList()
        {
            List<ProfessorQueryModel> list = new List<ProfessorQueryModel>();
            ProfessorQueryModel professor = new ProfessorQueryModel();
            professor.Id = 200;
            professor.Name = "Sneza";
            professor.Lastname = "Snezic";
            professor.BornDate = new DateTime(1999,7,10);
            professor.Address = "bg";
            list.Add(professor);
            return list;
        }


    }
}
