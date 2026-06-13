using System.ComponentModel.DataAnnotations;

namespace UnitConversion.API.Models;
public class ConversionRequest
{
    [Required]
    public double Value { get; init; }
 
    [Required]
    public required string FromUnit { get; init; }
 
    [Required]
    public required string ToUnit { get; init; }
}