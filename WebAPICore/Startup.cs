using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using WebAPICore.Api.JsonSettings;
using DBCommunication.DbModels;
using DBCommunication.Identity;
using DBCommunication.Permisions;
using DBCommunication.Services;

namespace WebAPICore
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
            services
                .AddDbContext<APICoreDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("APICoreDB"));
                }, ServiceLifetime.Scoped);

            services
                .AddDbContext<APICoreIdentityDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("APICoreDB"));
                }, ServiceLifetime.Scoped);

            services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<APICoreIdentityDbContext>();

            services.AddControllers();

            services.AddHttpClient();
            services.AddDbContext<APICoreDBContext>(options =>
            options.UseSqlServer(Configuration["DbConnection"]));

            services.AddScoped<SubjectService>();
            services.AddScoped<StudentService>();
            services.AddScoped<ProfessorService>();
            services.AddScoped<CourseService>();
            services.AddScoped<AdminService>();
            services.AddScoped<AccountService>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<TokenService>();
            services.AddScoped<UserDataService>();

            var clientSecret = Configuration
                .GetSection("JwtClientSecretJsonSettings")
                .Get<JwtClientSecretJsonSettings>()
                .ClientSecret;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(clientSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                options.Validate();
            });

            services.AddAuthorization(options =>
            {
                foreach (var claim in ApiClaims.All)
                {
                    options.AddPolicy(claim, policy => policy.RequireClaim("Permission", claim));
                }
            });

            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Description = "Swagger" });

                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(endpoint =>
            {
                endpoint.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api");
            });

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
