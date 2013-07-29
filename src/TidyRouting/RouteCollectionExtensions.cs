using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace TidyRouting
{
	public static class RouteCollectionExtensions
	{
		/// <summary>
		/// Creates tidier versions of .NET MVC routes by lower casing the urls
		/// and making sure a trailing slash is added.
		/// </summary>
		public static void MapTidyRoute(this RouteCollection routes, string name, string url, object defaults)
		{
			if (routes == null) throw new ArgumentNullException("routes");

			routes.MapTidyRoute(name, url, defaults, null, null);
		}

		/// <summary>
		/// Creates tidier versions of .NET MVC routes by lower casing the urls
		/// and making sure a trailing slash is added.
		/// </summary>
		public static void MapTidyRoute(this RouteCollection routes, string name, string url, object defaults, object constraints)
		{
			if (routes == null) throw new ArgumentNullException("routes");

			routes.MapTidyRoute(name, url, defaults, constraints, null);
		}

		/// <summary>
		/// Creates tidier versions of .NET MVC routes by lower casing the urls
		/// and making sure a trailing slash is added.
		/// </summary>
		public static Route MapTidyRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
		{
			if (routes == null) throw new ArgumentNullException("routes");
			if (url == null) throw new ArgumentNullException("url");

			var route = new TidyRoute(url, new MvcRouteHandler())
			{
				Defaults = new RouteValueDictionary(defaults),
				Constraints = new RouteValueDictionary(constraints),
				DataTokens = new RouteValueDictionary()
			};

			if ((namespaces != null) && (namespaces.Length > 0))
				route.DataTokens["Namespaces"] = namespaces;

			if (String.IsNullOrEmpty(name))
				routes.Add(route);
			else
				routes.Add(name, route);

			return route;
		}
	}
}