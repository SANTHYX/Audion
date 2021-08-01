using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VueCliMiddleware;
using Web.Extensions;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSpaStaticFiles(spa => spa.RootPath = "ClientApp");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
            }

            app.UseRouting();

            app.UseStaticFiles();

            if (env.IsProduction())
            {
                app.UseSpaStaticFiles();
            }

            app.UseExceptionMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy(
                "{*path}",
                 new SpaOptions { SourcePath = "ClientApp"},
                        port: 8080,
                        npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                        regex: "Compiled successfully",
                        forceKill: true,
                        wsl: false
                    );
                }
            });
        }
    }
}
