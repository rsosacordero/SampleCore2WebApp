using AutoMapper;
using Correlate.AspNetCore;
using Correlate.DependencyInjection;
using EF_WWT.Data;
using EF_WWT.Domain;
using EF_WWT.Filters;
using EF_WWT.Mappers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace EF_WWT
{
    public class Startup
    {
        private readonly ApiConfig _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ApiConfig(env.EnvironmentName);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(opts => opts.Filters.Add<WWTExceptionFilter>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            //Add correlation ID 
            services.AddCorrelate(options =>
            {
                options.RequestHeaders = new[]
                {
                  "X-Correlation-ID",
                  "My-Correlation-ID"
                };
                options.IncludeInResponse = true;
            });

            //Add EF core
            services.AddDbContext<EFWWTContext>((opts) => opts.UseSqlServer(_configuration.EFWWTConnectionString), ServiceLifetime.Transient);

            //register Automapper + Mediatr + ... 
            var currentAssembly = typeof(Startup).GetTypeInfo().Assembly;
            //auto-register all MediatR classes. Otherwise we'd need to register them manually
            services.AddMediatR(currentAssembly);
            //Automapper dependencies
            services.AddAutoMapper(currentAssembly);

            //register all other mappers
            services.AddTransient<IMapper<List<GetContactByName>, List<Contact>>, ContactProfileMapper>();
            services.AddTransient<IMapper<List<GetEmailAddressByName>, List<Contact>>, EmailProfileMapper>();
            services.AddTransient<IWWTExceptionHandler, WWTExceptionHandler>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCorrelate();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
