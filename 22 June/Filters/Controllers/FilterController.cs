using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    [ActionFilter]
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyIndex()
        {
            return View("Index");
        }
    }

    class ActionFilter : ActionFilterAttribute,  IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            Trace.WriteLine(filterContext.ActionDescriptor+ "Method executed Successfully...." + DateTime.Now.ToString());
            //after action method execut
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctrlrName = filterContext.RouteData.Values["Controller"];
            var actName = filterContext.RouteData.Values["action"];
            Trace.WriteLine(filterContext.RouteData + "Method is executing...." + DateTime.Now.ToString() + "From The Controller " +ctrlrName.ToString() + "From The Method" + actName.ToString());
            //before action method execut

            //filterContext.Result = new RedirectResult("https://roli.com/");

        }
    }
}