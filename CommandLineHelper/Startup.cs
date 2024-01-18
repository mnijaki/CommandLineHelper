using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommandLineHelper
{
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
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		/// <summary>
		///   This method gets called by the runtime.
		///   Use this method to configure the HTTP request pipeline.
		///   Add middleware that will be used by your application here.
		///   Add code here that will be responsible for setting up the HTTP request pipeline.
		///   Request pipeline is made up of multiple middleware components.
		///   Each middleware component is responsible for performing a specific function.
		///   The order in which the middleware components are added in this method is important.
		///   Each middleware may or may not pass the request to the next middleware component in the pipeline.
		///   If it does not pass the request to the next middleware component, then it is responsible for generating the response for the request.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}