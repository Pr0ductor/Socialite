using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Mvc.IUrlHelper;

namespace SocialNetwork.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent SidebarLink(this IHtmlHelper htmlHelper, string controller, string action, string text, string iconSrc, string altText)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentController = routeData.Values["controller"]?.ToString();
            var currentAction = routeData.Values["action"]?.ToString();

            var isActive = currentController == controller && currentAction == action;
            var activeClass = isActive ? "active" : "";

            // Используем IUrlHelper для генерации URL
            var url = $"/{controller}/{action}";

            var link = $@"
            <li class=""{activeClass}"">
                <a href=""{url}"">
                    <img src=""{iconSrc}"" alt=""{altText}"" class=""w-6"">
                    <span>{text}</span>
                </a>
            </li>";

            return new HtmlString(link);
        }
    }
}
