using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;  
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
//using Sample.Core.Identity.Data.DbContexts;
//using Sample.Core.Identity.Data.Enities;

namespace MM.DataServices
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
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("MailOrigin",
                    builder => builder.AllowAnyOrigin ()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials());
                options.AddPolicy("AllowAll",
                                  builder => builder.WithOrigins("http://localhost:4200","mail.marcman.xyz","http://mail.marcman.xyz")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials());
            });

            #region Add Authentication 

            // Authentication

            var sharedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Jwt:Key"]));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                //options.Authority = "http://localhost:54470/136544d9-038e-4646-afff-10accb370679";
                //options.Audience = "257b6c36-1168-4aac-be93-6f2cd81cec43";
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters.ValidateLifetime = true;
                options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(5);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Specify the key used to sign the token:
                    IssuerSigningKey = sharedKey,
                    RequireSignedTokens = true,
                    // Other options...
                    ValidAudience = this.Configuration["Jwt:Issuer"],
                    ValidateIssuer = false,
                    ValidIssuer = this.Configuration["Jwt:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            #endregion

            #region Authorization
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("SurveyCreator", p =>
                {
                    // Using value text for demo show, else use enum : ClaimTypes.Role
                    p.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "SurveyCreator");
                });

            });



            #endregion

            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MarcMan LG API",
                    Description="RESTful API web service for the LinkedGlobe (LG) social networking application.",
                    Version = "v1" });

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "MM.DataServices.xml");
                c.IncludeXmlComments(filePath);
            });

            // var connection = @"Server=asus;database=DB_9B0E5C_linkedglobe;Trusted_Connection=True;ConnectRetryCount=0";
            // services.AddDbContext<DB_9B0E5C_linkedglobeContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/lg-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll"); //default

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

             //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
             //specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarcMan LG API V1");
            });

            app.UseMvc();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "lg/index.html"));
            });

        }
    }
}
