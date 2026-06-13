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

        double result;

        switch (fromUnit.Category)
        {
            case "length":
                result = ConvertLength(request.Value, fromUnit.FactorToBase, toUnit.FactorToBase);
                break;
            case "weight":
                result = ConvertWeight(request.Value, fromUnit.FactorToBase, toUnit.FactorToBase);
                break;
            case "temperature":
                result = ConvertTemperature(request.Value, request.FromUnit, request.ToUnit);
                break;
            default:
                throw new InvalidOperationException($"Unknown category: {fromUnit.Category}");
        }

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

    private static double ConvertWeight(double value, double fromFactorToBase, double toFactorToBase)
    {
        return value * fromFactorToBase / toFactorToBase;
    }

    private static double ConvertTemperature(double value, string fromUnit, string toUnit)
    {
        double celsius;

        switch (fromUnit.ToLower())
        {
            case "celsius":
                celsius = value;
                break;
            case "fahrenheit":
                celsius = (value - 32) * 5 / 9;
                break;
            case "kelvin":
                celsius = value - 273.15;
                break;
            default:
                throw new InvalidOperationException($"Unknown temperature unit: {fromUnit}");
        }

        double result;

        switch (toUnit.ToLower())
        {
            case "celsius":
                result = celsius;
                break;
            case "fahrenheit":
                result = celsius * 9 / 5 + 32;
                break;
            case "kelvin":
                result = celsius + 273.15;
                break;
            default:
                throw new InvalidOperationException($"Unknown temperature unit: {toUnit}");
        }

        return result;
    }
}