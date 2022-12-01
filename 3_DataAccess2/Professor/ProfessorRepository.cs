using BusinessObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class ProfessorRepository :GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(TuxContext db) : base(db)
        {

        }
        public override IEnumerable<Professor> GetAllStudents()
        {
            return table.SqlQuery("  select * from ((t_users INNER JOIN t_user_roles ON t_users.Id = t_user_roles.Id) INNER JOIN t_roles ON t_roles.RoleId = t_user_roles.RoleId) where BillingDetailType ='Professor'");
        }

        public override void Create(Professor Student)
        {
            table.Add(Student);
            db.UserRoles.AddRange(Student.Roles);
            db.SaveChanges();
        }
        public override void Delete(object id)
        {
            var model = table.Include("Roles").Where(a => a.Id == (int)id).First();
            if (model != null)
            {
                table.Attach(model);
                db.UserRoles.RemoveRange(model.Roles);
                table.Remove(model);
                db.SaveChanges();
            }
        }

        public List<Professor> search(string search)
        {
            search = search.ToUpper();
            List<Professor> students = table.Where(s => (s.Address).ToUpper().Contains(search)  || (s.BornDate).ToString().ToUpper().Contains(search) || (s.PhoneNumber).ToUpper().Contains(search) || (s.Name).ToUpper().Contains(search) || (s.Email.ToUpper().Contains(search)) || (s.LastName.ToUpper().Contains(search) || (s.Name.ToUpper().Contains(search)))).ToList();
            return students;
        }

        public Professor findByEmail(string email)
        {
            return table.Where(a => a.Email == email).First();
        }
    }
}
