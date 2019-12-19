namespace RUSTWebApplication.Infrastructure
{
	public interface IDbInitializer
	{
		void SeedInMemory(RUSTWebApplicationContext context);
        void SeedAzure(RUSTWebApplicationContext context);
    }

}
