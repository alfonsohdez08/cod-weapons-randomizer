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

        private IHtmlHeadingElement? FindWeaponAttachmentHeadings()
        {
            IHtmlHeadingElement? heading;
            if (IsExclusiveMwWeapon())
                heading = (IHtmlHeadingElement)HtmlDocument.GetElementById("Attachments")?.ParentElement;
            else
                heading = FindNonExclusiveWeaponAttachmentsHeading();

            IHtmlHeadingElement? FindNonExclusiveWeaponAttachmentsHeading()
            {
                var element = HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare").ParentElement;

                for (; element != null; element = element.NextElementSibling)
                    if (element is IHtmlHeadingElement h && h.Children[0] is IHtmlSpanElement s
                        && s.Text() == "Attachments")
                        break;

                return (IHtmlHeadingElement)element;
            }

            return heading;
        }

        private IEnumerable<AttachmentCategory> GetWeaponSupportedAttachments()
        {
            IHtmlHeadingElement element = FindWeaponAttachmentHeadings();
            return element != null ? new ModernWarfareWeaponAttachmentsScraper(element).Scrap() : new List<AttachmentCategory>();
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
