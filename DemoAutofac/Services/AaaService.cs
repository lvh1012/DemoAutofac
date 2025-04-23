using DemoAutofac.Services.Interfaces;

namespace DemoAutofac.Services;

public class AaaService: IAaaService
{
    public void DoSomething()
    {
        Console.WriteLine("AaaService DoSomething");
    }
}