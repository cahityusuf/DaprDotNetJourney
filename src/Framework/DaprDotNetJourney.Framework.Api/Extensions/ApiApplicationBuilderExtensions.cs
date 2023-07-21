using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace DaprDotNetJourney.Framework.Api.Extensions
{
    public static class ApiApplicationBuilderExtensions
    {
        public static void UseCustomSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{app.Configuration.GetValue<string>("OpenApi:Title")} V1");
                c.OAuthClientId("basketswaggerui");
                c.OAuthAppName("Basket Swagger UI");
            });
        }

        public static void UseCustomAuthentication(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public static void UseCustomRoute(this WebApplication app)
        {
            app.UseCloudEvents();
            app.MapDefaultControllerRoute();
            app.MapControllers();
        }
    }
}
