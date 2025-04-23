using DemoAutofac.Modules.Interfaces;

namespace DemoAutofac.Modules;

public class Car(IDriver driver) : IVehicle
{
    public void DoSomething()
    {
        Console.WriteLine("Car do something");
        driver.DoSomething();
    }
}