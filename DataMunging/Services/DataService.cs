using DataMunging.Common;

namespace DataMunging.Services;

internal static class DataService
{
    const string Asterisk = "*";

    public static DataItem? GetWeatherItem(string line)
    {
        var id = line[..4]?.Trim();
        if (!int.TryParse(id, out _))
        {
            return null;
        }

        var value1Str = line.Substring(4, 4)?
            .Replace(Asterisk, string.Empty)?
            .Trim();
        if (!int.TryParse(value1Str, out int value1))
        {
            return null;
        }

        var value2Str = line.Substring(8, 6)?
            .Replace(Asterisk, string.Empty)?
            .Trim();
        if (!int.TryParse(value2Str, out int value2))
        {
            return null;
        }

        return new DataItem
        {
            Id = id,
            Value1 = value1,
            Value2 = value2,
            Diff = Math.Abs(value1 - value2)
        };
    }

    public static DataItem? GetFootballItem(string line)
    {
        var num = line[..5]?.Trim();
        if (!int.TryParse(num, out _))
        {
            return null;
        }

        var id = line.Substring(7, 16)?.Trim();
        if (string.IsNullOrWhiteSpace(id))
        {
            return null;
        }

        var value1Str = line.Substring(43, 2)?.Trim();
        if (!int.TryParse(value1Str, out int value1))
        {
            return null;
        }

        var value2Str = line.Substring(50, 2)?.Trim();
        if (!int.TryParse(value2Str, out int value2))
        {
            return null;
        }

        return new DataItem
        {
            Id = id,
            Value1 = value1,
            Value2 = value2,
            Diff = Math.Abs(value1 - value2)
        };
    }
}
