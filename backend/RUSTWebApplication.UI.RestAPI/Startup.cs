using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RUSTWebApplication.Core.Authentication;
using RUSTWebApplication.Infrastructure;

namespace RUSTWebApplication.UI.RestAPI
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

			services.AddTransient<IDbInitializer, DbInitializer>();
			services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder
						.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()
					);
			});
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseCors("AllowSpecificOrigin");

			if (env.IsDevelopment())
            {
				using (var scope = app.ApplicationServices.CreateScope())
				{
					RUSTWebApplicationContext context = scope.ServiceProvider.GetService<RUSTWebApplicationContext>();
					IDbInitializer dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
					dbInitializer.Seed(context);
				}
				app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
        }
    }
}
