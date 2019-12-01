using System;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Authentication;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;


		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public User ValidateUser(LoginInputModel loginInput)
		{
			throw new NotImplementedException();
		}
	}
}
