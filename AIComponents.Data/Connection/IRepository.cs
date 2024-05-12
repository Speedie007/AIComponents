using AIComponents.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Data.Connection
{
    public interface IRepository<TEntity> where TEntity : NodeBaseContextEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity?> Get(int id);
        Task Insert(TEntity entity);
        Task Insert(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);
        Task Update(IEnumerable<TEntity> entities);
        Task Delete(TEntity entity);
        Task Delete(IEnumerable<TEntity> entities);

        //separate method SaveChangesAsync can be helpful when using this pattern with UnitOfWork
        Task SaveChangesAsync();
    }
}
