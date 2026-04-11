using Microsoft.AspNetCore.Identity;
using SevDocs.Services.Email;
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

        internal static IServiceCollection AddEmailServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, SmtpEmailSender>();

            services.AddOptions<SmtpEmailOptions>()
                .BindConfiguration("Smtp")
                .Configure<IConfiguration>((opt, cfg) =>
                {
                    if (cfg.GetConnectionString("mailpit") != null)
                    {
                        opt.UseSsl = false;
                        opt.Host = cfg.GetValue<string>("MAILPIT_HOST");
                        opt.Port = cfg.GetValue<int>("MAILPIT_PORT");
                    }
                });

            return services;
        }
    }
}
