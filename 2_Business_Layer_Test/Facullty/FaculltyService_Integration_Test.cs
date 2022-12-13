using BusinessLayer;
using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _2_Business_Layer_Test
{
    public class FaculltyService_Integration_Test
    {
        //private FacultyStudentService _facultyStudentService;
        //private FacultyQueryModelRepository _facultyQueryRepository;
        //private FacultyStudentRepository _facultyStudentRepository;
        //private readonly TuxContext db;
        //public FaculltyService_Integration_Test()
        //{
        //    db = new TuxContext();
        //    _facultyQueryRepository = new FacultyQueryModelRepository(db);
        //    _facultyStudentRepository = new FacultyStudentRepository(db);           
        //    _facultyStudentService = new FacultyStudentService(_facultyStudentRepository, _facultyQueryRepository);


        //}
        //[Fact]
        //public void Update()
        //{
        //    FaculltyStudents student = MyStudentsList()[0];
        //    bool ok = false;
        //    _facultyStudentService.Create(student);
        //    student.Name = "Marija";
        //    _facultyStudentService.Update(student);
        //    if (student.Name.Equals(_facultyStudentService.GetAllStudents().Where(a => a.Name.Equals("Marija")).FirstOrDefault().Name))
        //    {
        //        ok = true;
        //        _facultyStudentService.Remove(student.Id);
        //    }
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void Create()
        //{          
        //    int ListSize = _facultyStudentService.GetAllStudents().Count;
        //    FaculltyStudents student = MyStudentsList()[0];
        //    _facultyStudentService.Create(student);
        //    int List2Size = _facultyStudentService.GetAllStudents().Count;
        //    bool result = false;
        //    if ((List2Size > ListSize))
        //    {
        //        result = true;
        //    }
        //    _facultyStudentService.Remove(student.Id);
        //    Assert.True(result);           
        //}
        //[Fact]
        //public void FindByEmail()
        //{
        //    FaculltyStudents student = MyStudentsList()[0];
        //    _facultyStudentService.Create(student);
        //    FaculltyStudents findStudent = _facultyStudentService.findByEmail(student.Email);
        //    bool ok = false;
        //    if((findStudent!=null) && (findStudent.Name== "Aleksina") && (findStudent.LastName == "Bryanta")) {           
        //        _facultyStudentService.Remove(student.Id);
        //        ok = true;
        //    }
        //    Assert.True(ok);
        //}
        //[Fact]
        //public void GetAllStudents()
        //{
        //    bool ok =  false;
        //    List<FacultyQueryModel> faculltyStudents = _facultyStudentService.GetAllStudents();
        //    if(faculltyStudents!=null) {
        //        ok = true;
        //    }
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void Search()
        //{
        //    bool ok = false;
        //    FaculltyStudents student = MyStudentsList()[0];
        //    _facultyStudentService.Create(student);
        //    FacultyQueryModel SearchStudent = _facultyStudentService.Search("Aleksina")[0];
        //    if((SearchStudent!=null) && (SearchStudent.Lastname == "Bryanta"))
        //    {
        //        ok = true;
        //        _facultyStudentService.Remove(student.Id);
        //    }
        //    Assert.True(ok);
        //}

        //public List<FaculltyStudents> MyStudentsList() {
        //    List<FaculltyStudents> list = new List<FaculltyStudents>();
        //    FaculltyStudents faculltyStudents = new FaculltyStudents();
        //    faculltyStudents.Id = 57;
        //    faculltyStudents.Name = "Aleksina";
        //    faculltyStudents.LastName = "Bryanta";
        //    faculltyStudents.Generation = 1999;
        //    faculltyStudents.PhoneNumber = "0645409345";
        //    faculltyStudents.FacultyName = "PMF";
        //    faculltyStudents.Address = "bg";
        //    faculltyStudents.Email = "kobe12aaa34@gmail.com";
        //    faculltyStudents.Password = "Holala";
        //    DateTime date = new DateTime(2022, 1, 1);
        //    faculltyStudents.BornDate = date;
        //    List<UserRoles> listUserRoles = new List<UserRoles>();
        //    UserRoles userRole = new UserRoles()
        //    {
        //        Id = 57,
        //        RoleId = 10

        //    };
        //    listUserRoles.Add(userRole);
        //    faculltyStudents.Roles = listUserRoles;
        //    list.Add(faculltyStudents);
        //    return list;
        //}
    }
}
