using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Domain.Features.GetWeatherForecast;

namespace WeatherApp.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    IMediator _mediator,
    ILogger<WeatherForecastController> _logger
) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<GetWeatherForecastResponse> Get()
    {
        return await _mediator.Send(new GetWeatherForecastRequest());
    }
}