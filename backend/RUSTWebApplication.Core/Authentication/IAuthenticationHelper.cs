using RUSTWebApplication.Core.Entity.Authentication;

namespace RUSTWebApplication.Core.Authentication
{
	interface IAuthenticationHelper
	{
		void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
		bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
		string GenerateToken(User user);
	}
}
