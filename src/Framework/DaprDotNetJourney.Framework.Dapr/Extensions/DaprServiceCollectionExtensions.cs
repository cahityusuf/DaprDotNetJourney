using Microsoft.AspNetCore.Builder;

namespace DaprDotNetJourney.Framework.Dapr.Extensions
{
    public static class DaprServiceCollectionExtensions
    {
        public static void ConfigureStateStore(this WebApplicationBuilder builder)
        {
            //services.AddScoped<IDaprStateStore>(sp => new DaprStateStore(sp.GetRequiredService<ILogger<DaprStateStore>>()));
        }

    }
}
