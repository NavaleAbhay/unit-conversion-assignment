using UnitConversion.API.Models;

namespace UnitConversion.API.Services.Strategies;

public class LengthConversionStrategy : IConversionStrategy
{
    public double ExecuteConversion(double value, UnitDefinition fromUnit, UnitDefinition toUnit, string fromUnitName, string toUnitName)
    {
        return value * fromUnit.FactorToBase / toUnit.FactorToBase;
    }
}
