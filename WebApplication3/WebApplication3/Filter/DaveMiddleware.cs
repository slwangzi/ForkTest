using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Filter
{
    public class DaveMiddleware
    {
        private readonly RequestDelegate next;
        public DaveMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await  context.Response.WriteAsync("hello ");
            await next(context);
            await context.Response.WriteAsync("world!");
        }
    }
}
