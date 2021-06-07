using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ERP_API.Services.Interfaces;
using ERP_API.Services.Implementations;
using ERP_API.Repositories.Interfaces;
using ERP_API.Repositories.Implementations;
using AutoMapper;
using ERP_API.Mappings;
using ERP_API.Models;

namespace ERP_API
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddControllers();

            services.AddDbContext<interworksDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP_API", Version = "v1" });
            });
            services.AddSingleton(mapper);

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDiscountsService, DiscountsService>();
            services.AddScoped<ISubscriptionsService, SubscriptionsService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDiscountsRepository, DiscountsRepository>();
            services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
