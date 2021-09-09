namespace CodWeaponsRandomizer.Core
{
    internal static class HashSetHelper
    {
        public static HashSet<string> ParseSet(params string[] elements) => new HashSet<string>(elements);
    }
}
