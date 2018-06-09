using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Resmap.API.Data;
using Resmap.API.Models;
using Resmap.API.Services;
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

            #region Idetity configuration
            // AddIdentity adds cookie based authentication
            // Adds scoped classes for things like UserManager, SignInManager, PasswordHashers etc..
            // NOTE: Automatically adds the validated user from a cookie to the HttpContext.User
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                // Adds UserStore and RoleStore from this context
                // That are consumed by the UserManager and RoleManager
                .AddEntityFrameworkStores<ApplicationDbContext>()
                // Adds a provider that generates unique keys and hashes for things
                // forgot password links, phone number verification codes etc...
                .AddDefaultTokenProviders();          

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // Change logint URL
            services.ConfigureApplicationCookie(options =>
            {
                // Redirect to /login
                options.LoginPath = "/login";

                // Change cookie timeout to expire in 15 seconds
                options.ExpireTimeSpan = TimeSpan.FromSeconds(15);
            });


            #endregion

            // Add JWT Authentication for api clients
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                    };
                });
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
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
            });

            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseMvc();        


        }
    }
}
