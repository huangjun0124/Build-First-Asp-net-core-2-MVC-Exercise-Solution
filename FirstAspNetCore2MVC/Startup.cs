using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspNetCore2MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstAspNetCore2MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get;  }

        public Startup(IConfiguration configure)
        {
            Configuration = configure;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // add support for mvc
            services.AddMvc();

            /*
            Transient objects are always different; a new instance is provided to every controller and every service；
            Scoped objects are the same within a request, but different across different requests；
            Singleton objects are the same for every object and every request(regardless of whether an instance is provided in ConfigureServices)
            */
            //services.AddTransient<IPieRepository, MockPieRepository>();

            // use ef core
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPieRepository, PieDbRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //this makes sure when something goes wrong in our application, we get an error
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            // go and search static files(image, css, js, html, etc) in wwwroot folder by default and return
            app.UseStaticFiles();
            // maps to {controller=Home}/{action=index}/{id?}
            //app.UseMvcWithDefaultRoute();
            // Remember the sequence in which you add these components matters

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
