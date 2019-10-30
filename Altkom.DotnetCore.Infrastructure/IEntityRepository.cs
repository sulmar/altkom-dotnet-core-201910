using System.Collections.Generic;

namespace Altkom.DotnetCore.Infrastructure
{
    public interface IEntityRepository<TEntity, TKey>
    {
        bool IsExists(TKey id);
        IEnumerable<TEntity> Get();
        TEntity Get(TKey id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TKey id);
    }


}
