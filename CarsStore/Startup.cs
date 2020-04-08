using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsStore.Data;
using CarsStore.Data.Repository;
using CarsStore.Interfaces;
using CarsStore.Mocks;
using CarsStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarsStore
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CarsStoreContext>(options => options.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<IAllCategories, CategoryRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();
            services.AddTransient<IAllUsers, UserRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddControllersWithViews(mvcOptions => { mvcOptions.EnableEndpointRouting = false; })
                .AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddMemoryCache();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseAuthorization();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Authorization}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                CarsStoreContext content = scope.ServiceProvider.GetRequiredService<CarsStoreContext>();
                DbObjects.Initialize(content);
            }
        }
    }
}
