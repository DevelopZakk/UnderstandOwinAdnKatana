using Nancy;
using Nancy.Owin;
using Nancy.Security;

namespace UnderstandOwinAndKatana.Modules
{
    public class NancyDemoModule:NancyModule
    {
        public NancyDemoModule()
        {

            this.RequiresMSOwinAuthentication();

            Get["/nancy"] = x =>
            {
                var env = Context.GetOwinEnvironment();
                var user = Context.GetMSOwinUser();
                return "Hello from nancy! Your request: " + env["owin.RequestPathBase"] +env["owin.RequestPath"] + "User:"+user.Identity.Name;
            };
        }
    }
}