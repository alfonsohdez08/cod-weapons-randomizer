using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponDetailsPageScraper : HtmlScraper<Weapon>
    {
        public ModernWarfareWeaponDetailsPageScraper(string weaponWikiPage): base(weaponWikiPage)
        {

        }

        private bool IsExclusiveMwWeapon() => HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare") == null;

        private IHtmlElement FindWeaponAsideElement()
        {
            if (IsExclusiveMwWeapon())
                return HtmlDocument.QuerySelector("aside") as IHtmlElement;
            else
                return HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare").ParentElement.NextElementSibling.NextElementSibling as IHtmlElement;
        }

        public override Weapon Scrap()
        {
            // the idea would have a scraper for the aside container
            // and then another scraper for the attachments container
            // so this means the html scraper can either receive a web page url (using url class) or a html as stream
            IHtmlElement asideElement = FindWeaponAsideElement();

            throw new NotImplementedException();
        }
    }
}
