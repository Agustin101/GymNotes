using Microsoft.EntityFrameworkCore;
using System;
using UsersServiceApi.Domain.Models;

namespace UsersServiceApi.Infra.Data
{
    public static class DataBaseInitializer
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<UsersDbContext>()!, isProduction);
            }
        }

        private static void SeedData(UsersDbContext context, bool isProduction)
        {

            Console.WriteLine("--> Attempting to apply migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }

            if(!isProduction && !context.Users.Any())
            {
                Console.WriteLine("--> Adding test user...");

                context.Users.Add(new User()
                {
                    Email = "agus_101@live.com.ar",
                    BirthDay = new DateTime(2001, 07, 16),
                    Heigth = 1.76f,
                    Weigth = 77.4f,
                    Name = "Agustin",
                    LastName = "Barberis",
                    StartDate = DateTime.Now,
                    HashedPassword = "2"
                });
            }
        }
    }
}
