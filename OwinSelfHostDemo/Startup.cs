using System.Runtime.InteropServices.ComTypes;
using Owin;

namespace OwinSelfHostDemo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.UseStaticFiles();

            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("Hello World");
            });
        }

    }
}