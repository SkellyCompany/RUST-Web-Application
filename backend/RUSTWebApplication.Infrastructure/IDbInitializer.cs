namespace RUSTWebApplication.Infrastructure
{
	public interface IDbInitializer
	{
		void Seed(RUSTWebApplicationContext context);
	}
}
