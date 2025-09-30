using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.core.ETicaretDtabase
{
    public class ExixtsStoredProcedure
    {
        //AppDbContext db = new AppDbContext();

        //public string Sp_AdresMusteriIl()
        //{
        //    try
        //    {
        //        string sql = @"CREATE PROCEDURE Sp_GetMusteriAdresBilgileri
        //                 as
        //                 begin
        //                SELECT    
        //                    a.Id AS AdresId, a.AdresBasligi, a.Adres, a.PostaKodu, a.AktifMi, a.EklenmeTarih, 
        //                    m.Adi + ' ' + m.Soyadi AS MusteriAdiSoyadi, m.Id AS MusteriId, 
        //                    il.IlAdi,  ilce.IlceAdi   
        //                  FROM Adresler  a  
        //                  INNER JOIN Musteriler m ON a.MusteriId = m.Id    
        //                  INNER JOIN Ilceler ilce ON a.IlceKodu = ilce.IlceKodu    
        //                  INNER JOIN Iller il ON ilce.IlKodu = il.IlKodu
        //               end";
        //        var list = db.Database.ExecuteSqlRaw(sql);
        //        return "Sp_GetMusteriAdresBilgileri başarılı bir şekilde oluşturuldu";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "HATA:" + ex.Message;
        //    }
        //}
    }
}
