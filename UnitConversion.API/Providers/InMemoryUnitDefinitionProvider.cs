using UnitConversion.API.Models;
namespace UnitConversion.API.Providers;

public class InMemoryUnitDefinitionProvider : IUnitDefinitionProvider
{
    private static readonly List<UnitDefinition> _units =
        BuildUnitRegistry();

    public UnitDefinition? GetUnit(string unitName)
    {
        return _units.Where(x => x.Name == unitName).FirstOrDefault();
    }

    private static List<UnitDefinition> BuildUnitRegistry()
    {
        var definitions = new List<UnitDefinition>
        {
            new() { Name = "meter",      DisplayName = "Meter",       Category = "length",      FactorToBase = 1.0 },
            new() { Name = "foot",       DisplayName = "Foot",        Category = "length",      FactorToBase = 0.3048 },
        };
        return definitions;
    }
}