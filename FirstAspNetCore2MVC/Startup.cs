using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FirstAspNetCore2MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // add support for mvc
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //this makes sure when something goes wrong in our application, we get an error
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            // go and search static files(image, css, js, html, etc) in wwwroot folder by default and return
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            // Remember the sequence in which you add these components matters
        }
    }
}
