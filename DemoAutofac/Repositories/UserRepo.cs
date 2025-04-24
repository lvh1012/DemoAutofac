using Autofac.Extras.DynamicProxy;
using DemoAutofac.Attributes;
using DemoAutofac.Interceptors;
using DemoAutofac.Repositories.Interfaces;

namespace DemoAutofac.Repositories;

public class UserRepo: IUserRepo
{
    public void Hello()
    {
        Console.WriteLine("Hello From UserRepo");
    }

    [Transaction]
    public Task<int> HelloAsync()
    {
        Console.WriteLine("Hello From UserRepo");
        return Task.FromResult(42);
    }
}