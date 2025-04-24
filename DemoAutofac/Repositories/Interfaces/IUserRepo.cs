namespace DemoAutofac.Repositories.Interfaces;

public interface IUserRepo: IRepo
{
    Task<int> HelloAsync();
}