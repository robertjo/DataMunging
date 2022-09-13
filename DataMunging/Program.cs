using DataMunging.Common;
using DataMunging.Services;

const string WeatherDataFile = @"DataFiles\weather.dat";
const string FootballDataFile = @"DataFiles\football.dat";

Console.WriteLine("Start program...");
Console.WriteLine();

var weatherData = CommonService.GetFileData(WeatherDataFile, DataType.Weather);
DisplayData(DataType.Weather.ToString(), weatherData);
var weatherItem = weatherData
    .OrderBy(i => i.Diff)
    .FirstOrDefault();
if (weatherItem != null)
{
    Console.WriteLine($"Day number with the smallest temperature spread: {weatherItem.Id}.");
    Console.WriteLine($"Values: Id: {weatherItem.Id}, Max temp: {weatherItem.Value1}, " + 
        $"Min temp: {weatherItem.Value2}, Spread: {weatherItem.Diff}");
    Console.WriteLine();
}

var footballData = CommonService.GetFileData(FootballDataFile, DataType.Football);
DisplayData(DataType.Football.ToString(), footballData);
var footballItem = footballData
    .OrderBy(i => i.Diff)
    .FirstOrDefault();
if (footballItem != null)
{
    Console.WriteLine($"Team with the smallest difference in ‘for’ and ‘against’ goals: {footballItem.Id}.");
    Console.WriteLine($"Values: Id: {footballItem.Id}, For goals: {footballItem.Value1}, " + 
        $"Against goals: {footballItem.Value2}, Diff: {footballItem.Diff}.");
    Console.WriteLine();
}

Console.WriteLine("End program.");

static void DisplayData(string dataType, List<DataItem> list)
{
    Console.WriteLine($"{dataType} data:");
    int i = 1;
    foreach (var item in list)
    {
        Console.WriteLine($"{i++}|{item.Id}|{item.Value1}|{item.Value2}|{item.Diff}");
    }

    Console.WriteLine();
}
