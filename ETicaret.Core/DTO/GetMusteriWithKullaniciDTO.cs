using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class GetMusteriWithKullaniciDTO
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefonu { get; set; }
        public string Meslek { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string KullaniciAdi { get; set; }// Kullanıcı tablosunda'da adi var. Çakışma oluyor.
        public string KullaniciSoyadi { get; set; }
        public string KullaniciResim { get; set; }
        public string KullaniciEmail { get; set; }
        //public string KullaniciSifre { get; set; }
    }
}
