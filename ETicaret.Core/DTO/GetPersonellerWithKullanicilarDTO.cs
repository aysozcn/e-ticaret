using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
	public class GetPersonellerWithKullanicilarDTO:BaseListDTO
	{
        public int KId { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }
        public string Cinsiyet { get; set; }
        public decimal PersonelMaasi { get; set; }
        public string CalistigiFirma { get; set; }
        public string YasadigiSehir { get; set; }
        public bool PersonelMi { get; set; }
        public KullanicilarDTO kullanicilar { get; set; }
       


    }
}
