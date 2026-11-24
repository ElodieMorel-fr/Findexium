using Microsoft.AspNetCore.Identity;

namespace P7CreateRestApi.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<int>> roleManager)
        {
           if (!roleManager.Roles.Any())
           {                
                await roleManager.CreateAsync(new IdentityRole<int> { Name = "Administrateur"});
                await roleManager.CreateAsync(new IdentityRole<int> { Name = "Utilisateur"});
           }
        }
    }
}
