using Microsoft.AspNetCore.Identity;

namespace MyEntitySecurity.Service
{
    public class PasswordService
    {
        private readonly PasswordHasher<object> _passwordHasher;

        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<object>();
        }

        public string HashPassword(string password)
        {
            // Utilisez un objet null ou une instance appropriée comme contexte
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            // Vérifie si le mot de passe en clair correspond au hachage
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
   

}

