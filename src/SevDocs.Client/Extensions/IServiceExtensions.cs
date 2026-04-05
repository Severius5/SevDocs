using FluentValidation;
using MudBlazor.Services;
using SevDocs.Shared;

namespace SevDocs.Client.Extensions
{
    public static class IServiceExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddMudServices();

            return services;
        }

        internal static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            // todo: ai generated, test
            var validatorTypes = typeof(SharedMarker).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new { Type = t, Interfaces = t.GetInterfaces() })
                .SelectMany(x => x.Interfaces
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>))
                    .Select(i => new { Interface = i, Implementation = x.Type }))
                .ToList();

            foreach (var v in validatorTypes)
            {
                services.AddSingleton(v.Interface, v.Implementation);
            }

            return services;
        }
    }
}
