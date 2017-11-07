using System;
using System.Diagnostics;
using Microsoft.Owin;

namespace UnderstandOwinAndKatana.Middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }

        public Action<IOwinContext> OnOutgoingReqeust { get; set; }

        public DebugMiddlewareOptions()
        {
            OnIncomingRequest = (ctx) =>
            {
                Debug.WriteLine("Incoming Request:" + ctx.Request.Path);
                Stopwatch watch = new Stopwatch();
                watch.Start();
                ctx.Environment["watch"] = watch;
            };


            OnOutgoingReqeust = (ctx) =>
            {
                Debug.WriteLine("Outogint Request:" + ctx.Request.Path);
                var watch = (Stopwatch) ctx.Environment["watch"];
                watch.Stop();
                Debug.WriteLine($"Time: {watch.ElapsedMilliseconds}ms");
            };
        }
    }
}