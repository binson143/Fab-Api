using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fab.Api.Infra;
using Fab.Api.Services;
using Fab.Api.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fab.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddTransient<ILoanService, LoanService>();
            services.AddDbContext<FabContext>(opt => opt.UseInMemoryDatabase("fab"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
           
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            var parent=System.IO.File.ReadAllText($"Data{Path.DirectorySeparatorChar}parent.json");
            Seeder.SeedParent(parent,app.ApplicationServices);
            
            var child=System.IO.File.ReadAllText($"Data{Path.DirectorySeparatorChar}child.json");
            Seeder.SeedChild(child,app.ApplicationServices);
        }
    }
}