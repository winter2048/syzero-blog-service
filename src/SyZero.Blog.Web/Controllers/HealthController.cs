
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using SyZero;
using SyZero.AspNetCore.Controllers;
using SyZero.Configurations;
using SyZero.Serialization;

namespace SyZero.Blog.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : SyZeroController
    {
        private readonly IConfiguration _configuration;
        public IJsonSerialize jsonSerialize { get; set; }

        public HealthController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //_configuration.Reload();
            //Console.WriteLine(jsonSerialize.ObjectToJSON(AppConfig.Configuration.GetSection("App2").GetChildren()));
            //Console.WriteLine(jsonSerialize.ObjectToJSON(_configuration.GetSection("App2").GetChildren()));
            Console.WriteLine($"Consul健康检查: " + DateTime.Now.ToString());
            return Ok();//只是个200 
        }


        [HttpGet("test")]
        public async Task<string> test()
        {
            string json = "";
            if (Cache.Exist("Health/test"))
            {
                json = Cache.Get<string>("Health/test");
            }
            else
            {
                json = jsonSerialize.ObjectToJSON(_configuration.GetSection("App2").GetChildren());
                await Cache.SetAsync("Health/test", json);
            }
            Console.WriteLine(json);
            return json;
        }
    }
}



