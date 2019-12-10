using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Authentication;
using System.Linq;

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