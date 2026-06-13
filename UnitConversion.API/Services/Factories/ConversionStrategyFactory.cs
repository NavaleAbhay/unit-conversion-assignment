using UnitConversion.API.Services.Strategies;

namespace UnitConversion.API.Services.Factories;

public class ConversionStrategyFactory
{
    private readonly Dictionary<string, IConversionStrategy> _strategies;

    public ConversionStrategyFactory()
    {
        _strategies = new Dictionary<string, IConversionStrategy>(StringComparer.OrdinalIgnoreCase)
        {
            { "length", new LengthConversionStrategy() },
            { "weight", new WeightConversionStrategy() },
            { "temperature", new TemperatureConversionStrategy() }
        };
    }

    public IConversionStrategy GetStrategy(string category)
    {
        if (_strategies.TryGetValue(category, out var strategy))
        {
            return strategy;
        }

        throw new InvalidOperationException($"Unknown conversion category: {category}");
    }
}
