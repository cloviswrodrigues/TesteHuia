using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


namespace HuiaTeste
{
    public class Startup
    {
       // public Startup(IConfiguration )
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DAL.Context.MyDbContext>(options => options.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbHuiaTeste;Data Source=DESKTOP-505QC65\\SQLEXPRESS"));
            //services.AddDbContext<DAL.Context.MyDbContext>(options => options.UseSqlServer(Configuration.Get));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => {

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("API Huia Teste");
                });

                endpoints.MapControllers();
            });
        }
    }
}
