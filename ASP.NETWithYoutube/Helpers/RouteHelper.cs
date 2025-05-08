using ASP.NETWithYoutube.Models;

namespace ASP.NETWithYoutube.Helpers;

public class RouteHelper
{
    public void GetCurrentRoute(RouteData routeData)
    {
        var route = RouteResponse.Routes
            .FirstOrDefault(x => x.Action == (string?)routeData.Values["action"]
                                 && x.Controller == (string?)routeData.Values["controller"]);

        if (route == null)
        {
            var responseRoute = new RouteResponse()
            {
                Controller = routeData.Values["controller"]?.ToString(),
                Action = routeData.Values["action"]?.ToString()
            };
            RouteResponse.Routes.Add(responseRoute);
        }
    }
}