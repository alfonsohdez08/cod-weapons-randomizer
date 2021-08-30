using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageComponentScraper<THtmlElementType, TResult>: WebScraper<TResult>
        where THtmlElementType: IHtmlElement
        where TResult: class
    {
        protected readonly THtmlElementType HtmlElement;

        public WebPageComponentScraper(THtmlElementType htmlElement)
        {
            HtmlElement = htmlElement;
        }
    }
}
