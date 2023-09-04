using DaprDotNetJourney.Framework.Api.Extensions;
using DaprDotNetJourney.Framework.Dapr.Extensions;
using System.Reflection;

namespace DaprDotNetJourney.Microservices.Basket.Api
{
    public static class ProgramExtensions
    {
        public static WebApplicationBuilder AddBasketApi(
            this WebApplicationBuilder builder)
        {
            builder.AddCustomSwagger();
            builder.AddCustomMvc();
            builder.AddCustomAuthentication();
            builder.AddCustomApplicationServices();
            builder.AddConfigureStateStore();
            return builder;
        }

        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            var Assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                   .Where(filePath => Path.GetFileName(filePath).StartsWith("DaprDotNetJourney.Microservices.Basket"))
                   .Select(Assembly.LoadFrom);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assemblies.ToArray());
            });
        }

        public static WebApplication UseBasketApi(this WebApplication app)
        {
            app.UseCustomSwagger();
            app.UseCloudEvents();
            app.UseCustomAuthentication();
            app.UseCors("CorsPolicy");
            app.UseCustomRoute();
            app.MapSubscribeHandler();

            return app;
        }
    }
}
