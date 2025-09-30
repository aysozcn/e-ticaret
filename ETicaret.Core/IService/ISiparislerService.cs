﻿using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    internal interface ISiparislerService : IService<Siparisler>
    {
        Task<List<Siparisler>> GetSiparislerMadeTodayAsync(DateTime siparisTarihi);
        Task<List<Siparisler>> GetSiparislerWithKullanicilarAsync(Kullanicilar kullaniciID);
        Task<List<Siparisler>> GetSiparislerWithMusterilerAsync(Musteriler musteriID);
    }
}
