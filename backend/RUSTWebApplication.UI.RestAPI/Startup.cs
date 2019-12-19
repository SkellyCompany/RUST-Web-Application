using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RUSTWebApplication.Infrastructure;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Authentication;
using RUSTWebApplication.Core.ApplicationService;
using RUSTWebApplication.Infrastructure.Repositories;
using RUSTWebApplication.Core.ApplicationService.Services;

namespace RUSTWebApplication.UI.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			Byte[] secretBytes = new byte[40];
			Random rand = new Random();
			rand.NextBytes(secretBytes);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = false,
					ValidateIssuer = false,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
					ValidateLifetime = true,
					ClockSkew = TimeSpan.FromMinutes(5)
				};
			});

			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder
						.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
					);
			});

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<RUSTWebApplicationContext>(opt => {
                    opt.UseSqlite("Data Source=RUSTWebapp.db");
                }
                );
            }
            else
            {
                services.AddDbContext<RUSTWebApplicationContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

            services.AddTransient<IDbInitializer, DbInitializer>();
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductMetricService, ProductMetricService>();
            services.AddScoped<IProductMetricRepository, ProductMetricRepository>();
            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();

            services.AddScoped<IProductModelService, ProductModelService>();
            services.AddScoped<IProductModelRepository, ProductModelRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductStockService, ProductStockService>();
            services.AddScoped<IProductStockRepository, ProductStockRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			if (env.IsDevelopment())
            {
				using (var scope = app.ApplicationServices.CreateScope())
				{
					RUSTWebApplicationContext context = scope.ServiceProvider.GetService<RUSTWebApplicationContext>();
					IDbInitializer dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    dbInitializer.SeedInMemory(context);
                    
                }
				app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    RUSTWebApplicationContext context = scope.ServiceProvider.GetService<RUSTWebApplicationContext>();
                    IDbInitializer dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
                    context.Database.EnsureCreated();
                //    dbInitializer.SeedAzure(context);
                }
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
        }
    }
}
