using DemoAutofac.Modules.Interfaces;

namespace DemoAutofac.Modules;

public class SaneDriver : IDriver
{
    public void DoSomething()
    {
        Console.WriteLine("SaneDriver do something");
    }
}