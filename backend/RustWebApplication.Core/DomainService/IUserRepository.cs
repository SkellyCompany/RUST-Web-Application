using RUSTWebApplication.Core.Entity.Authentication;

namespace RUSTWebApplication.Core.DomainService
{
	public interface IUserRepository
	{
		User Read(string username);
	}
}
