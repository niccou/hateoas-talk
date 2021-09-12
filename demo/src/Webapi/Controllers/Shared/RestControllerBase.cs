using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WebApi.Models.Shared;

namespace WebApi.Controllers.Shared
{
    [ApiController]
    public class RestControllerBase : ControllerBase
    {
        private readonly IReadOnlyCollection<ActionDescriptor> _routes;

        protected RestControllerBase(IActionDescriptorCollectionProvider provider)
        {
            _routes = provider.ActionDescriptors.Items;
        }

        protected Link UrlLink(string relation, string routeName, dynamic? values = null)
        {
            var route = Route(routeName);

            if (route is null)
            {
                return new Link();
            }

            var method = Method(route);

            if (method is null)
            {
                return new Link();
            }

            var version = GetApiVersion(route);

            if (!string.IsNullOrEmpty(version))
            {
                values ??= new ExpandoObject();
                values.Version = version;
            }

            var url = Url.Link(routeName, values);

            if (url is null)
            {
                return new Link();
            }

            return new Link
            {
                Href = url,
                Rel = relation,
                Type = method
            };
        }

        private ActionDescriptor? Route(string routeName) =>
            _routes.FirstOrDefault(_ => _.AttributeRouteInfo?.Name.Equals(routeName) ?? false);

        private string? Method(ActionDescriptor route) =>
            route.ActionConstraints?
                .OfType<HttpMethodActionConstraint>()
                .FirstOrDefault()?
                .HttpMethods
                .FirstOrDefault();

        private string GetApiVersion(ActionDescriptor route) => route.GetApiVersionModel().DeclaredApiVersions.LastOrDefault()?.ToString() ?? "";
    }
}
