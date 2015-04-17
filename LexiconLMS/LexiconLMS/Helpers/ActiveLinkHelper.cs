using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LexiconLMS.Helpers
{
    public static class ActiveLinkHelper
    {
        public static MvcHtmlString ListItemAction(this HtmlHelper helper, string name, string actionName, string controllerName)
        {
            var currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string)helper.ViewContext.RouteData.Values["action"];
            var sb = new StringBuilder();
            sb.AppendFormat("<li{0}", (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase)&&
                                                currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase)                                                    
                                                    ? " class=\"active\">" : ">"));
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            sb.AppendFormat("<a href=\"{0}\">{1}</a>", url.Action(actionName, controllerName), name);
            sb.Append("</li>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}