using Agenda.Aplicacao.Instrutores.Profiles;
using Agenda.Aplicacao.Instrutores.Servicos;
using Agenda.Dominio.Instrutores.Servicos;
using Agenda.Infra.Instrutores.Mapeamentos;
using Agenda.Infra.Instrutores.Repositorios;
using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Libraries.Aplicacao.Transacoes.Interfaces;
using Libraries.Core.Api.Filters;
using Libraries.Core.Api.Swagger;
using Libraries.NHibernate.Transacoes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NHibernate;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Agenda.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc(config => { config.Filters.Add<ExcecaoFilter>(); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Agenda",
                    Version = "v1",
                    Description = "API de controle de requisições para o site Agenda CEC"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<DefaultOperationFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                c.UseInlineDefinitionsForEnums();
            });

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddSingleton<ISessionFactory>(factory =>
            {
                return Fluently.Configure().Database(() =>
                    {
                        string connection = Configuration.GetConnectionString("MySql");
                        return FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
                            .FormatSql()
                            .ShowSql()
                            .ConnectionString(connection);
                    })
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<InstrutorMap>())
                    .CurrentSessionContext("call")
                    .BuildSessionFactory();
            });

            services.AddScoped<ISession>(factory => { return factory.GetService<ISessionFactory>().OpenSession(); });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(InstrutoresProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan
                .FromAssemblyOf<InstrutorAppServico>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            services.Scan(scan => scan
                .FromAssemblyOf<InstrutorServico>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            services.Scan(scan => scan
                .FromAssemblyOf<InstrutorRepositorio>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "Agenda.API-" + env.EnvironmentName);
                    c.DisplayRequestDuration();
                });
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}