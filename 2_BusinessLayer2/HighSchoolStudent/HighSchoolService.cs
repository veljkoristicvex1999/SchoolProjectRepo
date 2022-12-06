
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
    public class HighSchoolService : GenericService<HighSchoolStudents>, IHighSchoolService
    {

        IHighSchoolRepository _highSchoolRepository;
        IHighSchoolQueryRepository _highSchoolQueryRepository;

        public HighSchoolService(IHighSchoolRepository _highSchoolRepository, IHighSchoolQueryRepository _highSchoolQueryRepository) : base(_highSchoolRepository)
        {
            this._highSchoolRepository = _highSchoolRepository;
            this._highSchoolQueryRepository = _highSchoolQueryRepository;
        }


        public void Export(int id)
        {
            _highSchoolRepository.Export(id);
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
        

        public List<HighSchoolQueryModel> GettAllStudents()
        {
            return _highSchoolQueryRepository.GetAllStudents();
        }

        public List<HighSchoolQueryModel> Search(string search)
        {
            return _highSchoolQueryRepository.Search(search.ToString());
        }
    }
}
