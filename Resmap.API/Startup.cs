using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resmap.API.Models;
using Resmap.Data;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Text;

namespace Resmap.API
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
            // enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddMvc();

            // Add ApplicationDB context to DI
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRelationService, RelationService>();
            services.AddScoped<IEventService, EventService>();
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
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            // configure automapper
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
                cfg.CreateMap<Relation, RelationDto>();
                
                cfg.CreateMap<RelationForCreationDto, Relation>();
                cfg.CreateMap<EmployeeForCreationDto, Employee>();
                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<NoteDto, Note>();
                cfg.CreateMap<Event, EventDto>()
                    .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.From.ToShortDateString()))
                    .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.Till.ToShortDateString()))
                    .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => src.EmployeeId));
            });

            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseMvc();        


        }
    }
}
