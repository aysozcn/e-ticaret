using ETicaret.Core.ETicaretDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.Configurations
{
    public class SepetlerConfiguration : IEntityTypeConfiguration<Sepetler>
    {
        //public void Configure(EntityTypeBuilder<Sepetler> builder)
        //{
        //    builder.HasKey(k => k.Id);
        //    builder.Property(k => k.Id).UseIdentityColumn();
        //    builder.Property(k => k.UrunAdi).IsRequired();
        //    builder.Property(k => k.UrunAdet).IsRequired();
        //    builder.Property(k=>k.UrunFiyati).IsRequired().HasColumnType("decimal(18,2)");
        //    builder.Property(k => k.OdemeSekli).IsRequired();
        //    builder.Property(k=>k.ToplamOdeme).IsRequired().HasColumnType("decimal(18,2)");
        //    builder.Property(k=>k.urunId).IsRequired();
        //    builder.Property(k=>k.KargoAdresi).IsRequired();
        //    builder.Property(k=>k.KartNumarasi).IsRequired();
        //    builder.Property(k=>k.SiparisDurumu).IsRequired();
        //    builder.Property(k => k.MusteriNot).IsRequired(false);
        //    //builder.HasMany(k => k.Urunler).WithOne(k => k.sepetler).HasForeignKey(k => k.SepetId);
        //    //builder.HasMany(k => k.Siparisler).WithOne(k => k.Sepetler).HasForeignKey(k => k.SepetId);
        //    //builder.HasOne(k => k.kullanicilar).WithMany(k => k.Sepetler).HasForeignKey(k => k.KullaniciId);
        //}
    }
}
