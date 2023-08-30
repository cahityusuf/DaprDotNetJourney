using DaprDotNetJourney.Framework.Dapr.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DaprDotNetJourney.Framework.Dapr.Extensions
{
    public static class DaprServiceCollectionExtensions
    {
        public static void AddConfigureStateStore(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDaprStateStore>(sp => new DaprStateStore(sp.GetRequiredService<ILogger<DaprStateStore>>()));
        }

    }
}
