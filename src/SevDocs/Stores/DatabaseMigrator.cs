using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SevDocs.Stores
{
    internal static class DatabaseMigrator
    {
        public static async Task MigrateDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await dbContext.Database.MigrateAsync();
            });
        }

        public static async Task SeedDevDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();

            var dbDontext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (await dbDontext.Users.AnyAsync())
                return;

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = new AppUser
            {
                Email = "test@test.com",
                EmailConfirmed = true,
                FirstName = "Ad",
                LastName = "Min",
                UserName = "Admin"
            };

            await userManager.CreateAsync(user, "1qaz@WSX");
        }
    }
}
