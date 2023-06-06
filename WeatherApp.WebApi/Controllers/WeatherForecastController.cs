using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Domain.Features.GetWeatherForecast;
using WeatherApp.Domain.Features.SendExtremeWeatherAlert;

namespace WeatherApp.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    readonly IMediator _mediator;
    readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IMediator mediator,
        ILogger<WeatherForecastController> logger
    )
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<GetWeatherForecastResponse> Get()
    {
        _logger.LogInformation("Getting forecast");
        return await _mediator.Send(new GetWeatherForecastRequest());
    }

    [HttpPost(Name = "SendAlert")]
    public async Task<SendExtremeWeatherAlertResponse> SendAlert(SendExtremeWeatherAlertRequest request)
    {
        _logger.LogInformation("Sending extreme weather alert");
        return await _mediator.Send(request);
    }
}