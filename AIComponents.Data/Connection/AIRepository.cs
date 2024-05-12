using AIComponents.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace AIComponents.Data.Connection
{
    public class AIRepository<TEntity> : IRepository<TEntity> where TEntity : NodeBaseContextEntity, new()
    {
        private readonly AIRepositoryContext _context;


        public AIRepository(AIRepositoryContext context)
        {
            _context = context;

        }

        public Task Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<TEntity>().Remove(entity);

            return Task.CompletedTask;

        }

        public Task Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            _context.Set<TEntity>().RemoveRange(entities);

            return Task.CompletedTask;
        }

        public async Task<TEntity?> Get(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await SaveChangesAsync();
        }

        public async Task Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            await SaveChangesAsync();
        }
    }
}
