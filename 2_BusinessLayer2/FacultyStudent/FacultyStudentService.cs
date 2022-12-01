using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLayer
{
    public class FacultyStudentService : GenericService<FaculltyStudents> , IFacultyStudentService
    {
        private IFacultyStudentRepository _facultyStudenRepository;

        public FacultyStudentService(IFacultyStudentRepository facultyStudentRepository) : base(facultyStudentRepository)
        {
            this._facultyStudenRepository = facultyStudentRepository;
        }
        public void Export(int id)
        {
            _facultyStudenRepository.Export(id);
        }


        public List<FaculltyStudents> Search(string search)
        {
            return _facultyStudenRepository.search(search);
        }
        public override void Create(FaculltyStudents student)
        {
             _facultyStudenRepository.Create(student);
        }

        public FaculltyStudents findByEmail(string email)
        {
            return _facultyStudenRepository.findByEmail(email);
        }
    }
}
