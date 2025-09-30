using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
	public class KullanicilarDTO:BaseDTO
	{
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciResim { get; set; }
        public string KullaniciEmail { get; set; }
        public string KullaniciSifre { get; set; }
        public bool PersonelMi { get; set; }
        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; }
    }
}
