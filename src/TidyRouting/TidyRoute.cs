using System;
using System.Web.Routing;

namespace TidyRouting
{
    public class TidyRoute : Route
    {
        public TidyRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler) { }

        public TidyRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler) { }

        public TidyRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler) { }

        public TidyRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler) { }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData path = base.GetVirtualPath(requestContext, values);

	        if (path != null && path.VirtualPath != String.Empty)
	        {
		        int qsIndex = path.VirtualPath.IndexOf("?", StringComparison.Ordinal);

		        // Lower Case
		        string newPath = qsIndex >= 0
			                         ? path.VirtualPath.Substring(0, qsIndex).ToLowerInvariant()
			                         : path.VirtualPath.ToLowerInvariant();

		        // Trailing Slash
		        if (newPath.Length > 0 && newPath[newPath.Length - 1] != '/')
			        newPath += '/';

		        // Preserve Query String
		        if (qsIndex >= 0)
			        newPath += path.VirtualPath.Substring(qsIndex);

		        path.VirtualPath = newPath;
	        }

	        return path;
        }
    }
}