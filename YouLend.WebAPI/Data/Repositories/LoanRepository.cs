﻿using System.Threading.Tasks;

namespace YouLend.WebAPI.Data.Repositories
{
    public class LoanRepository<T> : ILoanRepository<T> where T : class
    {
        private readonly WebAPIContext _context;

        public LoanRepository(WebAPIContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
