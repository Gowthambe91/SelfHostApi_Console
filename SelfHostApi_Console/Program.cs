using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHostApi_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:58710/");

            config.Routes.MapHttpRoute("default",
                                "api/{controller}/{id}",
                                new { controller = "Home", id = RouteParameter.Optional });

            var server = new HttpSelfHostServer(config);

            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine("Web API Server has started at http://localhost:58710");
            Console.ReadLine();
        }
    }
}
