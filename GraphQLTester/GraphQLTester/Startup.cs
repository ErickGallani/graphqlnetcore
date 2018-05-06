namespace GraphQLTester
{
    using GraphQLTester.Data;
    using GraphQLTester.Data.Repositories;
    using GraphQLTester.Data.SeedData;
    using GraphQLTester.Data.Specs;
    using GraphQLTester.Queries;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

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
            services.AddMvc();

            services.AddTransient<StudentQuery>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddDbContext<GraphQLTesterContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                              ILoggerFactory loggerFactory, GraphQLTesterContext db)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            db.SeedData();
        }
    }
}
