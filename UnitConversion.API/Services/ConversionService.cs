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

    public ApiResponse<ConversionResponse> Convert(ConversionRequest request)
    {
        try
        {
            ValidateRequest(request);

            var fromUnit = ResolveUnit(request.FromUnit);
            var toUnit = ResolveUnit(request.ToUnit);

            ValidateUnitsCategory(fromUnit, toUnit);

            var strategy = _strategyFactory.GetStrategy(fromUnit.Category);
            var result = strategy.ExecuteConversion(request.Value, fromUnit, toUnit, request.FromUnit, request.ToUnit);

            var conversionResponse = new ConversionResponse
            {
                InputValue = request.Value,
                FromUnit = fromUnit.Name,
                ToUnit = toUnit.Name,
                Result = Math.Round(result, 6),
                Category = fromUnit.Category,
            };

            return ApiResponseBuilder.CreateSuccessResponse(conversionResponse, "Conversion successful");
        }
        catch (InvalidOperationException ex)
        {
            return ApiResponseBuilder.CreateErrorResponse<ConversionResponse>(ex.Message, "INVALID_UNIT");
        }
        catch (ArgumentException ex)
        {
            return ApiResponseBuilder.CreateErrorResponse<ConversionResponse>(ex.Message, "INVALID_REQUEST");
        }
        catch (Exception)
        {
            return ApiResponseBuilder.CreateErrorResponse<ConversionResponse>("An unexpected error occurred", "INTERNAL_ERROR");
        }
    }

    private void ValidateRequest(ConversionRequest request)
    {
        if (request == null)
            throw new ArgumentException("Request cannot be null");

        if (string.IsNullOrWhiteSpace(request.FromUnit))
            throw new ArgumentException("FromUnit cannot be empty");

        if (string.IsNullOrWhiteSpace(request.ToUnit))
            throw new ArgumentException("ToUnit cannot be empty");

        if (request.Value < 0)
            throw new ArgumentException("Value cannot be negative");
    }

    private void ValidateUnitsCategory(UnitDefinition fromUnit, UnitDefinition toUnit)
    {
        if (fromUnit.Category != toUnit.Category)
            throw new InvalidOperationException($"Cannot convert between different categories: {fromUnit.Category} and {toUnit.Category}");
    }

    private UnitDefinition ResolveUnit(string name)
    {
        var unit = _unitProvider.GetUnit(name);
        if (unit == null)
            throw new InvalidOperationException($"Unit '{name}' not found");
        return unit;
    }
}