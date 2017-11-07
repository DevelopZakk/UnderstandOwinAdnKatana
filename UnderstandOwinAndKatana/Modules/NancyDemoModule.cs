using Nancy;
using Nancy.Owin;

namespace UnderstandOwinAndKatana.Modules
{
    public class NancyDemoModule:NancyModule
    {
        public NancyDemoModule()
        {
            Get["/nancy"] = x =>
            {
                var env = Context.GetOwinEnvironment();
                return "Hello from nancy! Your request: " + env["owin.RequestPathBase"] +env["owin.RequestPath"];
            };
        }
    }
}