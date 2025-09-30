using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
	public class GetKullanicilarWithYetkilerDTO:BaseListDTO
	{
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public bool PersonelMi { get; set; }
        public YetkilerDTO yetkiler { get; set; }
        public int YetkiId { get; set; }
       

    }
}
