using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Personeller:BaseEntity
    {
        public string PersonelAdi { get; set; }

        public string PersonelSoyadi { get; set; }

        public string Cinsiyet { get; set; }

        public decimal PersonelMaasi { get; set; }

        public DateTime MaasOdemeTarihi { get; set; }

        public bool MedeniHali { get; set; }

        public string CalistigiFirma { get; set; }

        public string PersonelHakkinda { get; set; }

        public string YasadigiSehir { get; set; }

        public int Kullanici_Id { get; set; }

        public int PersonelKullaniciBilgileriId { get; set; }

        public  Kullanicilar Kullanicilar { get; set; }//Personeli ekleyen Kullanıcı

        public Kullanicilar PersonelKullaniciBilgileri { get; set; }//Personelin Login için kullandığı Kullanıcı bilgilerini tutar
        //public virtual Siparisler Siparisler { get; set; }//1 kullanıcı 1 den fazla siparişi alabilir
        //public  Musteriler Musteriler { get; set; }//1 personelin 1 den fazla müşterisi olabilir
    }
}
