using EBank.Domain.Context;
using EBank.Domain.Infrastructure.Define;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Infrastructure.Implement
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Properties

        private EBankDbContext dataContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected EBankDbContext DbContext
        {
            get { return dataContext ??= DbFactory.Init(); }
        }
        #endregion

        protected Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implement

        public virtual void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            dbSet.UpdateRange(entities);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual void DeleteByEntity(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void DeleteById(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<T> GetSingleByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return dataContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return await query.FirstOrDefaultAsync(expression);
            }
            return await dataContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return dataContext.Set<T>().AsQueryable();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return await query.ToListAsync();
            }

            return await dataContext.Set<T>().ToListAsync();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int numPage = 1, int perPage = 10,
            string[] includes = null)
        {
            numPage--;
            int skipCount = numPage * perPage;
            IQueryable<T> _restSet;
            if (includes == null && includes.Length > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }
                _restSet = expression != null ? query.Where<T>(expression).AsQueryable() : dataContext.Set<T>()
                    .AsQueryable();
            }
            else
            {
                _restSet = expression != null
                    ? dataContext.Set<T>().Where<T>(expression).AsQueryable()
                    : dataContext.Set<T>().AsQueryable();
            }

            _restSet = skipCount == 0 ? _restSet.Take(perPage) : _restSet.Skip(skipCount).Take(perPage);
            total = _restSet.Count();

            return _restSet.AsQueryable();
        }

        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(expression).AsQueryable<T>();
            }

            return dataContext.Set<T>().Where<T>(expression).AsQueryable<T>();
        }

        public virtual async Task<IEnumerable<T>> GetMultiAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return await query.Where<T>(expression).ToListAsync<T>();
            }

            return await dataContext.Set<T>().Where<T>(expression).ToListAsync<T>();
        }
        #endregion
    }
}
