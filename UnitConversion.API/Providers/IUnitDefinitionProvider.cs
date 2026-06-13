
using UnitConversion.API.Models;

namespace UnitConversion.API.Providers;

public interface IUnitDefinitionProvider
{
    UnitDefinition? GetUnit(string unitName);
}