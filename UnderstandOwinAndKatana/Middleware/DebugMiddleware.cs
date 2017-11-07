using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace UnderstandOwinAndKatana.Middleware
{
    public class DebugMiddleware
    {
        private readonly AppFunc _next;
        private readonly DebugMiddlewareOptions _options;

        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);
            //Debug.WriteLine("Incoming Request:" + ctx.Request.Path);
            _options.OnIncomingRequest(ctx);
            await _next(environment);
            //Debug.WriteLine("Outogint Request:" + ctx.Request.Path);
            _options.OnOutgoingReqeust(ctx);
        }
    }
}