using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace TidyRouting
{
	public static class AreaRegistrationContextExtensions
	{
		/// <summary>
		/// Creates tidier versions of .NET MVC routes by lower casing the urls
		/// and making sure a trailing slash is added.
		/// </summary>
		public static Route MapTidyRoute(this AreaRegistrationContext context, string name, string url, object defaults)
		{
			return context.MapTidyRoute(name, url, defaults, null, null);
		}

		/// <summary>
		/// Creates tidier versions of .NET MVC routes by lower casing the urls
		/// and making sure a trailing slash is added.
		/// </summary>
		public static Route MapTidyRoute(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces)
		{
			if (namespaces == null && context.Namespaces != null)
				namespaces = context.Namespaces.ToArray();

			Route route = context.Routes.MapTidyRoute(name, url, defaults, constraints, namespaces);
			route.DataTokens["area"] = context.AreaName;

			// disabling the namespace lookup fallback mechanism keeps this area from accidentally picking up
			// controllers belonging to other areas
			bool useNamespaceFallback = (namespaces == null || namespaces.Length == 0);
			route.DataTokens["UseNamespaceFallback"] = useNamespaceFallback;

			return route;
		}
	}
}