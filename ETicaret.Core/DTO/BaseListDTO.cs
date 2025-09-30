using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
	public class BaseListDTO
	{
		public int Id { get; set; }
		public bool AktifMi { get; set; }
		public DateTime EklenmeTarih { get; set; }
		public DateTime? GuncellenmeTarih { get; set; }
		public int? KullaniciId { get; set; }
	}
}
