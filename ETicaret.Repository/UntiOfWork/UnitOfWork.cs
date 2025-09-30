using ETicaret.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.UntiOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _eTicaretDB;//ETicaretCoreDB veritabanı adı AppDbContext olarak vermiştik

        public UnitOfWork( AppDbContext context)
        {
            _eTicaretDB = context;
        }
        public void Commit()
        {
            _eTicaretDB.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _eTicaretDB.SaveChangesAsync();
        }
    }
}
