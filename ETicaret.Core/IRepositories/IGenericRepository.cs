using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //Asenkron bir yapıya göre işlem yapılarak
        //Asenkron sırasıyla gerçekleşmesi gereken işlemleri sıraya tabi tutmadan aynı anda bütün işlemeri gerçekleştirmeyi sağlar. Data ların hızlı çekilmesini sağlar
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity,bool>> expression);
        IQueryable<TEntity> GetAll();   
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllQueryAsync(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    }
}
