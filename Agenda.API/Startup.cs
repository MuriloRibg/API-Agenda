using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Agenda.Aplicacao.Instrutores.Profiles;
using Agenda.Aplicacao.Instrutores.Servicos;
using Agenda.Aplicacao.Instrutores.Servicos.Interfaces;
using Agenda.Dominio.Instrutores.Repositorios;
using Agenda.Dominio.Instrutores.Servicos;
using Agenda.Dominio.Instrutores.Servicos.Interfaces;
using Agenda.Infra.Instrutores.Mapeamentos;
using Agenda.Infra.Instrutores.Repositorios;
using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Core.Api.Filters;
using Libraries.NHibernate.Transacoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NHibernate;

namespace Agenda.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc(config => 
            {
                config.Filters.Add<ExcecaoFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSingleton<ISessionFactory>(factory =>
            {
                string connection = configuration.GetConnectionString("MySql");

                ISessionFactory sessionFactory = Fluently.Configure().Database(
                    MySQLConfiguration.Standard
                        .FormatSql()
                        .ShowSql()
                        .ConnectionString(connection)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<InstrutorMap>())
                .CurrentSessionContext("call")
                .BuildSessionFactory();

                return sessionFactory;
            });

            services.AddScoped<ISession>(factory =>
            {
                return factory.GetService<ISessionFactory>().OpenSession();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInstrutorAppServico, InstrutorAppServico>();
            services.AddScoped<IInstrutorServico, InstrutorServico>();
            services.AddScoped<IInstrutoresRepositorio, InstrutorRepositorio>();

            services.AddAutoMapper(typeof(InstrutoresProfile).GetTypeInfo().Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agenda.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agenda.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
