using Microsoft.EntityFrameworkCore;

namespace MyEntitySecurity.Data;

    public static class SeedData
    {
        public static void GeneratedUser(this ModelBuilder modelBuilder) { 
            List<User> users =  new List<User>()
            {
                new User { Id = 1,UserName = "joelmk28",PassWord = "joelmk28",Role="ADMIN" },
                 new User { Id = 2,UserName = "daniel",PassWord = "joelmk28",Role="ETUDIANT" },
                  new User { Id = 3,UserName = "claudient",PassWord = "joelmk28",Role="PROD" },
            };

        foreach (var user in users) { 
            modelBuilder.Entity<User>().HasData(user);
        }

        }



    }

