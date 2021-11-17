using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEP3BlazorT1Client.Authentication;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Data.Impl;
using SEP3BlazorT1Client.Pages.RegisterResidence;
using SEP3BlazorT1Client.ViewModels;

namespace SEP3BlazorT1Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMatBlazor();
            services.AddScoped<MatDialogService>();
            services.AddScoped<IResidenceService, GraphQlResidenceService>();
            services.AddScoped<IHostService, GraphQlHostService>();
            services.AddScoped<IGuestRegistrationRequestService, GraphQlAdministrationService>();
            services.AddScoped<IHostRegistrationRequestService, GraphQlAdministrationService>();
            services.AddScoped<RegisterResidenceViewModel>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}