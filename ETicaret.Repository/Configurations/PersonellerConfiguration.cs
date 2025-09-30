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
    public class PersonellerConfiguration : IEntityTypeConfiguration<Personeller>
    {
        public void Configure(EntityTypeBuilder<Personeller> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.PersonelAdi).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PersonelSoyadi).IsRequired().HasMaxLength(100);
            //builder.Property(p => p.Cinsiyeti).IsRequired().HasColumnType("bit");
            builder.Property(p => p.PersonelMaasi).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.MaasOdemeTarihi).IsRequired();
            builder.Property(p => p.CalistigiFirma).IsRequired();
            builder.Property(p => p.PersonelHakkinda).HasMaxLength(200).IsRequired();
            builder.Property(p => p.YasadigiSehir).IsRequired();
            //builder.HasOne(p => p.Kullanicilar).WithOne(p => p.Personeller).HasForeignKey<Kullanicilar>(p => p.PersonelId);
           // builder.HasOne(p => p.Kullanicilar).WithMany(p => p.Personeller).HasForeignKey(p => p.KullaniciId);
           // builder.HasOne(p => p.Siparisler).WithMany(p => p.Personeller).HasForeignKey(p => p.SiparisId);
            //builder.HasOne(p => p.Musteriler).WithMany(p => p.Personeller).HasForeignKey(p => p.MusteriId);
           
        }
    }
}
