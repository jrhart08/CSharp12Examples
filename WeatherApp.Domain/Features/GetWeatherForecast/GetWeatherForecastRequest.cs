using MediatR;

namespace WeatherApp.Domain.Features.GetWeatherForecast;

public sealed class GetWeatherForecastRequest : IRequest<GetWeatherForecastResponse>
{
    
}

public sealed class GetWeatherForecastResponse
{
    public class Forecast
    {
        public DateOnly Date { get; init; }
        public int TemperatureC { get; init; }
        public string? Summary { get; init; }
        
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public IList<Forecast> DailyForecasts { get; set; }
}