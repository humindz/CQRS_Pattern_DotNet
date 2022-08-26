using Application;
using ApplicationWithMediatR;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApplicationWithAkka;
using InfrastructureWithAkka;
using InfrastructureWithAkka.SignalR;

namespace CQRSArchitecture
{
    public class Startup
    {
        private const string PolicyName = "CQRSArchitecture";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpContextAccessor();
            services.AddInfrastructureWithAkkaModule();

            services.AddInfrastructureModule();
            services.AddApplicationModule();
            services.AddApplicationWithMediatRModule();
            services.AddApplicationWithAkkaModule();

            services.AddSwaggerDocument(configure => configure.Title = "CQRS Architecture Demo API");

            //===================================Setting up CORS=======================================
            services.AddCors(options =>
            {
                options.AddPolicy(name: PolicyName,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            //=========================================================================================

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ResultHub>("/query-result");
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
