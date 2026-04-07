using Microsoft.AspNetCore.Identity;
using SevDocs.Stores;

namespace SevDocs.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();

            services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();

            services.AddIdentityCore<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
