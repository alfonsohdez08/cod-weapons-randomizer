using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper.CoDWikiFandom
{
    class CodMwWeaponAttachmentsScrapper : WikiScraper<IEnumerable<AttachmentCategory>>
    {
        private CodMwWeaponAttachmentsScrapper(string weaponWikiPath): base(weaponWikiPath)
        {

        }

        public override IEnumerable<AttachmentCategory> Scrap()
        {
            return new List<AttachmentCategory>();
        }


        public static IEnumerable<AttachmentCategory> ScrapAttachmentCategories(string weaponWikiPath) => new CodMwWeaponAttachmentsScrapper(weaponWikiPath).Scrap();
    }
}
