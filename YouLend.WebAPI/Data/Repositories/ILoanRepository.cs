using System.Threading.Tasks;

namespace YouLend.WebAPI.Data.Repositories
{
    public interface ILoanRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> SaveAsync(T entity);
    }
}
