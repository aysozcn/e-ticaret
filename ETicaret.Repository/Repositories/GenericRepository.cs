using ETicaret.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _eTicaretDB;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext eTicaretDB)
        {
            _eTicaretDB = eTicaretDB;
            _dbSet = _eTicaretDB.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
        }        

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
            //Tracking=>datayı anlık almak için kullanılır, AsNoTracking()=> anlık olarak kontrol etme
            //avantajı hızdır, dezavantajı => son yapılan işlemler yansımaz
            //RabbitMQ, ElasticSearch, DockerContainer=> 
            //

        }

        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
           //_eTicaretDB.Entry(entity).State = EntityState.Deleted;

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);

        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            //_eTicaretDB.Entry(entity).State=EntityState.Modified;
        }




        public async Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> whereCondition)
        {
            try
            {
                IQueryable<TEntity> dbSet = _eTicaretDB.Set<TEntity>();
                return await dbSet.FirstOrDefaultAsync(whereCondition);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Bir Hata Olustu: {e.Message}");
                throw;
            }
        }

        //SOLID prensiplerine göre aşağıda bir class içinde mevcut yer alan methodların değiştirilmemesi gereklidir ama class'a yeni method eklenebilir
        //Open/Closed=> içinde ter alan methodlara yeni bir method eklenebilir, olan methodları değiştirmeye kesinlikle kapalı olmalıdır
        public async Task<IEnumerable<TEntity>> GetAllQueryAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}
