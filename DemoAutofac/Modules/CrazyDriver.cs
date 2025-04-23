using DemoAutofac.Modules.Interfaces;

namespace DemoAutofac.Modules;

public class CrazyDriver : IDriver
{
    public void DoSomething()
    {
        Console.WriteLine("CrazyDriver do something");
    }
}