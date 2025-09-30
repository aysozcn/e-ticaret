using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Sp_AdreslerWithMusteriDto
    {
        public int AdresId { get; set; }
        public int MusteriId { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string PostaKodu { get; set; }
        public bool AktifMi { get; set; }
        public DateTime EklenmeTarih { get; set; }
        public DateTime? GuncellenmeTarih { get; set; }
        public string MusteriAdiSoyadi { get; set; }
        public string IlceAdi { get; set; }
        public string IlAdi { get; set; }
    }
}
