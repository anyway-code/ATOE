using ATOEBackend.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ATOEBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Permit all access to OData endpoint
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Enable all query types
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Project>("Projects");
            builder.EntitySet<Resource>("Resources");
            builder.EntitySet<ResourceUsage>("ResourceUsages");

            config.MapODataServiceRoute(routeName: "ODataRoute", routePrefix: "api", model: builder.GetEdmModel());
        }
    }
}
