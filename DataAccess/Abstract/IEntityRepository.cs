using Entities.Abstract;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
        void Create(T entity);
    }
}
