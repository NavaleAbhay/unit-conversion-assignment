using UnitConversion.API.Models;

namespace UnitConversion.API.Services;

public interface IConversionService
{
    ConversionResponse Convert(ConversionRequest request);
}