using CommonDependencies;
using WeatherApp.Domain;
using WeatherApp.SMS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<MyDbContext>();
builder.Services.AddTransient<ISmsService, SmsService>();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblyContaining<WeatherAppDomainRef>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();