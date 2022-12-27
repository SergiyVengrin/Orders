using Application.Interfaces;

namespace Infrastructure.Security
{
    public sealed class PasswordHasher:IPasswordHasher
    {
        public string? HashPassword(string? password)
        {
            if(password is null)
            {
                return null;
            }

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
