
using BusinessObjectModel;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IHighSchoolService : IGenericService<HighSchoolStudents>
    {
     

      List<HighSchoolStudents> Search(String search);
        void Export(int id);
        HighSchoolStudents findByEmail(String email);
    }
}
