using CommonDependencies;
using MediatR;
using WeatherApp.SMS;

namespace WeatherApp.Domain.Features.SendExtremeWeatherAlert;

public sealed class SendExtremeWeatherAlertRequestHandler(
    MyDbContext _context,
    ISmsService _sms
) : IRequestHandler<SendExtremeWeatherAlertRequest, SendExtremeWeatherAlertResponse>
{
    public async Task<SendExtremeWeatherAlertResponse> Handle(SendExtremeWeatherAlertRequest request, CancellationToken cancellationToken)
    {
        var (zipCodes, alertMessage) = request;
        
        List<string> phoneNumbersToAlert = _context
            .SupportedAreas
            .Where(area => zipCodes.Contains(area.ZipCode))
            .SelectMany(area => area.Subscribers)
            .Select(sub => sub.PhoneNumber)
            .ToList();

        await _sms.SendAlert(alertMessage, phoneNumbersToAlert);

        return new(phoneNumbersToAlert);
    }
}