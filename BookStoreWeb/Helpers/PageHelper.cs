using System;
using System.Text;
using System.Web.Mvc;
using BookStoreWeb.Models;

namespace BookStoreWeb.Helpers
{
    public static class PageHelper
    {
        // Create a pagination links
        public static MvcHtmlString CreatePages(this HtmlHelper htmlHelper, PageInfo pageInfo, Func<int,string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();
            for(int index = 1; index <= pageInfo.PagesCount; index++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href", pageUrl(index));
                tagBuilder.InnerHtml = index.ToString();
                if(index == pageInfo.CurrentPage)
                {
                    tagBuilder.AddCssClass("selected");
                    tagBuilder.AddCssClass("btn-primary");
                }
                tagBuilder.AddCssClass("btn btn-default");
                builder.Append(tagBuilder.ToString());
            }
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}