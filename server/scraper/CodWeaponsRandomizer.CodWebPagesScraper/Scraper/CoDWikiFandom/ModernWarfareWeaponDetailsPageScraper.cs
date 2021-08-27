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
            IElement asideElement = IsExclusiveMwWeapon() ? HtmlDocument.QuerySelector("aside") : FindAsideElementForNonExclusiveWeapon();

            IElement FindAsideElementForNonExclusiveWeapon()
            {
                var element = HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare").ParentElement;
                while (element.TagName.ToLower() != "aside")
                    element = element.NextElementSibling;

                return element;
            }

            return (IHtmlElement)asideElement;
        }

        private IEnumerable<AttachmentCategory> GetWeaponSupportedAttachments()
        {
            IEnumerable<AttachmentCategory> supportedAttachments = new List<AttachmentCategory>();
            if (IsExclusiveMwWeapon())
            {
                IHtmlSpanElement? spanElement = (IHtmlSpanElement)HtmlDocument.GetElementById("Attachments");
                if (spanElement != null)
                    supportedAttachments = new ModernWarfareWeaponAttachmentsScraper(spanElement).Scrap();
            }
            //else
            //    supportedAttachments = new List<AttachmentCategory>();

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
