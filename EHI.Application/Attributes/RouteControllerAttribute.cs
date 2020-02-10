using Microsoft.AspNetCore.Mvc;
using System;

namespace EHI.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class RouteControllerAttribute : RouteAttribute
    {
        public RouteControllerAttribute() : base("api/[controller]/[action]")
        {
        }
    }
}
