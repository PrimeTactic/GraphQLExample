using Data.Core.Service;
using Data.GraphQL.Schema;
using Data.GraphQL.Type;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleGraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Register services
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IDeviceService, DeviceService>();
            services.AddSingleton<IDeviceEventService, DeviceEventService>();

            // Register GraphQL Types
            services.AddSingleton<DeviceType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<DeviceStatusEnum>();
            services.AddSingleton<DeviceEventType>();
            services.AddSingleton<RegisterDeviceInputType>();
            services.AddSingleton<Query>();
            services.AddSingleton<Mutation>();
            services.AddSingleton<Subscription>();
            services.AddSingleton<Schema>();

            // Make all the types we registered available to GraphQL.Net
            services.AddSingleton<IDependencyResolver>(c =>
                new FuncDependencyResolver(c.GetRequiredService));

            services.AddGraphQL().AddWebSockets();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles(); // for index.html
            app.UseStaticFiles(); // for serving the static files for GraphiQL
            app.UseWebSockets();
            app.UseGraphQLWebSockets<Schema>();
            app.UseGraphQL<Schema>();
        }
    }
}
