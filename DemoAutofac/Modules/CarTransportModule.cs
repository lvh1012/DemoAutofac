using Autofac;
using Autofac.Core.Registration;
using DemoAutofac.Modules.Interfaces;

namespace DemoAutofac.Modules;

public class CarTransportModule : Module
{
    public bool ObeySpeedLimit { get; set; }

    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c => new Car(c.Resolve<IDriver>())).As<IVehicle>().InstancePerLifetimeScope();

        if (ObeySpeedLimit)
        {
            builder.Register(c => new SaneDriver()).As<IDriver>().InstancePerLifetimeScope();
        }
        else
        {
            builder.Register(c => new CrazyDriver()).As<IDriver>().InstancePerLifetimeScope();
        }
    }
}