using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsyncs();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllQueryAsync(Expression<Func<TEntity, bool>> expression);
        //Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
//*************************************NOTLARIM******************************
//GetAllQuery: Belirli bir şartı sağlayan tüm varlıkları sorgular.
//GetAllAsyncs: Tüm varlıkları asenkron olarak getirir.
//GetByIdAsync: Belirli bir kimliğe sahip varlığı asenkron olarak getirir.
//AnyAsync: Belirli bir şartı sağlayan herhangi bir varlık olup olmadığını kontrol eder.
//AddAsync: Yeni bir varlık ekler.
//AddRangeAsync: Birden çok varlığı asenkron olarak ekler.
//UpdateAsync: Varlık güncellemesini gerçekleştirir.
//RemoveAsync: Belirli bir varlığı asenkron olarak kaldırır.
//RemoveRangeAsync: Birden çok varlığı asenkron olarak kaldırır.GetAllQuery: Belirli bir şartı sağlayan tüm varlıkları sorgular.
//GetAllAsyncs: Tüm varlıkları asenkron olarak getirir.
//GetByIdAsync: Belirli bir kimliğe sahip varlığı asenkron olarak getirir.
//AnyAsync: Belirli bir şartı sağlayan herhangi bir varlık olup olmadığını kontrol eder.
//AddAsync: Yeni bir varlık ekler.
//AddRangeAsync: Birden çok varlığı asenkron olarak ekler.
//UpdateAsync: Varlık güncellemesini gerçekleştirir.
//RemoveAsync: Belirli bir varlığı asenkron olarak kaldırır.
//RemoveRangeAsync: Birden çok varlığı asenkron olarak kaldırır.