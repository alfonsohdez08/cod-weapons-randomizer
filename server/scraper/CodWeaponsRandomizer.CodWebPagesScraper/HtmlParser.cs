using AngleSharp;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    static class HtmlParser
    {
        private static readonly IBrowsingContext _browsingCtx;

        static HtmlParser()
        {
            _browsingCtx = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
        }

        public static IHtmlDocument ParseWebPage(string webPageUrl) => (IHtmlDocument)_browsingCtx.OpenAsync(webPageUrl).Result;

        public static T ParseElement<T>(string elementContent) where T: IHtmlElement => (T)_browsingCtx.OpenAsync(req => req.Content(elementContent)).Result;
    }
}
