using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DemoAutofac.Interceptors;
using DemoAutofac.Modules;
using DemoAutofac.Repositories;
using DemoAutofac.Repositories.Interfaces;
using DemoAutofac.Services;
using DemoAutofac.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Replace built-in DI container with Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Autofac registrations go here
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // When you register components, you have to tell Autofac which services (Interface) that component exposes.
    containerBuilder.RegisterType<UserRepo>()
                    .As<IUserRepo>()
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(CallLogger))
                    .InstancePerLifetimeScope();

    var dataAccess = Assembly.GetExecutingAssembly();

    // containerBuilder.RegisterAssemblyTypes(dataAccess)
    //                 .Where(t => t.Name.EndsWith("Repo"))
    //                 .AsImplementedInterfaces()
    //                 .InterceptedBy(typeof(CallLogger))
    //                 .InstancePerLifetimeScope();

    containerBuilder.RegisterType<AaaService>()
                    .As<IAaaService>()
                    .EnableInterfaceInterceptors()
                    .InstancePerLifetimeScope();
    containerBuilder.Register((IAaaService aaaService) => new BbbService(aaaService) )
                    .As<IBbbService>()
                    .EnableInterfaceInterceptors()
                    // .InterceptedBy(typeof(CallLogger))
                    .InstancePerLifetimeScope();

    // containerBuilder.RegisterGeneric(typeof(GenericRepository<>))
    //                 .As(typeof(IGenericRepository<>))
    //                 .InstancePerLifetimeScope();

    containerBuilder.RegisterAssemblyOpenGenericTypes(dataAccess)
                    .Where(t =>true)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

    containerBuilder.RegisterModule(new CarTransportModule() {
        ObeySpeedLimit = true
    });

    containerBuilder.Register(c => new CallTransaction(Console.Out))
                    .As<IAsyncInterceptor>()
                    .InstancePerLifetimeScope();

    // Named registration
    containerBuilder.Register(c => new CallLogger(Console.Out, c.Resolve<IAsyncInterceptor>()))
           .Named<IInterceptor>("log-calls")
           .InstancePerLifetimeScope();

    // Typed registration
    containerBuilder.Register(c => new CallLogger(Console.Out, c.Resolve<IAsyncInterceptor>()))
        .InstancePerLifetimeScope();

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