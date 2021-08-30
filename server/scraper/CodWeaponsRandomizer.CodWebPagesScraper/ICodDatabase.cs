namespace CodWeaponsRandomizer.CodWebPagesScraper
{
    interface ICodDatabase
    {
        string FolderName { get; }

        void Export(string folderPath);
    }
}
