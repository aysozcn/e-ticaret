using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IUnitOfWork;
using ETicaret.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.Services
{
    public class SiparislerService : Service<Siparisler>
    {
       

            private readonly ISiparislerRepository _siparisRepository;

            public SiparislerService(IGenericRepository<Siparisler> siparisRepository, IUnitOfWork unitOfWork): base(siparisRepository, unitOfWork) 
            {
                _siparisRepository = (ISiparislerRepository?)siparisRepository;
            }

            public Urunler GetProduct(int kullaniciId)
            {
                // Ürünü veritabanından al
                // Bu sadece örnek bir metoddur, gerçek uygulama bağlamına göre değiştirilmelidir.
                // Eğer ürün bulunamazsa null dönebilir.
                return new Urunler(); // Örnek bir Product nesnesi döndürüldü.
            }

            public Siparisler CreateSiparis(Kullanicilar Kullanici, Urunler urun, int toplamUrunAdet)
            {
                // Siparişi veritabanına ekle
                // Bu sadece örnek bir metoddur, gerçek uygulama bağlamına göre değiştirilmelidir.
                Siparisler newSiparis = new Siparisler
                {
                    KullaniciId = Kullanici.Id,
                    UrunId = urun.Id,
                    ToplamUrunAdet = toplamUrunAdet,
                    SiparisTarihi = DateTime.Now
                };

                _siparisRepository.AddSiparis(newSiparis); // Veritabanına siparişi ekle

                return newSiparis;
            }
        
    }

        public class OrderRepository
        {
            // Bu sadece örnek bir veritabanı işlemidir, gerçek bir veritabanı kullanılmalıdır.
            private List<Siparisler> _orders = new List<Siparisler>();

            public void AddOrder(Siparisler siparisler)
            {
                _orders.Add(siparisler);
            }
        }

       

    }


