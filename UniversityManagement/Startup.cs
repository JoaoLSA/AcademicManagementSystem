using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.Models;
using CoreProject.Repositories;
using CoreProject.RequestHandlers;
using DataProject;
using DataProject.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UniversityManagement
{
    public class Startup
    {
        private static readonly Type repoType = typeof(Repository<,>);
        private static readonly Type entityType = typeof(BaseEntity);
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AcademicContext>(options => options.UseSqlite("Data Source=university.db"));

            services.AddMediatR(typeof(ListStudentsQueryHandler));

            var specificRepos = entityType.Assembly
                  .ExportedTypes
                  .Where(t => t.IsClass && !t.IsAbstract && entityType.IsAssignableFrom(t))
                  .Select(oneEntityType =>
                  {
                      var implementationType = repoType.MakeGenericType(oneEntityType, typeof(AcademicContext));
                      var interfaceType = typeof(IRepository<>).MakeGenericType(oneEntityType);
                      return (interfaceType, implementationType);
                  });

            foreach (var (interfaceType, implementationType) in specificRepos)
                services.AddScoped(interfaceType, implementationType);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
