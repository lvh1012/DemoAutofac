using DemoAutofac.Entities;
using DemoAutofac.Modules.Interfaces;
using DemoAutofac.Repositories.Interfaces;
using DemoAutofac.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoAutofac.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IUserRepo  _userRepo;
    private readonly IBbbService _bbbService;
    private readonly IGenericRepository<User> _user;
    private readonly IVehicle _vehicle;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                     IUserRepo userRepo,
                                     IBbbService bbbService,
                                     IGenericRepository<User> user,
                                     IVehicle vehicle)
    {
        _logger = logger;
        _userRepo = userRepo;
        _bbbService = bbbService;
        _user = user;
        _vehicle = vehicle;
        _userRepo.Hello();
        _bbbService.DoSomething();
        _bbbService.Test();
        _user.GetAll();
        _vehicle.DoSomething();
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
                             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                             TemperatureC = Random.Shared.Next(-20, 55),
                             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                         })
                         .ToArray();
    }
}