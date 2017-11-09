using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace PluginsSystemHangfire.EntityFramework.Repositories
{
    public abstract class ServiceRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ServiceDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ServiceRepositoryBase(IDbContextProvider<ServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ServiceRepositoryBase<TEntity> : ServiceRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ServiceRepositoryBase(IDbContextProvider<ServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
