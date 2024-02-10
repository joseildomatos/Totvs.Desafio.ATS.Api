using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;
using Totvs.Desafio.ATS.Aplicacao;
using Totvs.Desafio.ATS.Infraestrutura;
using Totvs.Desafio.ATS.WebApi.ErroMiddleware;

namespace Totvs.Desafio.ATS.WebApi
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var serviceCollection = InjecaoDependencia.ConfigureServices();
            //foreach (var service in serviceCollection)
            //{
            //    services.Add(service);
            //}

            // Add services to the container.
            //services.Configure<MongoDbConfiguracoes>(Configuration.GetSection("MongoDbConfiguracoes"));
            //services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddSingleton(serviceProvider =>
            {
                var mongoClient = new MongoClient(Configuration["MongoDbConfiguracoes:ConnectionString"]);
                return mongoClient.GetDatabase("Totvs");
            });
            services.AddHttpContextAccessor();

            services.RegistrarAplicacaoServices();
            services.RegistrarInfrastructureServices();
            services.AddControllers().AddFluentValidation(config =>
                                    {
                                        config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                                    });
            //services.AddControllers();

            //services.AddApiVersioningWithApiExplorer(1, 0);
            services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "Totvs.Desafio.ATS.WebApi", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerGenOptions.IncludeXmlComments(xmlPath);


                //swaggerGenOptions.OrderActionsBy(apiDescription =>
                //    $"{new SwaggerControllerDisplayOrderAction<ControllerBase>(Assembly.GetEntryAssembly()!)
                //        .SortKey(apiDescription.ActionDescriptor.RouteValues["controller"])}");


            });
            //    .AddOptions<OpenApiOptions>().Configure((openApiOptions) =>
            //{
            //    openApiOptions.Title = "Totvs.Desafio.ATS.WebApi";
            //    openApiOptions.Description = "Api do Totvs.Desafio";
            //});
        }

        //services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Totvs.Desafio.ATS.WebApi", Version = "v1" });
        //    });
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Totvs.Desafio.ATS.WebApi"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ErroMiddleware.ErroMiddleware));
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}