using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
	public class GetKullanicilarWithMusterilerDTO:BaseListDTO
	{
		public Kullanicilar kullanicilar { get; set; }

		public string  MusteriAdi { get; set; }

        public string MusteriSoyadi { get; set; }

        public string MusteriMeslek { get; set; }
    }
}
