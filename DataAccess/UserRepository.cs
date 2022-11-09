using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessObjectModel;

namespace DataAccess
{
	public class UserRepository : DbContext, IUserRepository
	{
		protected DbContext DbContext => DbContextLocator.GetDbContext();

		public UserRepository()
			: base("name=TuxDatabase")
		{
		}

		public List<UserDetails> GetUserDetailsList()
		{
			var query = @"
SELECT TOP 100 id_user AS UserId,
	first_name AS FirstName,
	last_name AS LastName
FROM t_users
";
			var userDetailsList = DbContext.Database.SqlQuery<UserDetails>(query).ToList();
			return userDetailsList;
		}
	}
}
