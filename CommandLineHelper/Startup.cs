namespace CommandLineHelper
{
	using System;
	using Data;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Newtonsoft.Json.Serialization;

	public class Startup
	{
		public IConfiguration Configuration { get; }
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		///   This method gets called by the runtime.
		///   Use this method to add services to the container.
		///   Add services that will be used by your application here.
		///   You can treat this method as a dependency injection container (similar to Zenject in Unity).
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			// Possible service injection types:
			// Singleton: A single instance of the service will be created.
			// Scoped: A new instance of the service will be created once per request.
			// Transient: A new instance of the service will be created every time it is requested.
			
			
			services.AddAuthorization();
			services.AddRazorPages();
			services.AddScoped<IRepo, SqlRepo>();
			services.AddDbContext<Ctx>(ConfigureDbContextOptions);
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddControllers().AddNewtonsoftJson(ConfigureNewtonsoftJSONOptions);
		}

		private void ConfigureDbContextOptions(DbContextOptionsBuilder options)
		{
			// Depending on the SQL provider this syntax can change.
			// options.Use_SqlProvider(params_needed_to_connect_to_DB)
			// Usually can be received from "appsettings.json" -> "CommandLineHelperConnection" field.
			options.UseSqlServer(Configuration.GetConnectionString("CommandLineHelperConnection"));
		}

		private static void ConfigureNewtonsoftJSONOptions(MvcNewtonsoftJsonOptions option)
		{
			// Newtonsoft JSON serializer is used for JSON serialization of requests.
			// Makes JSON response properties camelCase.
			option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}

		/// <summary>
		///   This method gets called by the runtime.
		///   Use this method to configure the HTTP request pipeline.
		///   Add middleware that will be used by your application here.
		///   Request pipeline is made up of multiple middleware components.
		///   Each middleware component is responsible for performing a specific function.
		///   The order in which the middleware components are added in this method is important.
		///   Each middleware may or may not pass the request to the next middleware component in the pipeline.
		///   If it does not pass the request to the next middleware component, then it is responsible for generating the response for the request.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
			});
		}
	}
}