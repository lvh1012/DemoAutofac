using Autofac.Extras.DynamicProxy;
using DemoAutofac.Interceptors;
using DemoAutofac.Services.Interfaces;

namespace DemoAutofac.Services;

// This attribute will look for a TYPED
// interceptor registration:
// [Intercept(typeof(CallLogger))]
public class AaaService: IAaaService
{
    public void DoSomething()
    {
        Console.WriteLine("AaaService DoSomething");
    }
}