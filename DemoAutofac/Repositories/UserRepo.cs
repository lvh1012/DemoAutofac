using DemoAutofac.Repositories.Interfaces;

namespace DemoAutofac.Repositories;

public class UserRepo: IUserRepo
{
    public void Hello()
    {
        Console.WriteLine("Hello From UserRepo");
    }
}