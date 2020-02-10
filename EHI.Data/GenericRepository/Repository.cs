using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHI.Data.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            CommitChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await CommitChangesAsync();
            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            CommitChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await CommitChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            CommitChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await CommitChangesAsync();
        }
        public async Task AddRangeAsync(IList<T> entity)
        {
            _dbContext.Set<T>().AddRange(entity);
            await CommitChangesAsync();
        }

        public async Task DeleteRangeAsync(IList<T> entity)
        {
            _dbContext.Set<T>().RemoveRange(entity);
            await CommitChangesAsync();
        }


        private int CommitChanges()
        {
            return _dbContext.SaveChanges();
        }

        private async Task<int> CommitChangesAsync()
        {

            return await _dbContext.SaveChangesAsync();
        }
    }
}