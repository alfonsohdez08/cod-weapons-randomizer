using AngleSharp;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    static partial class Html
    {
        private static readonly IBrowsingContext _browsingCtx = BrowsingContext.New(Configuration.Default.WithDefaultLoader());

        public static IHtmlDocument ParseWebPage(string webPageUrl) => (IHtmlDocument)_browsingCtx.OpenAsync(webPageUrl).Result;

        public static T ParseElement<T>(string elementContent) where T: IHtmlElement => (T)_browsingCtx.OpenAsync(req => req.Content(elementContent)).Result;
    }
}
