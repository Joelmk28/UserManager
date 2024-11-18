using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyEntitySecurity.Data;

namespace MyEntitySecurity.Service
{
    public class UserService
    {
        public readonly DataContext dataContext;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserService(DataContext dataContext) {
            this.dataContext = dataContext;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await dataContext.users.ToListAsync();
            return users;
        }
        public async Task<User> ChangePassWord(User user,string NewPassWord)
        {
           

            try
            {
                var userFind = await dataContext.users.FirstOrDefaultAsync(u => u.Equals(user));
                if (userFind != null)
                {
                    userFind.PassWord = _passwordHasher.HashPassword(user,NewPassWord);
                    await dataContext.SaveChangesAsync();
                    return userFind;
                }
                else
                {
                    return new User();
                }
              
            }
            catch (Exception ex) { 
                Console.WriteLine("----------------\n"+
                               ex+"\n---------------");
                return new User();
            }

          
        }

        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            // Vérifie si le mot de passe en clair correspond au hachage
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<(User,string,bool)> ToLogin(string username,string pwd)
        {
            try
            {
                var users = await GetAllUsers();
                var userConnected = users.Where(User => User.UserName == username).FirstOrDefault();

                if (userConnected == null)
                {

                    return (userConnected, "Aucun utilisateur n'est trouvé avec ce nom",false);
                }

              var result =  _passwordHasher.VerifyHashedPassword(null, userConnected.PassWord,pwd);
                if (result == PasswordVerificationResult.Success)
                    return (userConnected, "Connection effectuée avec succes",true);
                return (userConnected, "Mot de passe incorecte", false);

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return (null, "Un probleme est survenu lors de la connection , reessayer plus tard", false);
            }
        }

    }
}
