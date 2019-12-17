using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Authentication;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
		private readonly RUSTWebApplicationContext _context;


		public UserRepository(RUSTWebApplicationContext context)
		{
			_context = context;
		}

		public User Read(string username)
        {
			return _context.Users.AsNoTracking().FirstOrDefault(u => u.Username == username);
		}
    }
}