using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //This is a global filter to redirect to authorization
            //filters.Add(new AuthorizeAttribute());
        }
    }
}
