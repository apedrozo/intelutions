//---------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API
{
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using Intelutions.Permissions.API.Contracts.Requests;
    using Intelutions.Permissions.API.Contracts.Validators;
    using Intelutions.Permissions.API.Utils;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string origin = Configuration["Origins:WebApp:Url"];

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins(origin)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services
                .AddCustomDbContext(Configuration)
                .AddControllers();

            services
                .AddMvc()
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
                .AddFluentValidation();

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IValidator<PermissionRequest>, PermissionRequestValidator>();
            services.AddTransient<IValidator<PermissionTypeRequest>, PermissionTypeRequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
