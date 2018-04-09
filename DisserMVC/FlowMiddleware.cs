using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisserMVC
{
    public class FlowMiddleware
    {
        private readonly RequestDelegate _next;

        public FlowMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    await _next.Invoke(context);5
        //    var resp = context.Response;
        //}

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            var resp = context.Response;
        }

    }
}
