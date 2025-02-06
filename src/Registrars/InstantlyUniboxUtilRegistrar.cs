using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Instantly.Client.Registrars;
using Soenneker.Instantly.Unibox.Abstract;

namespace Soenneker.Instantly.Unibox.Registrars;

/// <summary>
/// A .NET typesafe implementation of Instantly's Unibox API
/// </summary>
public static class InstantlyUniboxUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IInstantlyUniboxUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddInstantlyUniboxUtilAsSingleton(this IServiceCollection services)
    {
        services.AddInstantlyClientAsSingleton()
                .TryAddSingleton<IInstantlyUniboxUtil, InstantlyUniboxUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IInstantlyUniboxUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddInstantlyUniboxUtilAsScoped(this IServiceCollection services)
    {
        services.AddInstantlyClientAsScoped()
                .TryAddScoped<IInstantlyUniboxUtil, InstantlyUniboxUtil>();

        return services;
    }
}