using BusinessObjectModel;
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
        
        public ProfessorService(IProfessorRepository _profesorRepository) : base(_profesorRepository)
        {
            this._profesorRepository = _profesorRepository;
        }
        public override void Create(Professor student)
        {
            _profesorRepository.Create(student);
        }

        public Professor findByEmail(string email)
        {
            return _profesorRepository.findByEmail(email);
        }

        public List<Professor> Search(String search)
        {
            return _profesorRepository.search(search);
        }

       

    }
}
