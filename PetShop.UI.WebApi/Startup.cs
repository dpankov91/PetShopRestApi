using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PetShop.Core.ApplicationService.Services.Implementation;
using PetShop.Infastructure.Static.Data.Repositories;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using Newtonsoft.Json;
using PetShop.Infastructure.Static.Data;

namespace PetShop.UI.WebApi
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
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            services.AddScoped<ITypePetService, TypePetService>();
             services.AddScoped<ITypePetRepository, TypePetRepository>();

            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
            }

            using(var scope = app.ApplicationServices.CreateScope())
            {
                var petService = scope.ServiceProvider.GetRequiredService<IPetService>();
                var ownerService = scope.ServiceProvider.GetRequiredService<IOwnerService>();
                var typeService  = scope.ServiceProvider.GetRequiredService<ITypePetService>();
                var dataInitializer = new DataInitializer(petService, ownerService, typeService);
                dataInitializer.InitOwner();
                dataInitializer.InitTypePet();
                dataInitializer.InitPet();
            }

            app.UseDeveloperExceptionPage();

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
