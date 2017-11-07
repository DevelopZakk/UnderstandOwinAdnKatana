using Owin;

namespace UnderstandOwinAndKatana
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {

            app.Use(async (ctx,next) =>
            {
                await ctx.Response.WriteAsync($"<html><body><h1>Hello World</h1></body></html>");
            });
        }

    }
}