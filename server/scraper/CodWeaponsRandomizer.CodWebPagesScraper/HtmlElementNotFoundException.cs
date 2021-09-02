namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    class HtmlElementNotFoundException : Exception
    {
        public HtmlElementNotFoundException(string selector): base($"Did not find any HTML element by using the selector: \"{selector}\".")
        {
        }
    }
}
