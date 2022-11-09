using System.Collections.Generic;
using BusinessObjectModel;
using DataAccess;
using Mehdime.Entity;

namespace BusinessLayer
{
	public class UserService 
	{
		private readonly IDbContextScopeFactory _dbContextScopeFactory;
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository, 
			IDbContextScopeFactory dbContextScopeFactory)
		{
			_userRepository = userRepository;
			_dbContextScopeFactory = dbContextScopeFactory;
		}

		public List<UserDetails> GetUserDetailsList()
		{
			using (_dbContextScopeFactory.CreateReadOnly())
			{
				return _userRepository.GetUserDetailsList();
			}
		}
	}
}
