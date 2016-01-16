using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RestApp.App_Start;

[assembly: OwinStartup(typeof(RestApp.Startup))]
namespace RestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {           
            HttpConfiguration config = new HttpConfiguration();            
            WebApiConfig.Register(config);
            Swashbuckle.Bootstrapper.Init(config);

            ConfigureAuth(app);
            app.UseWebApi(config);
        }
    }
}