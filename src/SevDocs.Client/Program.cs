using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SevDocs.Client.Extensions;

namespace SevDocs.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddSharedServices();
        builder.Services.AddFluentValidators();

        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();

        await builder.Build().RunAsync();
    }
}
