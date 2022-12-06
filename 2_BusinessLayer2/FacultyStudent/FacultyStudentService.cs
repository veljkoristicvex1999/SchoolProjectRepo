using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObjectModel.QueryModels;

namespace BusinessLayer
{
    public class FacultyStudentService : GenericService<FaculltyStudents> , IFacultyStudentService
    {
        private IFacultyStudentRepository _facultyStudenRepository;
        private IFacultyQueryModelRepository _facultyQueryRepository;

        public FacultyStudentService(IFacultyStudentRepository facultyStudentRepository, IFacultyQueryModelRepository _facultyQueryRepository) : base(facultyStudentRepository)
        {
            this._facultyStudenRepository = facultyStudentRepository;
            this._facultyQueryRepository = _facultyQueryRepository;
        }
        public void Export(int id)
        {
            _facultyStudenRepository.Export(id);
        }

        public List<FacultyQueryModel> Search(string search)
        {
            return _facultyQueryRepository.Search(search);
        }
        
        public override void Create(FaculltyStudents student)
        {
             _facultyStudenRepository.Create(student);
        }

        public FaculltyStudents findByEmail(string email)
        {
            return _facultyStudenRepository.findByEmail(email);
        }

        

        public List<FacultyQueryModel> GetAllStudents()
        {
            return _facultyQueryRepository.GetAllStudents();
        }
    }
}
