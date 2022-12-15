using BusinessObjectModel;
using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess
{
    public class FacultyQueryModelRepository : IFacultyQueryModelRepository
    {
        private readonly TuxContext db;

        public FacultyQueryModelRepository(TuxContext db) 
        {
            this.db = db;
        }
        public List<FacultyQueryModel> Search(string search)
        {
            
            
                var ProfessorList = db.Database.SqlQuery<FacultyQueryModel>("select Id, Name, LastName,BornDate,Address from dbo.t_users where (LOWER(Name) like LOWER(concat('%',@search, '%')) or LOWER(LastName) like LOWER(concat('%',@search, '%')) or LOWER(Address) like LOWER(concat('%',@search, '%')) or LOWER(BornDate) like LOWER(concat('%',@search, '%')))  and (BillingDetailType = 'Facullty')", new SqlParameter("@search", search)).ToList();

                return ProfessorList;
            

        }

            public List<FacultyQueryModel> GetAllStudents()
        {
            
                var qery = @"select * from ((t_users INNER JOIN t_user_roles ON t_users.Id = t_user_roles.Id) INNER JOIN t_roles ON t_roles.RoleId = t_user_roles.RoleId) where BillingDetailType = 'Facullty'";
                var FacultyList = db.Database.SqlQuery<FacultyQueryModel>(qery).ToList();
                return FacultyList;
            
           


        }

        public void Create(FacultyQueryModel Student)
        {
            throw new NotImplementedException();
        }

        public FacultyQueryModel FindStudent(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(FacultyQueryModel student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FacultyQueryModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

