using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EquipmentSupply.API
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
            
            services.AddDbContext<EquipmentSupply.DAL.Contexts.DbSuppliesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SuppliesContext")));
            

            services.AddScoped<Domain.Contracts.Services.ISupplyService, Domain.Imp.Services.SuppliesService>();
            services.AddScoped<Domain.Contracts.Repositories.DB.ISuppliesbUnitOfWork, DAL.UnitOfWorks.SuppliesUnitOfWork>();
            services.AddScoped<Domain.Contracts.Repositories.DB.IEqupmentTypesRepository, DAL.Repositories.EquipmentTypesRepository>();
            services.AddScoped<Domain.Contracts.Repositories.DB.INotificationQueueRepository, DAL.Repositories.NotificationQueueRepository>();
            services.AddScoped<Domain.Contracts.Repositories.DB.IProvidersRepository, DAL.Repositories.ProvidersRepository>();
            services.AddScoped<Domain.Contracts.Repositories.DB.ISuppliesRepository, DAL.Repositories.SuppliesRepository>();
            services.AddScoped<Domain.Contracts.Services.INotificationWorkerService, Domain.Imp.Services.NotificationWorkerService>();
            services.AddScoped<Domain.Contracts.Repositories.IConfigRepository,>();

            //Настройка нативного хоста
            //services.AddHostedService<TimedHostedService<IImportPaymentsService>>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider("wwwroot"),
                //RequestPath = new PathString($"/{fileStoragePath}"),
                //ContentTypeProvider = provider
            });
        }
    }
}
