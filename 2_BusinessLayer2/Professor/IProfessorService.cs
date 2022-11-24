using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IProfessorService : IGenericService<Professor>
    {
        List<Professor> Search(string search);
     
    }
}
