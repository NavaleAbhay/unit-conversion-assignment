using UnitConversion.API.Models;

namespace UnitConversion.API.Services;

public interface IConversionService
{
    ApiResponse<ConversionResponse> Convert(ConversionRequest request);
}