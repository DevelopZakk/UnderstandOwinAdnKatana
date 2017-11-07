using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using Owin;

namespace UnderstandOwinAndKatana
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Debug.WriteLine("Incoming Request:" +ctx.Request.Path);
                await next();
                Debug.WriteLine("Outogint Request:" + ctx.Request.Path);
            });
            app.Use(async (ctx,next) =>
            {
                Debug.WriteLine("Incoming Request 2module:" + ctx.Request.Path);
                await ctx.Response.WriteAsync($"<html><body><h1>Hello World</h1></body></html>");
                Debug.WriteLine("Outgoingcoming Request 2module:" + ctx.Request.Path);
            });
        }

    }
}