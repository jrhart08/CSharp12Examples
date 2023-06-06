namespace WeatherApp.SMS;

public class SmsService : ISmsService
{
    public async Task Send(string message, IEnumerable<string> phoneNumbers)
    {
        Console.WriteLine($"Sending message to recipients");
    }

    public async Task SendAlert(string message, IEnumerable<string> phoneNumbers)
    {
        Console.WriteLine($"Sending alert to recipients");
    }
}