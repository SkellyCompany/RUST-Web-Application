using RUSTWebApplication.Core.Entity.Authentication;

namespace RUSTWebApplication.Core.ApplicationService
{
	public interface IUserService
	{
		User ValidateUser(LoginInputModel loginInput);
	}
}
