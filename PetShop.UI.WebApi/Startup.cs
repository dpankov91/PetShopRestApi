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
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using Newtonsoft.Json;
using PetShop.Infastructure.Static.Data;
using PetShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PetShop.Infrastructure.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PetShop.Core.Security;
using PetShop.Infrastructure.Data.SecurityImplemintation;

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
            #region DbContext
            services.AddDbContext<PetAppDBContext>(
                opt =>
                {
                    opt.UseSqlite("Data Source=petapp.db");
                });
            #endregion
            #region Authentication

            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);
                
            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
            // Register the AuthenticationHelper in the helpers folder for dependency
            // injection. It must be registered as a singleton service. The AuthenticationHelper
            // is instantiated with a parameter. The parameter is the previously created
            // "secretBytes" array, which is used to generate a key for signing JWT tokens,
            services.AddSingleton<IAuthenticationHelper>(new
                AuthenticationHelper(secretBytes));
            #endregion
            #region Scope
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetSQLRepository>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerSQLRepository>();

            services.AddScoped<ITypePetService, TypePetService>();
            services.AddScoped<ITypePetRepository, TypePetSQLRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserSQLRepository>();
            #endregion
            #region CORS
            services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder.AllowAnyOrigin()
                                                                                               .AllowAnyMethod()
                                                                                               .AllowAnyHeader()));
            #endregion
            #region Ignore Loops
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            #endregion
            #region Swagger
            services.AddSwaggerGen();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                #region Scoping
                using (var scope = app.ApplicationServices.CreateScope())
                {

                    var ctx = scope.ServiceProvider.GetService<PetAppDBContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();

                    var petRepository = scope.ServiceProvider.GetRequiredService<IPetRepository>();
                    var ownerRepository = scope.ServiceProvider.GetRequiredService<IOwnerRepository>();
                    var typeRepository = scope.ServiceProvider.GetRequiredService<ITypePetRepository>();
                    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                    var authenticationHelper = scope.ServiceProvider.GetRequiredService<IAuthenticationHelper>();
                    var dataInitializer = new DataInitializer(petRepository, ownerRepository, typeRepository, userRepository, authenticationHelper);

                    dataInitializer.InitData();
                }
                #endregion
                #region Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
                #endregion
                app.UseCors("AllowEverything");

                app.UseAuthentication();

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
}
