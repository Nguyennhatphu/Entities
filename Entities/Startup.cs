using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Helper;
using Entities.LoggerService;
using Entities.Models;
using Entities.Repositories;
using Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;

namespace Entities
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IDataShaper<Owner>, DataShaper<Owner>>();
			services.AddScoped<IDataShaper<Account>, DataShaper<Account>>();
			services.AddScoped<ISortHelper<Owner>, SortHelper<Owner>>();
			services.AddScoped<ISortHelper<Account>, SortHelper<Account>>();
			services.AddAutoMapper(typeof(Startup));
			services.AddSingleton<ILoggerManager, LoggerManager>();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddDbContext<RepositoryContext>(options =>
			options.UseSqlServer(
				Configuration.GetConnectionString("EntitiesContext")));
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
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
