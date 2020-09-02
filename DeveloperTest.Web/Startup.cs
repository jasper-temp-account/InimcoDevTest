using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TextUtilLib;
using TextUtilLib.NameReverser;

namespace DeveloperTest.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Policy defined above. Allow requests from other origins as I host my Angular app on another port in development.
            // Obviously not in production :)
            app.UseCors("AllowAll");

            app.UseRouting();

            // Simple endpoints to expose TextUtilLib's functionality to the Angular app
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("");
                });

                endpoints.MapGet("/api/vowels/{name}", async context => {
                    string name = (string)context.Request.RouteValues["name"];
                    ICharacterCounter characterCounter = new NaiveCharacterCounter();
                    await context.Response.WriteAsync(characterCounter.GetAmountOfVowels(name).ToString());
                });

                endpoints.MapGet("/api/consonants/{name}", async context => {
                    string name = (string)context.Request.RouteValues["name"];
                    ICharacterCounter characterCounter = new LinqCharacterCounter();
                    await context.Response.WriteAsync(characterCounter.GetAmountOfConsonants(name).ToString());
                });

                endpoints.MapGet("/api/reverse/{name}", async context =>
                {
                    string name = (string)context.Request.RouteValues["name"];
                    INameReverser nameReverser = new NaiveNameReverser();
                    await context.Response.WriteAsync(nameReverser.Reverse(name));
                });
            });
        }
    }
}
