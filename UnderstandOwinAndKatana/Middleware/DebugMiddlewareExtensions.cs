﻿using Owin;
using UnderstandOwinAndKatana.Middleware;

namespace Owin 
{
    public static class DebugMiddlewareExtensions
    {
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options==null) options = new DebugMiddlewareOptions();

            app.Use<DebugMiddleware>(options);
        }
    }
}