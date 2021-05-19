﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using OrderManagementSystem.API.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.API.Core.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IdentityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IIdentityService _identityService;

        public IdentityMiddleware(RequestDelegate next, IIdentityService identityService)
        {
            _next = next;
            _identityService = identityService;
        }

        public Task Invoke(HttpContext httpContext)
        {
            this._identityService.User = httpContext.User;
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IdentityMiddleware>();
        }
    }
}
