using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class ModernWarfareWeaponDetailsPageScraper : WebPageScraper<Weapon>
    {
        public ModernWarfareWeaponDetailsPageScraper(string weaponWikiPage): base(weaponWikiPage)
        {

        }

        private bool IsExclusiveMwWeapon() => HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare") == null;

        private IHtmlElement FindWeaponAsideElement()
        {
            IElement asideElement = null;
            if (IsExclusiveMwWeapon())
                asideElement = HtmlDocument.QuerySelector("aside");
            else
                asideElement = HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare").ParentElement.NextElementSibling.NextElementSibling;

            return (IHtmlElement)asideElement;
        }

        private IEnumerable<AttachmentCategory> GetWeaponSupportedAttachments()
        {
            IEnumerable<AttachmentCategory> supportedAttachments;
            if (IsExclusiveMwWeapon())
                supportedAttachments = new ModernWarfareWeaponAttachmentsScraper((IHtmlSpanElement)HtmlDocument.GetElementById("Attachments")).Scrap();
            else
                supportedAttachments = null;

            return supportedAttachments;
        }

        public override Weapon Scrap()
        {
            IHtmlElement asideElement = FindWeaponAsideElement();

            var weapon = new ModernWarfareWeaponContainerScraper(asideElement).Scrap();
            weapon.SupportedAttachments = GetWeaponSupportedAttachments();

            return weapon;
        }
    }
}
