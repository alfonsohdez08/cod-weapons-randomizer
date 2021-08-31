using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using CodWeaponsRandomizer.CodWebPagesScraper.Data;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.MW
{
    class WeaponWikiPageScraper : WebPageScraper
    {
        public WeaponWikiPageScraper(string weaponWikiPage): base(weaponWikiPage)
        {

        }

        private bool IsExclusiveMwWeapon() => HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare") == null;

        private IHtmlElement FindWeaponAsideElement()
        {
            IElement asideElement = IsExclusiveMwWeapon() ?
                HtmlDocument.SelectFirst<IElement>(Html.Tags.Aside) : FindAsideElementForNonExclusiveWeapon();

            IElement FindAsideElementForNonExclusiveWeapon()
            {
                string asideHtmlTag = Html.Tags.Aside.ToUpper();
                var element = HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare")!.ParentElement;

                while (element!.TagName != asideHtmlTag)
                    element = element.NextElementSibling;

                return element;
            }

            return (IHtmlElement)asideElement!;
        }

        private IHtmlHeadingElement? FindWeaponAttachmentHeadings()
        {
            IHtmlHeadingElement? heading;
            if (IsExclusiveMwWeapon())
                heading = HtmlDocument.QuerySelector("#Attachments")?.ParentElement as IHtmlHeadingElement;
            else
                heading = FindNonExclusiveWeaponAttachmentsHeading();

            IHtmlHeadingElement? FindNonExclusiveWeaponAttachmentsHeading()
            {
                var element = HtmlDocument.GetElementById("Call_of_Duty:_Modern_Warfare")?.ParentElement;

                for (; element != null; element = element.NextElementSibling)
                    if (element is IHtmlHeadingElement h && h.Children[0] is IHtmlSpanElement s
                        && s.Text() == "Attachments")
                        break;

                return element as IHtmlHeadingElement;
            }

            return heading;
        }

        private IEnumerable<AttachmentCategory> GetWeaponSupportedAttachments()
        {
            IHtmlHeadingElement? element = FindWeaponAttachmentHeadings();
            return element != null ? new WeaponAttachmentsScraper(element).Scrap() : new List<AttachmentCategory>();
        }

        public Weapon ScrapWeapon()
        {
            IHtmlElement asideElement = FindWeaponAsideElement();

            Weapon weapon = new WeaponScraper(asideElement).Scrap();
            weapon.SupportedAttachmentCategories = GetWeaponSupportedAttachments();

            return weapon;
        }
    }
}
