using UnitConversion.API.Models;
using UnitConversion.API.Providers;
using UnitConversion.API.Services;
using UnitConversion.API.Services.Factories;

namespace UnitConversion.Api.Services;

public class ConversionService : IConversionService
{
    private readonly IUnitDefinitionProvider _unitProvider;
    private readonly ConversionStrategyFactory _strategyFactory;

    public ConversionService(IUnitDefinitionProvider unitProvider)
    {
        _unitProvider = unitProvider;
        _strategyFactory = new ConversionStrategyFactory();
    }

    public ConversionResponse Convert(ConversionRequest request)
    {
        var fromUnit = ResolveUnit(request.FromUnit);
        var toUnit = ResolveUnit(request.ToUnit);

        var strategy = _strategyFactory.GetStrategy(fromUnit.Category);
        var result = strategy.ExecuteConversion(request.Value, fromUnit, toUnit, request.FromUnit, request.ToUnit);

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
}