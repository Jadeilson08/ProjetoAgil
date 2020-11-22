using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebAPI.Repositories.Interface;
using WebAPI.Repositories;
using WebAPI.Services.Interface;
using WebAPI.UnitOfWork.Interface;
using WebAPI.UnitOfWork;
using WebAPI.Facades.Interface;
using WebAPI.Facades;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Poco;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // using Microsoft.EntityFrameworkCore;
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtPoco>(Configuration.GetSection("Authentication:Jwt"));

            ConfigureAuthenticationSettings(services);

            Services(services);
            Repositories(services);
            UnitOfWork(services);
            Facades(services);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:53135",
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions() 
            { 
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Repository
        public void Repositories(IServiceCollection services)
        {
            services.AddTransient<IEventoRepository, EnventoRepository>();
        }
        #endregion
        
        #region Services
        public void Services(IServiceCollection services)
        {
            services.AddTransient<IEventoService, EventoService>();
            services.AddTransient<IAuthService, AuthService>();
        }
        #endregion

        #region UnitOfWork
        public void UnitOfWork(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitofWork>();
        }
        #endregion

        #region Facades
        public void Facades(IServiceCollection services)
        {
            services.AddTransient<IEventosFacade, EventosFacade>();
            services.AddTransient<IAuthFacade, AuthFacade>();
        }
        #endregion


        #region Configure Auth
        private void ConfigureAuthenticationSettings(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Authentication:Jwt:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
        #endregion
    }
}
