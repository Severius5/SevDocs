global using SevDocs.Stores.Entities;
global using FastEndpoints;

using SevDocs.Client.Extensions;
using SevDocs.Components;
using SevDocs.Extensions;
using SevDocs.Shared;
using SevDocs.Stores;

namespace SevDocs;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        builder.Services.AddSharedServices();

        builder.AddNpgsqlDbContext<AppDbContext>("postgresdb");

        builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents()
            .AddAuthenticationStateSerialization();

        builder.Services.AddAuth();

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddFastEndpoints(opts =>
        {
            opts.IncludeAbstractValidators = true;
            opts.DisableAutoDiscovery = true;
            opts.Assemblies = [typeof(Program).Assembly, typeof(SharedMarker).Assembly];
        });

        //builder.Services.AddScoped<IdentityRedirectManager>();
        //builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        var app = builder.Build();

        await app.MigrateDatabaseAsync();

        if (app.Environment.IsDevelopment())
        {
            await app.SeedDevDatabaseAsync();
            app.MapDefaultHealthChecks();
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.UseFastEndpoints(opt =>
        {
            opt.Endpoints.RoutePrefix = "api";
        });

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        //app.MapAdditionalIdentityEndpoints();

        await app.RunAsync();
    }
}
