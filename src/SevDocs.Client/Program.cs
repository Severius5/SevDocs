using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SevDocs.Client.Extensions;
using SevDocs.Client.Providers;

namespace SevDocs.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddFluentValidators();
        builder.Services.AddMudServices();
        builder.Services.AddScoped<ApiClient>();
        builder.Services.AddHttpClient<ApiClient>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        });

        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();

        await builder.Build().RunAsync();
    }
}
