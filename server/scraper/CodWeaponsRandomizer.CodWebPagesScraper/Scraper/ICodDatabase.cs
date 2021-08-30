namespace CodWeaponsRandomizer.CodWebPagesScraper.Scraper
{
    interface ICodDatabase
    {
        string FolderName { get; }

        void Export(string folderPath);
    }
}
