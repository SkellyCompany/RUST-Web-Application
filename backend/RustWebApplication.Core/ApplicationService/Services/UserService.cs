using System;
using RustWebApplication.Core.DomainService;
using RustWebApplication.Core.Entity;

namespace RustWebApplication.Core.ApplicationService.Services
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
