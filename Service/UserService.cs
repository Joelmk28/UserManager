using Microsoft.EntityFrameworkCore;
using MyEntitySecurity.Data;

namespace MyEntitySecurity.Service
{
    public class UserService
    {
        public readonly DataContext dataContext;
        public UserService(DataContext dataContext) {
            this.dataContext = dataContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await dataContext.users.ToListAsync();
            return users;
        }
    }
}
