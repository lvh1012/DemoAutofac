using DemoAutofac.Attributes;
using DemoAutofac.Entities;
using DemoAutofac.Repositories.Interfaces;

namespace DemoAutofac.Repositories;

public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntity
{
    public Task<List<TEntity>> GetAll()
    {
        Console.WriteLine("Get All");
        return Task.FromResult(new List<TEntity>());
    }
}