using Microsoft.AspNetCore.Mvc;
using UnitConversion.API.Models;
using UnitConversion.API.Services;

namespace UnitConversion.API.Controllers;

[ApiController]
[Route("api")]
public sealed class ConversionController : ControllerBase
{
    private readonly IConversionService _conversionService;

    public ConversionController(
        IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    [HttpPost("convert")]
    public IActionResult Convert([FromBody] ConversionRequest request)
    {
        var result = _conversionService.Convert(request);
        return Ok(result);
    }
}