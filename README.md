TidyRouting
================================

What is TidyRouting?
--------------------------------
TidyRouting is a small library that extends the ASP.NET MVC routing system to provide cleaner urls. Traditionally routes in ASP.NET MVC are created in proper-case with no trailing slash. This not only looks bad but is bad for SEO. TidyRouting makes sure that all urls are created in lower-case and are given a trailing slash.

For more information about the impacts on SEO take a look at http://www.searchenginejournal.com/url-capitalization-and-seo/12667/ and http://www.awebguy.com/2011/02/seo-trailing-slash/

How do I get started?
--------------------------------
Once you have added TidyRouting to your project you simply need to replace your traditional route mappings with TidyRoute. For example,

    using TidyRouting
    ...
    
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapTidyRoute( // changed from routes.MapRoute
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }

Where can I get it?
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install TidyRouting from the package manager console:

    PM> Install-Package TidyRouting