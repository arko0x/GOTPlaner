using Microsoft.AspNetCore.Identity;

namespace GOTPlaner.Data
{
    public class MyIdentityInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Leader").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Leader",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Tourist").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Tourist",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedOneUser(UserManager<IdentityUser> userManager, string name, string password, string role = null, string role2 = null)
        {
            if (userManager.FindByNameAsync(name).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = name,
                    Email = name
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                    userManager.AddToRoleAsync(user, role2).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            SeedOneUser(userManager, "admin@localhost", "Admin123", "Admin");
            SeedOneUser(userManager, "tourist@localhost", "Tourist1", "Tourist");
            SeedOneUser(userManager, "leader@localhost", "Leader12", "Leader", "Tourist");
            SeedOneUser(userManager, "leader2@localhost", "Leader12", "Leader", "Tourist");
        }
    }
}
