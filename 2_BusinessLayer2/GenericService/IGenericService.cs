
using BusinessObjectModel;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> GetAllStudents();
    //      void Create(T student, List<UserRoles> list);
        void Create(T student);
        T findStudent(object id);
        void Remove(object id);
        void Update(T student);
        

        //     IEnumerable<T> Search(object search);
        //  void Export(object id);
    }
}
