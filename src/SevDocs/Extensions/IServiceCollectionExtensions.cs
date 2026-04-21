using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SevDocs.Features.SendEmail;
using SevDocs.Services.Email;
using SevDocs.Stores;
using SevDocs.Stores.Configs;
using SevDocs.Stores.Jobs;
using SevDocs.Templates;

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
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            return services;
        }

        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            builder.AddNpgsqlDbContext<AppDbContext>("postgresdb");
            builder.AddSqliteDbContext<JobsDbContext>("sqlite");
            builder.Services.AddPooledDbContextFactory<JobsDbContext>(opt => { });
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        }

        internal static IServiceCollection AddTemplating(this IServiceCollection services)
        {
            return services
                .AddScoped<HtmlRenderer>()
                .AddTransient<ITemplateRenderer, RazorRenderer>();
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

        internal static IServiceCollection AddJobs(this IServiceCollection services)
        {
            services.Configure<JobsOptions>(opt =>
            {
                opt.Retry.Delay = TimeSpan.FromMinutes(1);
                opt.Retry.Retries = 3;

                opt.ConfigureRetries<SendEmailJob>(10, TimeSpan.FromSeconds(5));
            });

            return services.AddJobQueues<JobRecord, JobsStorage>();
        }
    }
}
