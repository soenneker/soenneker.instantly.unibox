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
    public static void AddInstantlyUniboxUtilAsSingleton(this IServiceCollection services)
    {
        services.AddInstantlyClientAsSingleton();
        services.TryAddSingleton<IInstantlyUniboxUtil, InstantlyUniboxUtil>();
    }

    /// <summary>
    /// Adds <see cref="IInstantlyUniboxUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddInstantlyUniboxUtilAsScoped(this IServiceCollection services)
    {
        services.AddInstantlyClientAsScoped();
        services.TryAddScoped<IInstantlyUniboxUtil, InstantlyUniboxUtil>();
    }
}
