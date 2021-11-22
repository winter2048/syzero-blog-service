using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SyZero;
using SyZero.AspNetCore;
using SyZero.AutoMapper;
using SyZero.Log4Net;
using SyZero.Redis;
using SyZero.Web.Common;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using SyZero.Blog.Repository;
using SyZero.DynamicWebApi;
using SyZero.Consul;
using SyZero.Feign;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Xml.XPath;
using SyZero.Blog.Web.Authentication;

namespace SyZero.Blog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            AppConfig.Configuration = configuration;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //var nacosOptions = AppConfig.GetSection<NacosServiceOptions>("Nacos");
            //services.AddNacosAspNetCore(serverConf =>
            //{
            //    // serverConf.ServerAddresses = new List<string>() { "http://192.168.10.135:5000" };
            //    serverConf.ServiceName = AppConfig.ServerOptions.Name;
            //    serverConf.Weight = 100;
            //    serverConf.DefaultTimeOut = 15000;
            //    serverConf.LBStrategy = "WeightRandom";
            //    // serverConf.Port = AppConfig.ServerOptions.Port.ToInt32();
            //    // serverConf.Ip = AppConfig.ServerOptions.Ip;
            //}, nacosConf =>
            //{
            //    nacosConf.DefaultTimeOut = 8;
            //    nacosConf.ServerAddresses = nacosOptions.NacosAddresses;
            //    nacosConf.Namespace = "";
            //    nacosConf.ListenInterval = 1000;
            //    nacosConf.UserName = "nacos";
            //    nacosConf.Password = "nacos";
            //    nacosConf.EndPoint = "sub-domain.aliyun.com:8080";
            //});


            // services.AddNacosAspNetCore(Configuration);

            services.AddControllers().AddMvcOptions(options =>
            {
                options.Filters.Add(new AppVerificationFilter());
                options.Filters.Add(new AppExceptionFilter());
                options.Filters.Add(new AppResultFilter());
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new LongToStrConverter());
            });

            //动态WebApi
            services.AddDynamicWebApi(new DynamicWebApiOptions()
            {
                DefaultApiPrefix = "/api",
                DefaultAreaName = AppConfig.ServerOptions.Name
            });
            services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder =>
            {
                builder.AllowAnyMethod()
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            //Swagger
            services.AddSwagger();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //使用AutoMapper
            builder.RegisterModule<AutoMapperModule>();
            //使用SqlSugar仓储
            builder.RegisterModule<BlogRepositoryModule>();
            //使用SyZero
            builder.RegisterModule<SyZeroModule>();
            //注入控制器
            builder.RegisterModule<SyZeroControllerModule>();
            //注入Log4Net
            builder.RegisterModule<Log4NetModule>();
            //注入Redis
            builder.RegisterModule<RedisModule>();
            //注入公共层
            builder.RegisterModule<CommonModule>();

            builder.RegisterModule<FeignModule>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSyZero();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SyZero.Blog.Web API V1");
                c.RoutePrefix = "api/swagger";

            });

            app.UseConsul();
          
        }
    }
}



