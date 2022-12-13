using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProfessorService : GenericService<Professor>, IProfessorService
    {
        private IProfessorRepository _profesorRepository;
        private IProfessorQueryRepository _professorQueryRepository;
        
        public ProfessorService(IProfessorRepository _profesorRepository, IProfessorQueryRepository _professorQueryRepository) : base(_profesorRepository)
        {
            this._profesorRepository = _profesorRepository;
            this._professorQueryRepository = _professorQueryRepository;
        }
        public override void Create(Professor student)
        {
            _profesorRepository.Create(student);
        }

        public Professor findByEmail(string email)
        {
            return _profesorRepository.findByEmail(email);
        }

        public List<ProfessorQueryModel> GetAllStudents()
        {
            return _professorQueryRepository.GetAllStudents();
        }


        public List<ProfessorQueryModel> Search(string search)
        {
            return _professorQueryRepository.Search(search);
        }
    }
}
