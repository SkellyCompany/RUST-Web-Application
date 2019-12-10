using System;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Authentication;
using RUSTWebApplication.Core.Entity.Authentication;

namespace RUSTWebApplication.Core.ApplicationService.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IAuthenticationHelper _authenticationHelper;


		public UserService(IUserRepository userRepository, IAuthenticationHelper authenticationHelper)
		{
			_userRepository = userRepository;
			_authenticationHelper = authenticationHelper;
		}

		public User Validate(LoginInputModel loginInput)
		{
			if (loginInput == null)
			{
				throw new ArgumentNullException("LoginInput cannot be null");
			}
			else if (string.IsNullOrEmpty(loginInput.Username))
			{
				throw new ArgumentException("You need to specify a Username for the LoginInput");
			}
			else if (string.IsNullOrEmpty(loginInput.Password))
			{
				throw new ArgumentException("You need to specify a Password for the LoginInput");
			}

			User user = _userRepository.Read(loginInput.Username);
			if (_authenticationHelper.VerifyPasswordHash(loginInput.Password, user.PasswordHash, user.PasswordSalt) == false)
			{
				throw new ArgumentException("The Password does not match the User's StoredPassword");
			}
			return user; 
		}
	}
}
