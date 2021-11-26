using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using HotChocolate.Types;
using SEP3T2GraphQL.Graphql;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Repositories.Impl;
using SEP3T2GraphQL.Services;
using SEP3T2GraphQL.Services.Impl;
using SEP3T2GraphQL.Services.Validation;
using SEP3T2GraphQL.Services.Validation.HostValidation;
using SEP3T2GraphQL.Services.Validation.HostValidation.Impl;
using SEP3T2GraphQL.Services.Validation.ResidenceValidation;

namespace SEP3T2GraphQL
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
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<ListType>()
                .AddMutationType<Mutation>().ModifyRequestOptions(opt => opt.IncludeExceptionDetails =true);
            services.AddScoped<IResidenceRepository, ResidenceRepositoryImpl>();
            services.AddScoped<IResidenceService, ResidenceServiceImpl>();
            services.AddScoped<IResidenceValidation, ResidenceValidationImpl>();
            services.AddScoped<IHostRepository, HostRepositoryImpl>();
            services.AddScoped<IHostService, HostServiceImpl>();
            services.AddScoped<IHostValidation, HostValidationImpl>();
            services.AddScoped<IGuestService, GuestServiceImpl>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<IRentRequestRepository, RentRequestRepository>();
            services.AddScoped<CreateRentRequestValidator>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IRuleService, RuleService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            // app.UseGraphQLGraphiQL(new GraphiQLOptions()
            // {
            //     GraphQLEndPoint = "/graphql"
            // }, "/graphql-ui");

            app.UseGraphQLPlayground(new PlaygroundOptions()
            {
                GraphQLEndPoint = "/graphql"
            },"/graphql-ui" );
        }
    }
}