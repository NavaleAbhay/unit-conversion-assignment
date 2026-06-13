using UnitConversion.API.Models;

namespace UnitConversion.API.Services.Strategies;

public class TemperatureConversionStrategy : IConversionStrategy
{
    public double ExecuteConversion(double value, UnitDefinition fromUnit, UnitDefinition toUnit, string fromUnitName, string toUnitName)
    {
        double celsius = ConvertToCelsius(value, fromUnitName);
        return ConvertFromCelsius(celsius, toUnitName);
    }

    private double ConvertToCelsius(double value, string unitName)
    {
        return unitName.ToLower() switch
        {
            "celsius" => value,
            "fahrenheit" => (value - 32) * 5 / 9,
            "kelvin" => value - 273.15,
            _ => throw new InvalidOperationException($"Unknown temperature unit: {unitName}")
        };
    }

    private double ConvertFromCelsius(double celsius, string unitName)
    {
        return unitName.ToLower() switch
        {
            "celsius" => celsius,
            "fahrenheit" => celsius * 9 / 5 + 32,
            "kelvin" => celsius + 273.15,
            _ => throw new InvalidOperationException($"Unknown temperature unit: {unitName}")
        };
    }
}
