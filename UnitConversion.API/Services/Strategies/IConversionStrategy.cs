using UnitConversion.API.Models;

namespace UnitConversion.API.Services.Strategies;

public interface IConversionStrategy
{
    double ExecuteConversion(double value, UnitDefinition fromUnit, UnitDefinition toUnit, string fromUnitName, string toUnitName);
}
