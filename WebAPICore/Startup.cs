using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebAPICore.Api.JsonSettings;
using WebAPICore.DbModels;
using WebAPICore.Identity;
using WebAPICore.Permisions;
using WebAPICore.Services;

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

            services.AddTransient<SubjectService>();
            services.AddTransient<StudentService>();
            services.AddTransient<ProfessorService>();
            services.AddTransient<CourseService>();
            services.AddTransient<AdminService>();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
