﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
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

            services.AddScoped<DbContext, DAL.Contexts.DbSuppliesContext>();
            services.AddScoped<Domain.Contracts.Repositories.DB.ISuppliesbUnitOfWork, DAL.UnitOfWorks.SuppliesUnitOfWork>();
            services.AddScoped<Domain.Contracts.Repositories.DB.IEqupmentTypesRepository, DAL.Repositories.EquipmentTypesRepository>();
            services.AddScoped<Domain.Contracts.Repositories.DB.INotificationQueueRepository, DAL.Repositories.NotificationQueueRepository>();
            services.AddScoped<Domain.Contracts.Repositories.DB.IProvidersRepository, DAL.Repositories.ProvidersRepository>();
            services.AddScoped<Domain.Contracts.Repositories.DB.ISuppliesRepository, DAL.Repositories.SuppliesRepository>();

            services.AddScoped<Domain.Contracts.Repositories.IConfigRepository, Services.ConfigurationRepository>();
            services.AddScoped<Domain.Contracts.Services.INotificationSender, Services.NotificationSender>();

            services.AddScoped<Domain.Contracts.Services.INotificationWorkerService, Domain.Imp.Services.NotificationWorkerService>();
            services.AddScoped<Domain.Contracts.Services.ISupplyService, Domain.Imp.Services.SuppliesService>();
            services.AddScoped<Domain.Contracts.Services.IProviderService, Domain.Imp.Services.ProviderService>();
            services.AddScoped<Domain.Contracts.Services.IEquipmentTypeService, Domain.Imp.Services.EquipmentTypeService>();

            using (var context = services.BuildServiceProvider().GetService<DAL.Contexts.DbSuppliesContext>()) {
                context.Database.Migrate();
            }



            //Настройка нативного хоста
            //services.AddHostedService<Domain.Contracts.Services.INotificationWorkerService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);


            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".woff"] = "application/font-woff";
            provider.Mappings[".html"] = "html";
           

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(rootPath),
                //RequestPath = new PathString($"/index.html"),
                ContentTypeProvider = provider
            });
        }
    }
}
