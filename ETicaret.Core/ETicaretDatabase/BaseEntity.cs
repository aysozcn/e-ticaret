using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public abstract class BaseEntity
    {

        public int Id { get; set; }
        public bool AktifMi{ get; set; }
        public DateTime EklenmeTarih{ get; set; }
        public DateTime? GuncellenmeTarih { get; set; }
        public int? KullaniciId { get; set; }

    }
}
