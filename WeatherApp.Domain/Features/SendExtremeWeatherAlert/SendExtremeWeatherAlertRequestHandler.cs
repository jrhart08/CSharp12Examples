using CommonDependencies;
using MediatR;
using WeatherApp.SMS;

namespace WeatherApp.Domain.Features.SendExtremeWeatherAlert;

public sealed class SendExtremeWeatherAlertRequestHandler : IRequestHandler<SendExtremeWeatherAlertRequest, SendExtremeWeatherAlertResponse>
{
    readonly MyDbContext _context;
    readonly ISmsService _sms;

    public SendExtremeWeatherAlertRequestHandler(
        MyDbContext context,
        ISmsService sms
    )
    {
        _context = context;
        _sms = sms;
    }

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