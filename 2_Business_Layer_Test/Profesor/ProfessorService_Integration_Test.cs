using BusinessLayer;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BusinessObjectModel;
using BusinessObjectModel.QueryModels;

namespace _2_Business_Layer_Test.Profesor
{
    public class ProfessorService_Integration_Test
    {
        //private ProfessorService _professorService;
        //private ProfessorRepository _professorRepository;
        //private ProfessorQueryRepository _professorQueryRepository;
        //private TuxContext db;

        //public ProfessorService_Integration_Test()
        //{
        //    db = new TuxContext();
        //    _professorRepository = new ProfessorRepository(db);
        //    _professorQueryRepository = new ProfessorQueryRepository(db);
        //    _professorService = new ProfessorService(_professorRepository, _professorQueryRepository);
        //}

        //[Fact]
        //public void Create()
        //{
        //    Professor prof = MyProfessorsList()[0];
        //    int size = _professorService.GetAllStudents().Count;
        //    _professorService.Create(prof);
        //    bool ok = false;
        //    int size2 = _professorService.GetAllStudents().Count;
        //    if (size2 > size)
        //    {
        //        ok = true;
        //        _professorService.Remove(prof.Id);
        //    }
         
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void GetAllStudents()
        //{
        //    bool ok = false;
        //    List<ProfessorQueryModel> list = _professorService.GetAllStudents();
        //    if((list != null ) && (list.Count > 0))
        //    {
        //        ok = true;
        //    }
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void FindByEmail()
        //{
        //    Professor prof = MyProfessorsList()[0];
        //    bool ok = false;
        //    _professorService.Create(prof);
        //    if((_professorService.findByEmail(prof.Email) != null) && (_professorService.findByEmail(prof.Email).Name == "Aleks"))
        //    {
        //         ok = true;
        //        _professorService.Remove(prof.Id);
        //    }
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void Search()
        //{
        //    Professor professor = MyProfessorsList()[0];
        //    bool ok = false;
        //    _professorService.Create(professor);
        //    ProfessorQueryModel professorSearch = _professorService.Search("Aleks")[0];
        //    if(_professorService.Search(professor.LastName) != null)
        //    {
        //        ok = true;
        //        _professorService.Remove(professor.Id);
        //    }
        //    Assert.True(ok);
        //}

        //[Fact]
        //public void Update()
        //{
        //    Professor prof = MyProfessorsList()[0];
        //    bool ok = false;
        //    _professorService.Create(prof);
        //    prof.Name = "Jelisaveta";
        //    _professorService.Update(prof);
        //    if(prof.Name.Equals(_professorService.GetAllStudents().Where(a => a.Name.Equals("Jelisaveta")).FirstOrDefault().Name)){
        //        ok = true;
        //        _professorService.Remove(prof.Id);
        //    }
        //    Assert.True(ok);
        //}



        //public List<Professor> MyProfessorsList()
        //{
        //    List<Professor> professors = new List<Professor>();
        //    Professor professor = new Professor();
        //    professor.Id = 70;
        //    professor.Name = "Aleks";
        //    professor.LastName = "Petrovic";
        //    professor.PhoneNumber = "0657656455";
        //    professor.HoursPerWeek = 20;
        //    professor.Address = "Ogledna";
        //    professor.BornDate = new DateTime(2010, 1, 1);
        //    professor.Subject= "English";
        //    professor.Email = "mice12@gmail.com";
        //    professor.Password = "Medakcic234";
        //    UserRoles userRoles = new UserRoles()
        //    {
        //        Id = 80,
        //        RoleId = 9
        //    };
        //    List<UserRoles> listRoles = new List<UserRoles>();
        //    listRoles.Add(userRoles);
        //    professor.Roles = listRoles;
        //    professors.Add(professor);
        //    return professors;
        //}
        
    }
}
