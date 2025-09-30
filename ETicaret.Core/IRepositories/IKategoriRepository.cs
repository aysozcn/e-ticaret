using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IKategoriRepository : IGenericRepository<Kategoriler>
    {
        //Task<List<Kategoriler>> KategoriListeleAsync();
        //Task<string> KategoriEkleAsync(string kategoriAdi, string aciklama);
        //Task<string> KategoriGuncelleAsync(int id, string kategoriAdi, string aciklama);
        Task<Kategoriler> KategoriSilAsync(int id);


    }
}
