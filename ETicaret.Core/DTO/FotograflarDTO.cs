using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class FotograflarDTO : BaseDTO
    {
        public string FotografYolu { get; set; }

        public string FotografAciklamasi { get; set; }

        public byte? FotografSirasi { get; set; }

        public int UrunId { get; set; }
    }
}
