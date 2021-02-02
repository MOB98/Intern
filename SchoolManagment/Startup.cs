using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEMO.Data;
using DEMO.Models;
using Microsoft.AspNet.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using DEMO.Resources;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace DEMO
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
            //services.AddDefaultIdentity<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultUI()
            //.AddDefaultTokenProviders();
            services.AddDbContext<DEMOContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<DEMOContext>()
                 .AddDefaultTokenProviders();


            services.AddSingleton<LocService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assemblyName.Name);
                    };
                });

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                        {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar")
                    
                        };

                    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;

                    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
                });


            //services.AddLocalization(options => options.ResourcesPath = "Resources");

            //services.AddMvc()
            //        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //        .AddDataAnnotationsLocalization();

            //services.AddControllersWithViews();

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    var supportedCultures = new[] { "en", "ar" };
            //    options.SetDefaultCulture(supportedCultures[0])
            //        .AddSupportedCultures(supportedCultures)
            //        .AddSupportedUICultures(supportedCultures);
            //});
            services.AddRazorPages();

            //services.AddAuthorization(options => {
            //    options.AddPolicy("readpolicy",
            //        builder => builder.RequireRole("Admin", "Teacher", "Student"));
            //    options.AddPolicy("writepolicy",
            //        builder => builder.RequireRole("Admin"));
            //});

            services.AddMvc();
           
            //   services.AddScoped<ISchoolManagmentRepository<Student>, StudentDbRepository>();

            services.AddControllers();
         
        //    services.AddDbContext<SchoolAPIContext>(options =>
        //            options.UseSqlServer(Configuration.GetConnectionString("SchoolAPIContext")));
        
        //services.AddDbContext<SchoolManagmentDbContext>(opt => opt.UseSqlServer
        //       (Configuration.GetConnectionString("SchoolConnection")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

             
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();

            //var supportedCultures = new[] { "en", "ar" };

            //var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            //    .AddSupportedCultures(supportedCultures)
            //    .AddSupportedUICultures(supportedCultures);

            //app.UseRequestLocalization(localizationOptions);
            app.UseRouting();
            
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Students}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

            });

            //CreateUserRoles(services).Wait();
        }
    }
}
