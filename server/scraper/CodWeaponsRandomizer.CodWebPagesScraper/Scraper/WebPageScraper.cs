using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageScraper<T>: WebScraper<T> where T: class
    {
        protected readonly IHtmlDocument HtmlDocument;

        protected WebPageScraper(string webPageUrl)
        {
            HtmlDocument = Html.ParseWebPage(webPageUrl);
        }
    }
}
