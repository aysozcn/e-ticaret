using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IUrunlerRepository : IGenericRepository<Urunler>
    {
        //Eğer ki IGenericRepository de yer alan meethod dışında bir methoda ihtiyaç varsa Urunler için burda tanımlanır

        Task<List<Urunler>> GetUrunlerWithKategoriAsync();

        Task<Urunler> GetUrunlerWithKategoriAsync(int urunlerId);


        /*
        Task<List<Urunler>> GetUrunlerWithKategoriandFotoandYorum();        
        Task<Urunler> GetUrunlerWithCountYorum(int urunlerId);
        Task<Urunler> GetUrunlerWithCountFotograf(int urunlerId);
        Yukardaki yapılar yerine SP kullanılacak
        */
    }
}
