using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Data.Contracts;
using Projeto.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Services
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Configuração Injeção de dependência

            var connectionString = Configuration.GetConnectionString("Aula21");

            services.AddTransient<IFornecedorRepository, FornecedorRepository>
                (map => new FornecedorRepository(connectionString));

            services.AddTransient<IProdutoRepository, ProdutoRepository>
                (map => new ProdutoRepository(connectionString));
            #endregion

            #region Configuração Swagger

            services.AddSwaggerGen(swagger => 
            { swagger.SwaggerDoc("v1", new Info
            { Title = "API de controle de Produtos e Fornecedores",
                Version = "v1", Description = "Projeto desenvolvido em Asp.Net CORE" }); });
            #endregion

            #region Configuração AutoMapper

            services.AddAutoMapper(typeof(Startup));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Configuração Swagger

            app.UseSwagger(); app.UseSwaggerUI(swagger => 
            { swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto"); });
            #endregion

            app.UseMvc();
        }
    }
}
