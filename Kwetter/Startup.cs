using Kwetter.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http.Cors;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(Kwetter.Startup))]
namespace Kwetter
{
    public class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(120),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthAuthorizationServer(OAuthOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }

        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
           
        }
    }
}