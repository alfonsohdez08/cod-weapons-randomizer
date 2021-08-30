namespace CodWeaponsRandomizer.CodWebPagesScraper.Data
{
    class Weapon
    {
        public string Name { get; set; }
        public string WeaponClass { get;}
        public string? ImageUrl { get; set; }
        public IEnumerable<AttachmentCategory> SupportedAttachmentCategories { get; set; }

        public Weapon(string weaponClass, string name)
        {
            WeaponClass = weaponClass;
            Name = name;
            SupportedAttachmentCategories = new List<AttachmentCategory>();
        }
    }
}
