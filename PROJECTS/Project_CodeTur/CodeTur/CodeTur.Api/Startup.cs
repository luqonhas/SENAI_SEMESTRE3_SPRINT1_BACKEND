using CodeTur.Domain.Handlers.Autentication;
using CodeTur.Domain.Handlers.Pacotes;
using CodeTur.Domain.Handlers.Usuarios;
using CodeTur.Domain.Interfaces;
using CodeTur.Domain.Repositories;
using CodeTur.Infra.Data.Contexts;
using CodeTur.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTur.Api
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

            // adiciona a política CORS ao projeto
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeTur.Api", Version = "v1" });
            });

            // banco de dados
            // DefaultConnection = localizado no development.json
            services.AddDbContext<CodeTurContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddAuthentication(options =>
                {
                    // definiu a forma de autenticação
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // valida tudo que colocamos no Controller
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("codetur-chave-autenticacao")),
                        ClockSkew = TimeSpan.FromMinutes(30),
                        ValidIssuer = "codetur",
                        ValidAudience = "codetur"
                    };
                });

            // injeções de dependência
            #region Usuarios
                services.AddTransient<IUsuarioRepository, UsuarioRepository>();
                services.AddTransient<CriarContaHandler, CriarContaHandler>();
                services.AddTransient<LogarHandler, LogarHandler>();
            #endregion

            #region Pacotes
                services.AddTransient<IPacoteRepository, PacoteRepository>();
                services.AddTransient<CriarPacoteHandler, CriarPacoteHandler>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeTur.Api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            // habilita o CORS
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
