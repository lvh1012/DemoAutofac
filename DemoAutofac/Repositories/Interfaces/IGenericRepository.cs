using DemoAutofac.Entities;

namespace DemoAutofac.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAll();
}