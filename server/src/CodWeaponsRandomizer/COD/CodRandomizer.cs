
namespace CodWeaponsRandomizer.COD;
public abstract class CodRandomizer
{
    private readonly Random _random = new Random();

    protected int GenerateRandomIndex(int end) => GenerateRandomNumber(0, end);
    protected int GenerateRandomNumber(int inclusiveStart, int exclusiveEnd) => _random.Next(inclusiveStart, exclusiveEnd);
}
