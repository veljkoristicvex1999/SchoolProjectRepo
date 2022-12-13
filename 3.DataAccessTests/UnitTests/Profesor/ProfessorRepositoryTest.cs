
using BusinessObjectModel;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3.DataAccessTests.Profesor
{
    public class ProfessorRepositoryTest
    {
        private readonly Mock<IProfessorRepository> _sup;

        public ProfessorRepositoryTest()
        {
            _sup = new Mock<IProfessorRepository>();
        }

       
        [Fact]
        public void Should_Delete_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sup.Setup(x => x.Delete(student)).Verifiable();
            _sup.Object.Delete(student);
            _sup.Verify(x => x.Delete(It.Is<Professor>(stud => stud.Id == student.Id)));
        }

        [Fact]
        public void Should_Update_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sup.Setup(x => x.Update(student)).Verifiable();
            _sup.Object.Update(student);
            _sup.Verify(x => x.Update(It.Is<Professor>(stud => stud.Id == student.Id)));
        }

        [Fact]
        public void Should_Get_HighSchoolStudent_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sup.Setup(x => x.findByEmail(student.Email)).Returns(student);
            var foundStudent = _sup.Object.findByEmail(student.Email);
            Assert.Equal(foundStudent.Email, student.Email);
        }


        public List<Professor> MyStudentsList()
        {
            List<Professor> list = new List<Professor>();
            Professor professor = new Professor();
            professor.Id = 200;
            professor.Name = "Sneza";
            professor.LastName = "Snezic";
            professor.HoursPerWeek = 40;
            professor.PhoneNumber = "0645409345";
            professor.Subject = "Physycs";
            professor.Address = "bg";
            professor.Email = "lebron123@gmail.com";
            professor.Password = "Holalala";
            DateTime date = new DateTime(2022, 1, 1);
            professor.BornDate = date;
            List<UserRoles> listUserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = 200,
                RoleId = 9

            };
            listUserRoles.Add(userRole);
            professor.Roles = listUserRoles;
            list.Add(professor);
            return list;
        }
    }
}
