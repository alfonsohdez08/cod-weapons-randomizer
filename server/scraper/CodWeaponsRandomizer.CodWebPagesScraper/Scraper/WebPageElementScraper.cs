using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageElementScraper<THtmlElementType, TResult>: WebScraper<TResult>
        where THtmlElementType: IHtmlElement
        where TResult: class
    {
        protected readonly THtmlElementType HtmlElement;

        public WebPageElementScraper(string rawHtmlElement)
        {
            HtmlElement = HtmlParser.ParseElement<THtmlElementType>(rawHtmlElement);
        }
    }
}
