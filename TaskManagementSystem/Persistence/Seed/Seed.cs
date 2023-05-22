using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Seed
{
    public class Seed
    {
        public static async System.Threading.Tasks.Task SeedData(TaskManagementSystemDbContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User {
                        FullName = "Elsai Deribu",
                        UserName = "elsai",
                        Email = "elsai@test.com"

                    },

                     new User {
                        FullName = "Yafet Deribu",
                        UserName = "yafet",
                        Email = "yafet@test.com"

                    },

                     new User {
                        FullName = "Yulian Deribu",
                        UserName = "yulian",
                        Email = "yulian@test.com"

                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }


            }

        }
    }
}