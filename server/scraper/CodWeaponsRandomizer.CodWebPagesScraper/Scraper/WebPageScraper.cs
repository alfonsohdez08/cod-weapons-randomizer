using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageScraper
    {
        protected readonly IHtmlDocument HtmlDocument;

        protected WebPageScraper(string webPageUrl)
        {
            HtmlDocument = Html.ParseWebPage(webPageUrl);
        }
    }
}
