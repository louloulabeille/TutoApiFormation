using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TutoApiformation.Infrastructure.Database;
using TutoApiformation.Interface.Repository;

namespace TutoApiformation.Infrastructure.Repository
{
    public class Repository<T>(TutoApiDbContext context) : IRepository<T> where T : class
    {
        #region private preoperties 
        private readonly TutoApiDbContext _context = context;
        #endregion


        #region implementation interface IRepository
        public T Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList<T>();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where<T>(predicate).ToList();
        }
        #endregion

        #region methode async
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        #endregion
    }

}
