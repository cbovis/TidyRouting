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

			if (path != null)
			{
				if (path.VirtualPath != "")
				{
					int qsIndex = path.VirtualPath.IndexOf("?", StringComparison.Ordinal);

					if (qsIndex >= 0)
					{
						path.VirtualPath = path.VirtualPath.Substring(0, qsIndex).ToLowerInvariant() + "/" +
							path.VirtualPath.Substring(qsIndex);
					}
					else
					{
						path.VirtualPath = path.VirtualPath.ToLowerInvariant();
						path.VirtualPath += "/";
					}
				}
			}

			return path;
		}
	}
}