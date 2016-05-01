using System.Web;
using System.Web.Mvc;
using QuestBoard.Api.Filters;

namespace QuestBoard.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
