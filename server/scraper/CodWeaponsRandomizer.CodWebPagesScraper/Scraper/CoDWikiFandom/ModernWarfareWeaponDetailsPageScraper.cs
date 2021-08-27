using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponDetailsPageScraper : WebScraper<IHtmlDocument, Weapon>
    {
        public ModernWarfareWeaponDetailsPageScraper(string weaponWikiPage): base(new Uri(weaponWikiPage))
        {

        }

        private bool IsExclusiveMwWeapon() => ElementDom.GetElementById("Call_of_Duty:_Modern_Warfare") == null;

        private IHtmlElement FindWeaponAsideElement()
        {
            if (IsExclusiveMwWeapon())
                return ElementDom.QuerySelector("aside") as IHtmlElement;
            else
                return ElementDom.GetElementById("Call_of_Duty:_Modern_Warfare").ParentElement.NextElementSibling.NextElementSibling as IHtmlElement;
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
