using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IFacultyStudentService : IGenericService<FaculltyStudents>
    {
       
        List<FacultyQueryModel> Search (string search);
        List<FacultyQueryModel> GetAllStudents();
        void Export(int id);
        FaculltyStudents findByEmail(String email);
    }
}
