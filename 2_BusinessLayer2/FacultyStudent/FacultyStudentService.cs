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
        private IFacultyStudentRepository IFacultyStudentRepository;

        public FacultyStudentService(IFacultyStudentRepository IFacultyStudentRepository) : base(IFacultyStudentRepository)
        {
            this.IFacultyStudentRepository = IFacultyStudentRepository;
        }
        public void Export(int id)
        {
            IFacultyStudentRepository.Export(id);
        }


        public List<FaculltyStudents> Search(string search)
        {
            return IFacultyStudentRepository.search(search);
        }
    }
}
