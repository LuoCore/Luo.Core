﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luo.Core.Utility.ApplicationExtend
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;
        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }
            await _next(context);
        }
        // 使用 app.UseMiddleware<CorsMiddleware>();
    }
}
