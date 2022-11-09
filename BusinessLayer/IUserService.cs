using System.Collections.Generic;
using BusinessObjectModel;

namespace BusinessLayer
{
	public interface IUserService
	{
		List<UserDetails> GetUserDetailsList();
	}
}
