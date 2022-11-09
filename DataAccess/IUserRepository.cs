using System.Collections.Generic;
using BusinessObjectModel;

namespace DataAccess
{
	public interface IUserRepository
	{
		List<UserDetails> GetUserDetailsList();
	}
}
