using System.Text.RegularExpressions;

namespace ProjectCalendar.Domain.ValueObjects;

public class EventColor
{
    private static readonly Regex HexColorRegex = new(@"^#([A-Fa-f0-9]{6})$", RegexOptions.Compiled);

    public string Value { get; private set; }

    private EventColor()
    {
        Value = string.Empty;
        // Construtor privado para o MongoDB
    }

    public EventColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Color cannot be empty");

        if (!HexColorRegex.IsMatch(color))
            throw new ArgumentException("Color must be a valid hex color (e.g., #FF5733)");

        Value = color.ToUpperInvariant();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not EventColor other)
            return false;

        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }

    public static implicit operator string(EventColor color)
    {
        return color.Value;
    }
}