using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;


[assembly: OwinStartup(typeof(UI.WEB.Startup))]
namespace UI.WEB
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType =
DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/account/login"),
                    LogoutPath = new PathString("/account/logout")


                });



        }


    }
}