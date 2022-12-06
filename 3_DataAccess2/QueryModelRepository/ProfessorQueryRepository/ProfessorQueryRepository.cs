﻿using BusinessObjectModel;
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
    public class ProfessorQueryRepository : GenericRepository<ProfessorQueryModel>, IProfessorQueryRepository
    {
       
      
       
        public ProfessorQueryRepository(TuxContext db) : base(db)
        {
           
        }

        public List<ProfessorQueryModel> Search(string search)
        {

            using (db)
            {
                var ProfessorList = db.Database.SqlQuery<ProfessorQueryModel>("select Id, Name, LastName,BornDate,Address from dbo.t_users where (LOWER(Name) like LOWER(concat('%',@search, '%')) or LOWER(LastName) like LOWER(concat('%',@search, '%')) or LOWER(Address) like LOWER(concat('%',@search, '%')) or LOWER(BornDate) like LOWER(concat('%',@search, '%')))  and (BillingDetailType = 'Professor')", new SqlParameter("@search", search)).ToList();

                return ProfessorList;
            }
            
        }

        public List<ProfessorQueryModel> GetAllStudents()
        {
            using (db)
            {
                var qery = @"select * from ((t_users INNER JOIN t_user_roles ON t_users.Id = t_user_roles.Id) INNER JOIN t_roles ON t_roles.RoleId = t_user_roles.RoleId) where BillingDetailType = 'Professor'";
                var ProfessorList = db.Database.SqlQuery<ProfessorQueryModel>(qery).ToList();
                return ProfessorList;
            }
        }
    }
}
