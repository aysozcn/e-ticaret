using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Kullanicilar : BaseEntity
    {
        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string KullaniciResim { get; set; }

        public string KullaniciEmail { get; set; }

        public string KullaniciSifre { get; set; }

        public bool PersonelMi { get; set; }

        public int YetkiId { get; set; }

        //public int MusteriId { get; set; }

        //public int PersonelId { get; set; }

        public  Yetkiler Yetkiler { get; set; }//1 yetkide birden fazla kullanıcı olabilir ilişkisinde burda kullanıcı sonsuz tarafında yer alır

        public ICollection<Yorumlar> Yorumlar { get; set; }//1 kullanıcı 1 den fazla yorum yapabilir ilişkisinde burda kullanıcı 1 tarafında yer alır

        public ICollection<Siparisler> Siparisler { get; set; }//1 kullanıcı 1 den fazla sipariş yapabilir
        //public Musteriler Musteriler { get; set; }
        //public Personeller Personeller { get; set; }
        //public ICollection<Sepetler> Sepetler { get; set; }
       
        //************************Özel Durum--=> Tablonun kendisi ile bağlanması
        //public ICollection<Kullanicilar> Onaylayan { get; set; }
        //public Kullanicilar  OnayDurum { get; set; }


    }
}
