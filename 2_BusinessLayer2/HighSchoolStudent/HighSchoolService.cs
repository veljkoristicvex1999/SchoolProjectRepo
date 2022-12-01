
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
        private IHighSchoolRepository _highSchoolRepository;

        public HighSchoolService(IHighSchoolRepository highSchoolRepository) : base(highSchoolRepository)
        {
            this._highSchoolRepository = highSchoolRepository;
        }


        public void Export(int id)
        {
            _highSchoolRepository.Export(id);
        }

       
        //verovatno je save changes problem jer ga nemas i ne cuva podatke ove
        public List<HighSchoolStudents> Search(string search)
        {
            return _highSchoolRepository.search(search);
        }

        public override void Remove(object id)
        {
            _highSchoolRepository.Delete(id);
        }
        public override void Create(HighSchoolStudents student)
        {
            _highSchoolRepository.Create(student);
        }

        public HighSchoolStudents findByEmail(string email)
        {
            return _highSchoolRepository.findByEmail(email);
        }
    }
}
