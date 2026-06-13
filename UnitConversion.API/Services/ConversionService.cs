using UnitConversion.API.Models;
using UnitConversion.API.Providers;
using UnitConversion.API.Services;

namespace UnitConversion.Api.Services;
public class ConversionService : IConversionService
{
    private readonly IUnitDefinitionProvider _unitProvider;

    public ConversionService(IUnitDefinitionProvider unitProvider)
    {
        _unitProvider = unitProvider;
    }

    public ConversionResponse Convert(ConversionRequest request)
    {
        var fromUnit = ResolveUnit(request.FromUnit);
        var toUnit = ResolveUnit(request.ToUnit);

        var result = ConvertLength(request.Value, fromUnit.FactorToBase, toUnit.FactorToBase);

        return new ConversionResponse
        {
            InputValue = request.Value,
            FromUnit = fromUnit.Name,
            ToUnit = toUnit.Name,
            Result = Math.Round(result, 6),
            Category = fromUnit.Category,
        };
    }

    private UnitDefinition ResolveUnit(string name)
    {
        return _unitProvider.GetUnit(name);
    }

    private static double ConvertLength(double value, double fromFactorToBase, double toFactorToBase)
    {
        return value * fromFactorToBase / toFactorToBase;
    }
}