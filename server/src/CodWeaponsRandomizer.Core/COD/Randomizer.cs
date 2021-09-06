namespace CodWeaponsRandomizer.Core.COD
{
    public abstract class Randomizer<THints, TRandomType>
        where THints: class
        where TRandomType: class
    {
        private readonly Random _random = new Random();

        protected int GenerateRandomNumber(int inclusiveStart, int exclusiveEnd) => _random.Next(inclusiveStart, exclusiveEnd);

        protected int GenerateRandomIndex(int exclusiveEnd) => GenerateRandomNumber(0, exclusiveEnd);

        public abstract TRandomType Randomize(THints? hints);
    }
}