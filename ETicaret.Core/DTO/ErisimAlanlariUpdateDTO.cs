using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class ErisimAlanlariUpdateDTO : BaseListDTO
    {
        public string ControllerAdi { get; set; }
        public string ViewAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
