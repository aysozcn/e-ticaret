using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
	public class PersonellerDTO:BaseDTO
	{
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string Cinsiyet { get; set; }
        public decimal PersonelMaasi { get; set; }
        public DateTime MaasOdemeTarih { get; set; }
        public bool MedeniHali { get; set; }
        public string CalistigiFirma { get; set; }
        public string Hakkinda { get; set; }
        public string YasadigiSehir { get; set; }
        public int KullaniciBilgileriId { get; set; }
        public int KullaniciId { get; set; }
        public string  KullaniciAdSoyad { get; set; }
    }
}
