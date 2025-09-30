using ETicaret.Core.ETicaretDatabase;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.Configurations
{
    public class AdreslerConfiguration : IEntityTypeConfiguration<Adresler>
    {
        public void Configure(EntityTypeBuilder<Adresler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.AdresBasligi).IsRequired().HasMaxLength(50);
            builder.Property(k => k.Adres).IsRequired().HasMaxLength(500);
            builder.Property(k => k.PostaKodu).IsRequired(false);
            //builder.HasOne(k => k.Iller).WithOne(k => k.Adresler);
            builder.HasOne(k => k.Ilce).WithMany(k => k.Adresler).HasForeignKey(k=>k.IlceKodu);
            builder.HasOne(k => k.Musteriler).WithMany(k => k.Adresler).HasForeignKey(k => k.MusteriId);
            //***********************************
            /*
             Bağlantılar kontrol edilecek
             */

            //Merve
            //İkinci merve
        }
    }
}
