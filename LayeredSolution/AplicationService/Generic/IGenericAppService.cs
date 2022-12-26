using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredSolution
{
    public interface IGenericAppService<Model,VievModel> where Model : class where VievModel : class
    {
     //   IEnumerable<VievModel> GetAllStudents();
        void Create(VievModel student);
        VievModel findStudent(object id);
        void Remove(object id);
        void Update(VievModel student);
        VievModel Validate(VievModel model);
    }
}
