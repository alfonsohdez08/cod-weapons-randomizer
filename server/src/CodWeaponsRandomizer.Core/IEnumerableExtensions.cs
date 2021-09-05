namespace CodWeaponsRandomizer.Core
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            var random = new Random();
            return collection.OrderBy(i => random.Next());
        }
    }
}
