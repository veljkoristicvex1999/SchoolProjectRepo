using BusinessLayer;
using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2_Business_Layer_Test.HighSchool
{
    public class HighSchoolService_Integration_Test
    {
       
        //private HighSchoolService _highSchoolService;
        //private HighSchoolRepository _highSchoolRepository;
        //private HighSchoolQueryRepository _highSchoolQueryRepository;
        //private TuxContext db;
        //public HighSchoolService_Integration_Test()
        //{
        //    db = new TuxContext();
        //    _highSchoolRepository = new HighSchoolRepository(db);
        //    _highSchoolQueryRepository = new HighSchoolQueryRepository(db);
        //    _highSchoolService = new HighSchoolService(_highSchoolRepository, _highSchoolQueryRepository);
        //}

        //[Fact]
        //public void Create()
        //{
        //    int ListSize = _highSchoolService.GettAllStudents().Count;
        //    HighSchoolStudents student = MyStudentList()[0];
        //    _highSchoolService.Create(student);
        //    int List2Size = _highSchoolService.GettAllStudents().Count;
        //    bool result = false;
        //    if ((List2Size > ListSize))
        //    {
        //        result = true;
        //    }
        //    _highSchoolService.Remove(student.Id);
        //    Assert.True(result);
        //}

        //[Fact]
        //public void FindByEmail()
        //{
        //    HighSchoolStudents student = MyStudentList()[0];
        //    _highSchoolService.Create(student);
        //    bool ok = false;
        //    if((_highSchoolService.findByEmail(student.Email) != null) && (_highSchoolService.findByEmail(student.Email).Name == "Luka"))
        //    {              
        //        _highSchoolService.Remove(student.Id);
        //        ok = true;
        //    }
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void Search()
        //{
        //    HighSchoolStudents student = MyStudentList()[0];
        //    _highSchoolService.Create(student);
        //    bool ok = false;
        //    HighSchoolQueryModel studenSeach = _highSchoolService.Search("Luka")[0];
        //    if((studenSeach != null) && (studenSeach.Lastname == "Eric"))
        //    {
        //        ok = true;
        //        _highSchoolService.Remove(student.Id);
        //    }
        //    Assert.True(ok);
        //}


        //[Fact]
        //public void GetAllStudents()
        //{
        //    bool ok = false;
        //    List<HighSchoolQueryModel> list = _highSchoolService.GettAllStudents();
        //    if((list.Count>0) && (list != null))
        //    {
        //        ok = true;
        //    }
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void Update()
        //{
        //    HighSchoolStudents student = MyStudentList()[0];
        //    bool ok = false;
        //    _highSchoolService.Create(student);
        //    student.Name = "Snezana";
        //    _highSchoolService.Update(student);
        //    if (student.Name.Equals(_highSchoolService.GettAllStudents().Where(a => a.Name.Equals("Snezana")).FirstOrDefault().Name))
        //    {
        //        ok = true;
        //        _highSchoolService.Remove(student.Id);
        //    }
        //    Assert.True(ok);
        //}
        //public List<HighSchoolStudents> MyStudentList()
        //{
        //    List<HighSchoolStudents> studentsList = new List<HighSchoolStudents>();
        //    HighSchoolStudents student = new HighSchoolStudents();
        //    student.Id = 70;
        //    student.Name = "Luka";
        //    student.LastName = "Eric";
        //    student.PhoneNumber = "0657656455";
        //    student.SchoolName = "Sesta";
        //    student.Address = "Ogledna";
        //    student.BornDate = new DateTime(2010, 1, 1);
        //    student.DateOfEnrollment = new DateTime(2017, 1, 1);
        //    student.Email = "lukaeic@gmail.com";
        //    student.Password = "Medak234";
        //    UserRoles userRoles = new UserRoles()
        //    {
        //        Id = 70,
        //        RoleId = 7
        //    };
        //    List<UserRoles> listRoles = new List<UserRoles>();
        //    listRoles.Add(userRoles);
        //    student.Roles = listRoles;
        //    studentsList.Add(student);
        //    return studentsList;
        //}
    }
}
