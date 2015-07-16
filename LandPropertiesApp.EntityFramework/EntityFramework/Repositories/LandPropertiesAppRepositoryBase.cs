using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace LandPropertiesApp.EntityFramework.Repositories
{
    public abstract class LandPropertiesAppRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<LandPropertiesAppDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected LandPropertiesAppRepositoryBase(IDbContextProvider<LandPropertiesAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class LandPropertiesAppRepositoryBase<TEntity> : LandPropertiesAppRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected LandPropertiesAppRepositoryBase(IDbContextProvider<LandPropertiesAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
