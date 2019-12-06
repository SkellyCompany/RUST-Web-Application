using RUSTWebApplication.Core.Authentication;


namespace RUSTWebApplication.Infrastructure
{
	public class DbInitializer : IDbInitializer
	{
		private readonly IAuthenticationHelper _authenticationHelper;


		public DbInitializer(IAuthenticationHelper authenticationHelper)
		{
			_authenticationHelper = authenticationHelper;
		}

		public void Seed(RUSTWebApplicationContext context)
		{
			throw new System.NotImplementedException();
		}
	}
}
