using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProductService.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Student");
            config.MapODataServiceRoute(
                routeName: "student",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
