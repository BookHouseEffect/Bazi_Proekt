using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bazi_Web.Helpers
{
    public static class ActionLinkExtension
    {
        public static MvcHtmlString ActionLinkSpan(this HtmlHelper helper, string linkText, string actionName, string controllerName, string queryAttributeValuesPair,  string glyphClass)
        {
            TagBuilder glyphSpanBuilder = new TagBuilder("span");
            glyphSpanBuilder.AddCssClass(glyphClass);

            TagBuilder textSpanBuilder = new TagBuilder("span");
            textSpanBuilder.InnerHtml = linkText;

            return BuildNestedAnchor(String.Format("{0} {1}", glyphSpanBuilder, textSpanBuilder), string.Format("/{0}/{1}?{2}", controllerName, actionName, queryAttributeValuesPair));
        }

        private static MvcHtmlString BuildNestedAnchor(string innerHtml, string url)
        {
            TagBuilder anchorBuilder = new TagBuilder("a");
            anchorBuilder.Attributes.Add("href", url);
            anchorBuilder.InnerHtml = innerHtml;

            return new MvcHtmlString(anchorBuilder.ToString());
        }
    }
}