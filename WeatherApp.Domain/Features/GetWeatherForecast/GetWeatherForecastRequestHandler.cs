using MediatR;
using WeatherApp.Domain.Internals;

namespace WeatherApp.Domain.Features.GetWeatherForecast;

public sealed class GetWeatherForecastRequestHandler : IRequestHandler<GetWeatherForecastRequest, GetWeatherForecastResponse>
{
    public async Task<GetWeatherForecastResponse> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        var forecasts = Enumerable
            .Range(1, 5)
            .Select(index =>
            {
                var tempC = Random.Shared.Next(-20, 55);
                return new GetWeatherForecastResponse.Forecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = tempC,
                    Summary = TemperatureDescriptor.Describe(tempC)
                };
            })
            .ToArray();

        return new() { DailyForecasts = forecasts };
    }
}