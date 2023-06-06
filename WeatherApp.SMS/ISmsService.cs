namespace WeatherApp.SMS;

public interface ISmsService
{
    Task Send(string message, IEnumerable<string> phoneNumbers);
    Task SendAlert(string message, IEnumerable<string> phoneNumbers);
}