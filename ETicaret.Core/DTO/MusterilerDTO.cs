using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class MusterilerDTO : BaseDTO
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefonu { get; set; }
        public string Meslek { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}
