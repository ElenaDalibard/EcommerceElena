using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GestionProduitPanier_AspNET.Interface;
using GestionProduitPanier_AspNET.Services;
using GestionProduitPanier_AspNET.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GestionProduitPanier_AspNET
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
            services.AddControllersWithViews();

            // --- Ajouter une session ---
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(3);
            });

            // --- Ajouter un service ---
            //services.AddTransient<IUpload, UploadService>();
            //services.AddSingleton<IUpload, UploadService>();
            services.AddScoped<IUpload, UploadService>();
            services.AddScoped<IDisplayer, DisplayService>();
            services.AddScoped<ITranslate, TranslateService>();
            services.AddSingleton<ISaveErreurs, SaveErreurs>();
            services.AddScoped<IHash, HashService>();
            services.AddHttpContextAccessor();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ConnectUser", policy =>
                {
                    policy.Requirements.Add(new ConnectionRequirement());
                });
                options.AddPolicy("ConnectAdmin", policy =>
                {
                    policy.Requirements.Add(new ConnectionRequirement("admin"));
                });
            });
            services.AddScoped<IAuthorizationHandler, ConnectionHandler>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Utilisateur/SignInLogInForm");
                options.AccessDeniedPath = new PathString("/Utilisateur/AccesDenied");
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Produit}/{action=Acceuil}/{id?}/{qty?}");
            });
        }
    }
}
