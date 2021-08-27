namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    abstract class WebScraper<T> where T: class
    {
        public abstract T Scrap();
    }
}
