namespace UnitConversion.API.Models;

public class ConversionResponse
{
    public double InputValue { get; init; }

    public string? FromUnit { get; init; }

    public string? ToUnit { get; init; }

    public double Result { get; init; }

    public required string Category { get; init; }
}