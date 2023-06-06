namespace WeatherApp.SMS;

public interface ISmsService
{
    Task Send(string message, IEnumerable<string> phoneNumbers);
}