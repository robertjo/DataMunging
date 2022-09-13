using DataMunging.Common;
using System.Reflection;

namespace DataMunging.Services;

internal static class CommonService
{
    public static List<DataItem> GetFileData(string dataFile, DataType dataType)
    {
        var list = new List<DataItem>();
        var lines = ReadLines(dataFile);
        foreach (var line in lines)
        {
            if (line != null && !string.IsNullOrWhiteSpace(line))
            {
                DataItem? dataItem = new();
                if (dataType == DataType.Weather)
                {
                    dataItem = DataService.GetWeatherItem(line.ToString());
                }
                else if (dataType == DataType.Football)
                {
                    dataItem = DataService.GetFootballItem(line.ToString());
                }

                if (dataItem != null)
                {
                    list.Add(dataItem);
                }
            }
        }

        return list;
    }

    private static string[] ReadLines(string dataFile)
    {
        if (string.IsNullOrWhiteSpace(dataFile))
        {
            throw new ArgumentNullException(nameof(dataFile));
        }

        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (string.IsNullOrWhiteSpace(assemblyPath))
        {
            throw new InvalidOperationException($"Value cannot be null. Parameter name: {nameof(assemblyPath)}");
        }

        var filePath = Path.Combine(assemblyPath, dataFile);
        return File.Exists(filePath)
            ? File.ReadAllLines(filePath)
            : throw new InvalidOperationException($"File does not exist. Parameter name: {nameof(filePath)}");
    }
}
