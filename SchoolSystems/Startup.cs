using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolSystems.Models;
using SchoolSystems.Models.Data;
using SchoolSystems.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSystems
{
    public class Startup
    {
        public IConfiguration Configration { get; }

        public Startup(IConfiguration _Configration)
        {
            Configration = _Configration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(Configration.GetConnectionString("SqlCon"));
            });
            services.AddMvc(x => x.EnableEndpointRouting = false);
            //services.AddSingleton<IRepository<Books>, BooksRepository>();
            //services.AddSingleton<IRepository<Branch>, BranchRepository>();
            //services.AddSingleton<IRepository<Issues>, IssuesRepository>();
            //services.AddSingleton<IRepository<Login>, LoginRepository>();
            //services.AddSingleton<IRepository<Permission>, PermissionRepository>();
            //services.AddSingleton<IRepository<Roles>, RolesRepository>();
            //services.AddSingleton<IRepository<Student>, StudentRepository>();
            //services.AddSingleton<IRepository<User>, UserRepository>();

            services.AddScoped<IRepository<Books>, DbBooksRepository>();
            services.AddScoped<IRepository<Branch>, DbBranchRepository>();
            services.AddScoped<IRepository<Issues>, DbIssuesRepository>();
            services.AddScoped<IRepository<Login>, DbLoginRepository>();
            services.AddScoped<IRepository<Permission>, DbPermissionRepository>();
            services.AddScoped<IRepository<Roles>, DbRolesRepository>();
            services.AddScoped<IRepository<Student>, DbStudentRepository>();
            services.AddScoped<IRepository<User>, DbUserRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Books}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
