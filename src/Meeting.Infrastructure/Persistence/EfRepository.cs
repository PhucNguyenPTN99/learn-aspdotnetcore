using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Meeting.Core.Entities.Common;
using Meeting.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meeting.Infrastructure.Persistence
{
    public class EfRepository<TEntity> : BaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly MeetingDbContext DbContext;
        
        public EfRepository(
            ICurrentUserService currentUserService, 
            MeetingDbContext dbContext) : base(currentUserService)
        {
            DbContext = dbContext;
        }

        public override async Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<TEntity>()
                .SingleAsync(entity => entity.Id == id, cancellationToken);
        }

        public override async Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<TEntity>()
                .ToListAsync(cancellationToken);
        }

        protected override async Task<TEntity> CreateEntityAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var added = await DbContext
                .Set<TEntity>()
                .AddAsync(entity, cancellationToken);

            await DbContext.SaveChangesAsync(cancellationToken);
            
            return added.Entity;
        }

        protected override async Task<TEntity> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var updated = DbContext
                .Set<TEntity>()
                .Update(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(updated.Entity);
        }

        protected override async Task<bool> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken)
        {
            DbContext
                .Set<TEntity>()
                .Remove(entity);
            
            await DbContext.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(true);
        }
    }
}