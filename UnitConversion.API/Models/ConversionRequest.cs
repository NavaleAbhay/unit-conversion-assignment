using System.ComponentModel.DataAnnotations;

namespace UnitConversion.API.Models;
public class ConversionRequest
{
    public double Value { get; init; }
 
    public required string FromUnit { get; init; }
 
    public required string ToUnit { get; init; }
}