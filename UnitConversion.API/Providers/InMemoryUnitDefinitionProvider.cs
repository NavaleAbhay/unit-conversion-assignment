using UnitConversion.API.Models;
namespace UnitConversion.API.Providers;

public class InMemoryUnitDefinitionProvider : IUnitDefinitionProvider
{
    private static readonly List<UnitDefinition> _units =
        BuildUnitRegistry();

    public UnitDefinition? GetUnit(string unitName)
    {
        return _units.FirstOrDefault(x => x.Name == unitName);
    }

    private static List<UnitDefinition> BuildUnitRegistry()
    {
        var definitions = new List<UnitDefinition>
        {
            new() { Name = "meter",      DisplayName = "Meter",        Category = "length",       FactorToBase = 1.0 },
            new() { Name = "foot",       DisplayName = "Foot",         Category = "length",       FactorToBase = 0.3048 },
            new() { Name = "kilometer",  DisplayName = "Kilometer",    Category = "length",       FactorToBase = 1000.0 },
            new() { Name = "mile",       DisplayName = "Mile",         Category = "length",       FactorToBase = 1609.344 },
            new() { Name = "centimeter", DisplayName = "Centimeter",   Category = "length",       FactorToBase = 0.01 },

            new() { Name = "kilogram",   DisplayName = "Kilogram",     Category = "weight",       FactorToBase = 1.0 },
            new() { Name = "pound",      DisplayName = "Pound",        Category = "weight",       FactorToBase = 0.453592 },
            new() { Name = "gram",       DisplayName = "Gram",         Category = "weight",       FactorToBase = 0.001 },

            new() { Name = "celsius",    DisplayName = "Celsius",      Category = "temperature",  FactorToBase = 1.0 },
            new() { Name = "fahrenheit", DisplayName = "Fahrenheit",   Category = "temperature",  FactorToBase = 1.0 },
            new() { Name = "kelvin",     DisplayName = "Kelvin",       Category = "temperature",  FactorToBase = 1.0 },
        };
        return definitions;
    }
}