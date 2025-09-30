using AutoMapper;//AutoMapper.Extention.MS.DI
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.Mapping
{

  
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Urunler, UrunlerDTO>().ReverseMap();
            //Urunler nesnesi yerine UrunlerDTO nesnesi kullanılacak anlamına geliyor, ReverseMap ise bu olayın tam tersi de gerçekleşebiliri yani UrunlerDTO yerine Urunler nesnesi kullanılabilir
            CreateMap<Urunler,GetUrunlerWithKategoriDTO>().ReverseMap();
            CreateMap<Urunler, UrunlerUpdateDTO>().ReverseMap();
            //CreateMap<Kategoriler,KategorilerDTO>().ReverseMap();

            CreateMap<Kullanicilar, KullanicilarDTO>().ReverseMap();
            CreateMap<Kullanicilar, GetKullanicilarWithPersonellerDTO>().ReverseMap();
            CreateMap<Kullanicilar, GetKullanicilarWithMusterilerDTO>().ReverseMap();
            CreateMap<Kullanicilar, GetKullanicilarWithYetkilerDTO>().ReverseMap();
           
            CreateMap<Personeller, PersonellerDTO>().ReverseMap();
            CreateMap<Personeller, GetPersonellerWithKullanicilarDTO>().ReverseMap();
            CreateMap<Fotograflar, FotograflarDTO>().ReverseMap();
            CreateMap<Fotograflar, GetFotograflarWithUrunlerDTO>().ReverseMap();
            CreateMap<Fotograflar, FotografGuncelleDTO>().ReverseMap();

            //CreateMap<Urunler, GetUrunlerWithKategoriDTO>().ReverseMap();
            CreateMap<Siparisler, GetSiparislerWithMusterilerDTO>().ReverseMap();

            CreateMap<Yetkiler, YetkilerDTO>().ReverseMap();
            CreateMap<Yetkiler, YetkilerUpdateDTO>().ReverseMap();
            CreateMap<Yetkiler, GetYetkilerWithErisimAlaniDTO>().ReverseMap();

            CreateMap<ErisimAlanlari, GetErisimAlanlariWithYetkiDTO>().ReverseMap();
            CreateMap<ErisimAlanlari, ErisimAlanlariDTO>().ReverseMap();
            CreateMap<ErisimAlanlari, ErisimAlanlariUpdateDTO>().ReverseMap();
            CreateMap<Yorumlar,YorumlarDTO>().ReverseMap();
            CreateMap<Yorumlar, GetYorumlarWithKullanicilarDTO>().ReverseMap();
            CreateMap<Yorumlar, GetYorumlarWithUrunlerDTO>().ReverseMap();
           //CreateMap<Menular, MenulerDTO>().ReverseMap();
            //CreateMap<Menular, GetMenulerWithErisimAlanDTO>().ReverseMap();
            //CreateMap<Menular, MenulerUpdateDTO>().ReverseMap();
            CreateMap<Musteriler, MusterilerDTO>().ReverseMap();
            CreateMap<Musteriler, MusterilerUpdateDTO>().ReverseMap();
            CreateMap<Musteriler, GetMusteriWithKullaniciDTO>().ReverseMap();
            CreateMap<Musteriler, GetMusteriWithSiparisDTO>().ReverseMap();
            CreateMap<Musteriler, GetMusterilerWithAdresDTO>().ReverseMap();
            CreateMap<Urunler, GetUrunlerWithKategoriDTO>().ReverseMap();
            CreateMap<Adresler, GetAdreslerWithMusteriDTO>().ReverseMap();
            CreateMap<Adresler, AdreslerAddDTO>().ReverseMap();
            CreateMap<Adresler, AdreslerUpdateDTO>().ReverseMap();
            CreateMap<Kategoriler, KategoriDTO>().ReverseMap();
            CreateMap<Iller, IlDto>().ReverseMap();
            CreateMap<Ilceler, IlceDTO>().ReverseMap();



        }

    }
}
