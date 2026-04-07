using FluentValidation;
using SevDocs.Shared;

namespace SevDocs.Client.Extensions
{
    public static class IServiceExtensions
    {
        internal static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            var validatorTypes = typeof(SharedMarker).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new { Type = t, Interfaces = t.GetInterfaces() })
                .SelectMany(x => x.Interfaces
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>))
                    .Select(i => new { Interface = i, Implementation = x.Type }))
                .ToList();

            foreach (var v in validatorTypes)
                services.AddSingleton(v.Interface, v.Implementation);

            return services;
        }
    }
}
