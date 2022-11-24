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
        private IProfessorRepository IProfessorRepository;
        
        public ProfessorService(IProfessorRepository IProfessorRepository) : base(IProfessorRepository)
        {
            this.IProfessorRepository = IProfessorRepository;
        }
        public override void Create(Professor student)
        {
            IProfessorRepository.Create(student);
        }
        public List<Professor> Search(String search)
        {
            return IProfessorRepository.search(search);
        }

       

    }
}
