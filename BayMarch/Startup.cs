using BayMarch.Data;
using BayMarch.Dto;
using BayMarch.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog;
using BayMarch.Models;

namespace BayMarch
{

    public class Startup
    {
        string conName;
        public IConfiguration Configuration { get; }

        //private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            conName = Configuration["PolicyString:name"];
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnString")));


            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy(conName, policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            //Services
            services.AddScoped<IBaseInterface<Models.Type>, TypeService>();
            services.AddScoped<IBaseInterface<Seller>, SellerService>();
            services.AddScoped<IBaseInterface<ParentCategory>, ParentCategoryService>();
            services.AddScoped<IBaseInterface<Category>, CategoryService>();
            services.AddScoped<IBaseInterface<Product>, ProductService>();
            services.AddScoped<IBaseInterface<Supplier>, SupplierService>();
            services.AddScoped<IBaseInterface<Uom>, UomService>();
            services.AddScoped<IBaseInterface<Customer>, CustomerService>();
            services.AddScoped<IBaseInterface<Payment>, PaymentService>();

            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IOrderService, OrderService>();                       
            services.AddScoped<IStockTakeService, StockTakeService>();            
            services.AddScoped<IReportService, ReportService>();



            services.AddControllers().AddNewtonsoftJson(options =>  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                        

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            // app.UseCookiePolicy();

            //app.UseSerilogRequestLogging();

            app.UseRouting();
            // app.UseRequestLocalization();
            app.UseCors(conName);

            app.UseAuthentication();
            app.UseAuthorization();
            // app.UseSession();
            // app.UseResponseCompression();
            // app.UseResponseCaching();


            /*app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!");});
                //endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });*/


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
