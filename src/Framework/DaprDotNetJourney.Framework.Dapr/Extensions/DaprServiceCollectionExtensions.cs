using DaprDotNetJourney.Framework.Dapr.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DaprDotNetJourney.Framework.Dapr.Extensions;

public static class DaprServiceCollectionExtensions
{
    public static void ConfigureStateStore(this IServiceCollection services)
    {
        services.AddScoped<IDaprStateStore>(sp => new DaprStateStore(sp.GetRequiredService<ILogger<DaprStateStore>>()));
    }

}
