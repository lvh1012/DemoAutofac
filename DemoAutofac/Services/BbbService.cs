using Autofac.Extras.DynamicProxy;
using DemoAutofac.Services.Interfaces;

namespace DemoAutofac.Services;

// This attribute will look for a NAMED
// interceptor registration:
[Intercept("log-calls")]
public class BbbService(IAaaService aaaService): IBbbService
{
    public void DoSomething()
    {
        Console.WriteLine("BbbService DoSomething");
    }

    public void Test()
    {
        Console.WriteLine("BbbService Test");
    }
}