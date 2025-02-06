using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBank.Domain.Infrastructure.Define
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Create new entity functions 
        /// </summary>
        /// <param name="entities"></param>
        #region Create
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Add(T entity);
        Task AddAsync(T entity);
        #endregion

        /// <summary>
        /// Modified entity functions 
        /// </summary>
        /// <param name="entities"></param>
        #region Update

        void UpdateRange(IEnumerable<T> entities);
        void Update(T entity);

        #endregion

        /// <summary>
        /// Delete entity functions
        /// </summary>
        /// <param name="entity"></param>
        #region Delete

        void DeleteByEntity(T entity);
        void DeleteById(int id);
        void DeleteRange(IEnumerable<T> entities);
        void DeleteMulti(Expression<Func<T, bool>> where);

        #endregion

        /// <summary>
        /// Get entity functions
        /// </summary>
        /// <param name="id"> id, expression, includes</param>
        /// <returns>T/IEnumerable<T></returns>
        #region Get

        T GetSingleById(int id);
        Task<T> GetSingleByIdAsync(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);
        Task<IEnumerable<T>> GetAllAsync(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<IEnumerable<T>> GetMultiAsync(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int numPage = 1,
            int perPage = 10, string[] includes = null);

        #endregion
    }
}
