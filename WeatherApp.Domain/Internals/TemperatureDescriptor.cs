namespace WeatherApp.Domain.Internals;

static class TemperatureDescriptor
{
    static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static string Describe(int temperatureC)
    {
        return Summaries[Random.Shared.Next(Summaries.Length)];
    }
}