using DemoAutofac.Services.Interfaces;

namespace DemoAutofac.Services;

public class BbbService(IAaaService aaaService): IBbbService
{
    public void DoSomething()
    {
        Console.WriteLine("BbbService DoSomething");
    }
}