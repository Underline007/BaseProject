namespace BaseProject.Infrastructure.Common
{
    using BaseProject.Application.Common;
    using BaseProject.Domain.Common.Models;
    using BaseProject.Domain.Common.Specifications;
    using BaseProject.Infrastructure.Contexts;
    using BaseProject.Infrastructure.Exceptions;
    using Microsoft.EntityFrameworkCore;
    using System.Data;

    namespace AssetManagement.Infrastructure.Common
    {
        public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
        {
            public readonly ApplicationDbContext _dbContext;

            public BaseRepositoryAsync(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<T> AddAsync(T entity)
            {
                await _dbContext.Set<T>().AddAsync(entity);
                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    throw new RepositoryException("An error occurred while adding the entity.", ex);
                }
                return entity;
            }

            public async Task<int> CountAsync(ISpecification<T> spec)
            {
                return await ApplySpecification(spec).CountAsync();
            }

            public async Task<T> DeleteAsync(Guid id)
            {
                var entity = await GetByIdAsync(id);
                if (entity == null)
                {
                    return null;
                }
                entity.IsDeleted = true;
                await UpdateAsync(entity);
                return entity;
            }

            public async Task<T> DeletePermanentAsync(Guid id)
            {
                var entity = await GetByIdAsync(id);
                if (entity == null)
                {
                    return null;
                }

                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }

            public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
            {
                return await ApplySpecification(spec).FirstOrDefaultAsync();
            }

            public virtual async Task<T> GetByIdAsync(Guid id)
            {
                var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
                if (entity == null)
                {
                    return null;
                }
                return entity;
            }

            public async Task<List<T>> ListAllAsync()
            {
                return await _dbContext.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
            }

            public async Task<IList<T>> ListAsync(ISpecification<T> spec)
            {
                return await ApplySpecification(spec).ToListAsync();
            }

            public async Task<T> UpdateAsync(T entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }

            private IQueryable<T> ApplySpecification(ISpecification<T> spec)
            {
                return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
            }
        }
    }
}
