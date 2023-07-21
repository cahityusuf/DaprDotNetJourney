using DaprDotNetJourney.Framework.Api.Extensions;
using DaprDotNetJourney.Microservices.Basket.Abstraction.Services;
using DaprDotNetJourney.Microservices.Basket.Application.Services;

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

            return builder;
        }

        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBasketService, BasketService>();

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
