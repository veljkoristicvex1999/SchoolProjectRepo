using BusinessObjectModel.QueryModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HighSchoolQueryRepository  : GenericRepository<HighSchoolQueryModel>,IHighSchoolQueryRepository
    {
       
       
        public HighSchoolQueryRepository(TuxContext db): base(db) { }

        public List<HighSchoolQueryModel> Search(string search)
        {
            
                var HighSchoolList = db.Database.SqlQuery<HighSchoolQueryModel>("select Id, Name, LastName,BornDate,Address from dbo.t_users where (LOWER(Name) like LOWER(concat('%',@search, '%')) or LOWER(LastName) like LOWER(concat('%',@search, '%')) or LOWER(Address) like LOWER(concat('%',@search, '%')) or LOWER(BornDate) like LOWER(concat('%',@search, '%')))  and (BillingDetailType = 'HighSchool')", new SqlParameter("@search", search)).ToList();
                return HighSchoolList;
            

        }

        public  List<HighSchoolQueryModel> GetAllStudents()
        {
            
            
                var qery = @"select * from ((t_users INNER JOIN t_user_roles ON t_users.Id = t_user_roles.Id) INNER JOIN t_roles ON t_roles.RoleId = t_user_roles.RoleId) where BillingDetailType = 'HighSchool'";
                var HighSchooList = db.Database.SqlQuery<HighSchoolQueryModel>(qery).ToList();
                return HighSchooList;
            
        }
    }
}
