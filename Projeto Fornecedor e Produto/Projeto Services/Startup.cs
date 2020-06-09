﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Data.Contracts;
using Projeto.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto_Services
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            #region Configuração para Injeção de Dependencia

            var connectionString = Configuration.GetConnectionString("Aula21");

            services.AddTransient<IFornecedorRepository, FornecedorRepository>(map => new FornecedorRepository(connectionString));

            services.AddTransient<IProdutoRepository, ProdutoRepository>(map => new ProdutoRepository(connectionString));
            #endregion

            #region Configuração Swagger

            services.AddSwaggerGen(swagger => 
            { swagger.SwaggerDoc("v1", new Info
            { Title = "API de controle de Produtos e Fornecedores",
                Version = "v1", Description = "Projeto desenvolvido em Asp.Net CORE" }); });


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
