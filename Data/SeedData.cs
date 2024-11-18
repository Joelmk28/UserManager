using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyEntitySecurity.Service;

namespace MyEntitySecurity.Data;

    public static class SeedData
    {
    
    public static void GeneratedUser(this ModelBuilder modelBuilder) {

        var passwordService = new PasswordService();

        List<User> users = new List<User>()
            {
              
                new User { Id = 1,UserName = "joelmk28",PassWord = passwordService.HashPassword("joelmk28"),Role="ADMIN" },
                 new User { Id = 2,UserName = "daniel",PassWord = passwordService.HashPassword("joelmk28"),Role="ETUDIANT" },
                  new User { Id = 3,UserName = "claudient",PassWord = passwordService.HashPassword("joelmk28"),Role="PROD" },
            };

        foreach (var user in users) {
          
            modelBuilder.Entity<User>().HasData(user);
        }

        }



    }

