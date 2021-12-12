using MatBlazor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEP3BlazorT1Client.Authentication;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Data.Impl;

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
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<IGuestService, GraphQlGuestService>();
            services.AddScoped<IFacilityService, GraphQlFacilityService>();
            services.AddScoped<IRuleService, GraphQlRuleService>();
            services.AddScoped<IAdministrationService, GraphQlAdministrationService>();
            services.AddScoped<IRentalService, GraphQlRentalService>();
            services.AddScoped<IUserService, GraphQlUserService>();
            services.AddScoped<IGuestReviewService, GraphQlGuestReviewService>();
            services.AddScoped<IHostReviewService, GraphQlHostReviewService>();
            services.AddScoped<IResidenceReviewService, GraphQlResidenceReviewService>();
            
            //TODO add policies here:
            services.AddAuthorization(options =>
                {
                    options.AddPolicy("MustBeAdmin", apb => 
                        apb.RequireAuthenticatedUser().RequireClaim("Role" ,"Admin"));
                    options.AddPolicy("MustBeGuest", abp => abp.RequireAuthenticatedUser().RequireClaim("Role", "Guest", "Admin"));
                    options.AddPolicy("MustBeHost", abp => abp.RequireAuthenticatedUser().RequireClaim("Role", "Host", "Guest", "Admin"));
                    options.AddPolicy("MustBeApprovedHost", abd => abd.RequireAuthenticatedUser().RequireClaim("Approved", "Host", "Guest"));
                    options.AddPolicy("MustBeApprovedGuest", abd => abd.RequireAuthenticatedUser().RequireClaim("Approved", "Guest"));
                }
            );
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