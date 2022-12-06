using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess;

namespace BusinessLayer
{


   public  class GenericService<T> : IGenericService<T> where T : class
    {
        private IGenericRepository<T> repository;
        

        public GenericService(IGenericRepository<T> repository)
        {
            this.repository = repository; 
        }

        public virtual void Create(T student)
        {
            repository.Create(student);
        }

        public T findStudent(object id)
        {
            return repository.FindStudent(id);
        }

     

        public IEnumerable<T> GetAllStudents()
        {
            return repository.GetAllStudents();
        }

        public virtual void Remove(object id)
        {
            repository.Delete(id);
        }

        public void Update(T student)
        {
            repository.Update(student);
        }



    }

}