using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Repositories;

namespace MovieShopMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }  // IConfiguration help us to get data from appsettings.json

        // This method gets called by the runtime. Use this method to add services to the container.
        // .NET Core has built in DI support (Important point of Diff of new .NET Core vs old version .NET framework)
        // old .NET Framework did not had built-in DI
        // we used with 3rd party libraries, Autofac, Ninject
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddScoped<IMovieService, MovieNoSQLService>();
            services.AddScoped<IMovieService, MovieService>();   // we can inject NoSqlService or SqlService here   // controller需要呼叫service
            services.AddScoped<IMovieRepository, MovieRepository>(); // Inject MovieRepository in IMovieRepository  // service需要呼叫repository

            services.AddDbContext<MovieShopDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MovieShopDbConnection")));
        }
        // 3 scopes
        // AddScoped
        // AddTransient
        // AddSingleton



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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
