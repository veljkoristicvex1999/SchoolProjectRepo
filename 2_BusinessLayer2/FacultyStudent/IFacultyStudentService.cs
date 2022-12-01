using BusinessObjectModel;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IFacultyStudentService : IGenericService<FaculltyStudents>
    {
       
        List<FaculltyStudents> Search (string search);
        void Export(int id);
        FaculltyStudents findByEmail(String email);
    }
}
