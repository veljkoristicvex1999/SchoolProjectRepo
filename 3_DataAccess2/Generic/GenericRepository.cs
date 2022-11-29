

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

        public virtual void Delete(object id)
        {      
            var model = FindStudent(id);
            db.Set<T>().Remove(model);
            if (model != null)
            {
                table.Attach(model);
                table.Remove(model);
                db.SaveChanges();
            }
        }

        public T FindStudent(object id)
        {
            return table.Find(id);
        }

        public void Update(T student)
        {

            table.Attach(student);
            db.Entry(student).State = EntityState.Modified;          
             db.SaveChanges();
            // ovo ne radi lepo 
          
        }


        public virtual IEnumerable<T> GetAllStudents()
        {
            return table.SqlQuery("select * from ((t_users INNER JOIN t_user_roles ON t_users.Id = t_user_roles.Id) INNER JOIN t_roles ON t_roles.RoleId = t_user_roles.RoleId)");
        }

        public virtual void Create(T Student)
        {
            table.Add(Student);
            db.SaveChanges();
        }
    }
}
