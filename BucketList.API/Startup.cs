using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketList.API.CustomMiddlewares;
using BucketList.API.Helpers;
using BucketList.Common.StaticConstants;
using BucketList.Entity.DataAccess;
using BucketList.Entity.Model.Auth;
using BucketList.Repository.UnitOfWorkAndBaseRepo;
using BucketList.Service.Configurations;
using BucketList.Service.Implementation;
using BucketList.Service.Implementation.BucketItemService;
using BucketList.Service.Interfaces;
using BucketList.Service.Interfaces.BucketItemInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace BucketList.API
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
            //read from configuration file
            ReadConfigSettings();
            ReadConfigMessages();
         
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(Configuration);

            services.AddDbContext<BLDbContext>(options =>
                options.UseSqlServer(Constants.BLConnectionString));
            
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
                .AddEntityFrameworkStores<BLDbContext>()
                .AddDefaultTokenProviders();

            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

               })
               .AddJwtBearer(cfg =>
               {

                   cfg.RequireHttpsMetadata = false;
                   cfg.SaveToken = true;
                   cfg.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidIssuer = Constants.TokenIssuer,
                       ValidAudience =Constants.TokenAudience,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.TokenSecretKey)),
                       ClockSkew = TimeSpan.Zero, // remove delay of token when expire
                        ValidateLifetime = true
                   };
               });

       
             
            services.AddMvc();
            //####################service injections##############################
            services.AddTransient<IDemoService, DemoService>();
            services.AddTransient<IBucketItemService, BucketItemService>();

            //####################Repository injections##############################
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<BLDbContext>();
            //###################Swagger#####################
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.0",
                    Title = "Demo Architecture API",
                });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",

                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            MapperConfig.Configure();

            if (env.IsDevelopment())
            {
                //###################Swagger#####################
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Architecture API");
                    c.DocExpansion(DocExpansion.None);
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        private void ReadConfigSettings()
        {
            Constants.BLConnectionString = Configuration["App:BLConnectionString"];
            Constants.TokenIssuer = Configuration["App:TokenIssuer"];
            Constants.TokenAudience = Configuration["App:TokenAudience"];
            Constants.TokenExpiryDays = Convert.ToInt32(Configuration["App:TokenExpiryDays"]);
            Constants.TokenSecretKey = Configuration["App:TokenSecretKey"];

        }
        private void ReadConfigMessages()
        {
            //##################################### Shared ####################################################
            //############################ Error Messages ############################################
            
            BLMessages.GenralException = Configuration["Messages:GenralException"];
            BLMessages.RecordNotFound = Configuration["Messages:RecordNotFound"];
            BLMessages.SavedSuccessfully = Configuration["Messages:SavedSuccessfully"];
            BLMessages.UpdatedSuccessfully = Configuration["Messages:UpdatedSuccessfully"];
            BLMessages.DeletedSuccessfully = Configuration["Messages:DeletedSuccessfully"];
            BLMessages.VerificationRequired = Configuration["Messages:VerificationRequired"];
            BLMessages.RegistrationRequired = Configuration["Messages:RegistrationRequired"];
            BLMessages.RecordAlreadyExists = Configuration["Messages:RecordAlreadyExists"];
            BLMessages.DateGreaterThanNowError = Configuration["Messages:DateGreaterThanNowError"];
            BLMessages.OperationSuccessful = Configuration["Messages:OperationSuccessful"];            
            BLMessages.AccountNotExist = Configuration["Messages:AccountNotExist"];
            BLMessages.InvalidUserNamePassword = Configuration["Messages:InvalidUserNamePassword"];
            BLMessages.AccountAlreadyExist = Configuration["Messages:AccountAlreadyExist"];
            BLMessages.InvalidToken = Configuration["Messages:InvalidToken"];
            BLMessages.EmailAlreadyVerified = Configuration["Messages:EmailAlreadyVerified"];
            BLMessages.AccountBlocked = Configuration["Messages:AccountBlocked"] + BLMessages.SupportEmail;
            BLMessages.EmailAccountExist = Configuration["Messages:EmailAccountExist"];
            BLMessages.AccessDenied = Configuration["Messages:AccessDenied"];
            BLMessages.InvalidPassword = Configuration["Messages:InvalidPassword"];
           
           
            //########################### Success Messages ###########################################
       
 
        }
    }
}
