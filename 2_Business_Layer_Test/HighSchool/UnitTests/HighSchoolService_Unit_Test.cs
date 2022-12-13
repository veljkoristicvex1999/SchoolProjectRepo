using BusinessLayer;
using BusinessObjectModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2_Business_Layer_Test.HighSchool.UnitTests
{
    public class HighSchoolService_Unit_Test
    {
        private readonly Mock<IHighSchoolService> _sup;

        public HighSchoolService_Unit_Test()
        {
            _sup = new Mock<IHighSchoolService>();
        }

        [Fact]
        public void Should_Add_HighSchool_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sup.Setup(x => x.Create(student)).Verifiable();
            _sup.Object.Create(student);
            _sup.Verify(x => x.Create(It.Is<HighSchoolStudents>(stud => stud.Id == student.Id)));
        }
        [Fact]
        public void Should_Delete_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sup.Setup(x => x.Remove(student)).Verifiable();
            _sup.Object.Remove(student);
            _sup.Verify(x => x.Remove(It.Is<HighSchoolStudents>(stud => stud.Id == student.Id)));
        }

        [Fact]
        public void Should_Update_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sup.Setup(x => x.Update(student)).Verifiable();
            _sup.Object.Update(student);
            _sup.Verify(x => x.Update(It.Is<HighSchoolStudents>(stud => stud.Id == student.Id)));
        }

        [Fact]
        public void Should_Get_HighSchoolStudent_If_Exist()
        {
            var student = MyStudentsList()[0];
            _sup.Setup(x => x.findByEmail(student.Email)).Returns(student);
            var foundStudent = _sup.Object.findByEmail(student.Email);
            Assert.Equal(foundStudent.Email, student.Email);
        }


        public List<HighSchoolStudents> MyStudentsList()
        {
            List<HighSchoolStudents> list = new List<HighSchoolStudents>();
            HighSchoolStudents highSchoolStudent = new HighSchoolStudents();
            highSchoolStudent.Id = 150;
            highSchoolStudent.Name = "Aleksinaa";
            highSchoolStudent.LastName = "Bryanta";
            highSchoolStudent.DateOfEnrollment = new DateTime(2020, 1, 1);
            highSchoolStudent.PhoneNumber = "0645409345";
            highSchoolStudent.SchoolName = "Sesta";
            highSchoolStudent.Address = "bg";
            highSchoolStudent.Email = "lebron123@gmail.com";
            highSchoolStudent.Password = "Holalala";
            DateTime date = new DateTime(2022, 1, 1);
            highSchoolStudent.BornDate = date;
            List<UserRoles> listUserRoles = new List<UserRoles>();
            UserRoles userRole = new UserRoles()
            {
                Id = 150,
                RoleId = 7

            };
            listUserRoles.Add(userRole);
            highSchoolStudent.Roles = listUserRoles;
            list.Add(highSchoolStudent);
            return list;
        }
    }
}
