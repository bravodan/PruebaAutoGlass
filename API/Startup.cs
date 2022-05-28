using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using MediatR;
using DataAccess.Repositories;
using DataAccess;
using Domain.UnitOfWork;
using System.Reflection;
using AutoMapper;
using API.Validators;
using FluentValidation.AspNetCore;

namespace API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            #region NewtonSoft
            services.AddControllers().AddNewtonsoftJson();
            #endregion

            #region FluentValidation
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            #endregion

            #region Cors
            services.AddCors(options =>
            {
                options.AddPolicy("EnabledCORS",
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .WithMethods("PUT", "DELETE", "GET", "POST")
                        .WithHeaders("*");
                    });
            });
            #endregion

            #region Nugget packages
            services.AddMediatR(Assembly.Load("Services"));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Validators
            services.AddTransient<ProductItemCreateValidator>();
            services.AddTransient<ProductItemUpdateValidator>();
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IProductItemRepository, ProductItemRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion


            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("database"));
                opts.EnableSensitiveDataLogging();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
