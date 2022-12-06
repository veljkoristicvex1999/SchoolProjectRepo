
using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IHighSchoolService : IGenericService<HighSchoolStudents>
    {
        void Export(int id);
        HighSchoolStudents findByEmail(String email);
        List<HighSchoolQueryModel> GettAllStudents();
        List<HighSchoolQueryModel> Search(String search);
    }
}
