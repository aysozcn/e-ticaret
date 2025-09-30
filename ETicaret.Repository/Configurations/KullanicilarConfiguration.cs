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
    public class KullanicilarConfiguration : IEntityTypeConfiguration<Kullanicilar>
    {
        public void Configure(EntityTypeBuilder<Kullanicilar> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Adi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Soyadi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.KullaniciResim).IsRequired(false);
            builder.Property(k => k.KullaniciEmail).IsRequired(false);
            builder.Property(k => k.KullaniciSifre).IsRequired(false);
            builder.Property(k => k.PersonelMi).IsRequired();//.HasColumnType("bit");//bool=> C# => bit
            //builder.HasOne(k => k.Yetkiler).WithMany(k => k.Kullanicilar).HasForeignKey(k => k.YetkiId);
            //builder.HasOne(k => k.Musteriler).WithOne(k => k.Kullanicilar).HasForeignKey<Musteriler>(k => k.KullaniciId);
            builder.HasOne(k => k.Yetkiler).WithMany(k => k.Kullanicilar).HasForeignKey(k => k.YetkiId);
            builder.HasMany(k => k.Yorumlar).WithOne(k => k.Kullanicilar).HasForeignKey(k => k.KullaniciId);
            builder.HasMany(k => k.Siparisler).WithOne(k => k.Kullanicilar).HasForeignKey(k => k.KullaniciId);
          
            //********************************************************************************
            //Tablonun kendisi ile bağlanması
            //builder.HasOne(k => k.OnayDurum).WithMany(k => k.Onaylayan).HasForeignKey(k => k.KullaniciId);
            //builder.HasOne(k => k.Personeller).WithOne(k => k.PersonelKullaniciBilgileri).HasForeignKey<Personeller>(k => k.PersonelKullaniciBilgileriId);
        }
    }
}
