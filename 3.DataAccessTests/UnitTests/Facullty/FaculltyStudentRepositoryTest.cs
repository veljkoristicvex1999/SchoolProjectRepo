

using BusinessObjectModel;
using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3.DataAccessTests.Facullty
{
    public class FaculltyStudentRepositoryTest
    {
        private readonly Mock<IFacultyStudentRepository> _sut;

        public FaculltyStudentRepositoryTest()
        {
            _sut = new Mock<IFacultyStudentRepository>();
        }

        [Fact]
        public void Should_Add_Student_If_Student_Exist()
        {
            //Arange
            var student = MyStudentsList()[0];
            _sut.Setup(s => s.Create(student)).Verifiable();
            //Act
            _sut.Object.Create(student);
            //Assert
            _sut.Verify(m => m.Create(It.Is<FaculltyStudents>(stud => stud.Id == student.Id)));
        }

        [Fact]
        public void Should_Get_FacullltyStudent_By_Email_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sut.Setup(x => x.findByEmail(student.Email)).Returns(student);
            var stud = _sut.Object.findByEmail(student.Email);
            Assert.Equal(student.Email, stud.Email);
        }

        [Fact]
        public void Should_Updae_FacullltyStudent_If_Exist()
        {
            //Arange
            var student = MyStudentsList()[0];
            _sut.Setup(s => s.Update(student)).Verifiable();
            //Act
            _sut.Object.Update(student);
            //Assert
            _sut.Verify(m => m.Update(It.Is<FaculltyStudents>(stud => stud.Id == student.Id)));

        }


        [Fact]
        public void Should_Delete_FaculltyStudent_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sut.Setup(s => s.Delete(student)).Verifiable();
            //Act
            _sut.Object.Delete(student);
            //ovo
            //Assert
            _sut.Verify(m => m.Delete(It.Is<FaculltyStudents>(stud => stud.Id == student.Id)));
        }

        public List<FaculltyStudents> MyStudentsList()
        {
            List<FaculltyStudents> list = new List<FaculltyStudents>();
            FaculltyStudents faculltyStudents = new FaculltyStudents();
            faculltyStudents.Id = 100;
            faculltyStudents.Name = "Aleksinaa";
            faculltyStudents.LastName = "Bryanta";
            faculltyStudents.Generation = 1999;
            faculltyStudents.PhoneNumber = "0645409345";
            faculltyStudents.FacultyName = "PMF";
            faculltyStudents.Address = "bg";
            faculltyStudents.Email = "kobe12aaa34@gmail.com";
            faculltyStudents.Password = "Holala";
            DateTime date = new DateTime(2022, 1, 1);
            faculltyStudents.BornDate = date;
            List<UserRoles> listUserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = 100,
                RoleId = 10

            };
            listUserRoles.Add(userRole);
            faculltyStudents.Roles = listUserRoles;
            list.Add(faculltyStudents);
            return list;
        }
    }
}
