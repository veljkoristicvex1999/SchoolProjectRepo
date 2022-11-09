
using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLayer
{
    public class HighSchoolService : GenericService<HighSchoolStudents>, IHighSchoolService
    {
        private IHighSchoolRepository IHighSchoolRepository;

        public HighSchoolService(IHighSchoolRepository IHighSchoolRepository) : base(IHighSchoolRepository)
        {
            this.IHighSchoolRepository = IHighSchoolRepository;
        }


        public void Export(int id)
        {
            IHighSchoolRepository.Export(id);
        }

       
        //verovatno je save changes problem jer ga nemas i ne cuva podatke ove
        public List<HighSchoolStudents> Search(string search)
        {
            return IHighSchoolRepository.search(search);
        }



     
    }
}
