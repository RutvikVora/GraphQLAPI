using GraphQLAPI.GraphQLCore;
using GraphQLAPI.GraphQLCore.Book;
using GraphQLAPI.GraphQLCore.Category;
using GraphQLAPI.GraphQLCore.Directives;
using GraphQLAPI.GraphQLCore.Publisher;
using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLAPI
{
    public class Startup
    {
        private readonly string AllowedOrigin = "allowedOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("GraphQLDBConnection")));

            services.AddInMemorySubscriptions();

            services.AddGraphQLServer()
                .AddAuthorization()
                .AddQueryType<Query>()
                .AddTypeExtension<BookQuery>()
                .AddTypeExtension<CategoryQuery>()
                .AddTypeExtension<PublisherQuery>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<BookMutation>()
                .AddTypeExtension<CategoryMutation>()
                .AddTypeExtension<PublisherMutation>()
                .AddDirectiveType<TimeStampDirective>()
                .AddDirectiveType<UpperCaseDirective>()
                .AddDirectiveType<LowerCaseDirective>();

            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<CategoryRepository, CategoryRepository>();
            services.AddScoped<PublisherRepository, PublisherRepository>();

            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://localhost:44300";
                        options.Audience = "graphQLApi";
                    });

            services.AddCors(option => {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(AllowedOrigin);
            app.UseWebSockets();
            app.UseAuthentication();
            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
        }
    }
}
