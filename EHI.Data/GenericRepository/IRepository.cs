using System.Linq;
using System.Threading.Tasks;

namespace EHI.Data.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}