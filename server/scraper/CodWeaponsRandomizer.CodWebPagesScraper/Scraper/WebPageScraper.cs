using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebPageScraper<T> where T: class
    {
        private const string CodWikiFandomPage = "https://callofduty.fandom.com";

        protected readonly IHtmlDocument HtmlDocument;

        protected WebPageScraper()
        {
            HtmlDocument = LoadWebPage(CodWikiFandomPage);
        }

        protected WebPageScraper(string path)
        {
            HtmlDocument = LoadWebPage(CodWikiFandomPage + $"/{path}");
        }

        private static IHtmlDocument LoadWebPage(string webPageUrl)
        {
            string webPageContent = DownloadWebPage(webPageUrl);

            return new HtmlParser().ParseDocument(webPageContent);
        }

        private static string DownloadWebPage(string webPageUrl)
        {
            using var httpClient = new HttpClient();
            HttpResponseMessage httpResponse = httpClient.GetAsync(webPageUrl).Result;

            return httpResponse.Content.ReadAsStringAsync().Result;
        }

        public abstract T Scrap();
    }
}
