

using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected DbSet<T> table;
        protected readonly TuxContext db;

        public GenericRepository(TuxContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public void Create(T student)
        {
            table.Add(student);
            db.SaveChanges();
        }

        public void Delete(object id)
        {      
            var model = findStudent(id);
            db.Set<T>().Remove(model);
            if (model != null)
            {
                table.Attach(model);
                table.Remove(model);
                db.SaveChanges();
            }
        }

        public T findStudent(object id)
        {
            return table.Find(id);
        }

        public void Update(T student)
        {
            table.Attach(student);
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }


        public IEnumerable<T> GetAllStudents()
        {
            return table.ToList();
        }

        
    }
}
