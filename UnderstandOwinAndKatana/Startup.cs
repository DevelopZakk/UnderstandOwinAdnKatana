using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using Microsoft.Owin.Security.Cookies;
using Nancy;
using Nancy.Owin;
using Owin;
using UnderstandOwinAndKatana.Middleware;

namespace UnderstandOwinAndKatana
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            //app.Use<DebugMiddleware>(new DebugMiddlewareOptions());
            app.UseDebugMiddleware(new DebugMiddlewareOptions());

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/Login/Auth")
            });

            app.Use(async (ctx, next) =>
            {
                if (ctx.Authentication.User.Identity.IsAuthenticated)
                { Debug.WriteLine("User:" + ctx.Authentication.User.Identity.Name);}
                await next();

            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            //app.UseNancy();

            app.Map("/nancy", mapapp => { mapapp.UseNancy(); });

            //app.UseNancy(conf =>
            //{
            //    conf.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
            //});

            //app.Use(async (ctx,next) =>
            //{
            //    Debug.WriteLine("Incoming Request 2module:" + ctx.Request.Path);
            //    await ctx.Response.WriteAsync($"<html><body><h1>Hello World</h1></body></html>");
            //    Debug.WriteLine("Outgoingcoming Request 2module:" + ctx.Request.Path);
            //});
        }

    }
}