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
    public class ErisimAlanlariConfiguration : IEntityTypeConfiguration<ErisimAlanlari>
    {
        public void Configure(EntityTypeBuilder<ErisimAlanlari> builder)
        {
            //ErisimAlanlari=> Erişim Sayfaları

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.AktifMi).IsRequired();
            builder.Property(e => e.ControllerAdi).IsRequired().HasMaxLength(128);
            builder.Property(e => e.ViewAdi).IsRequired().HasMaxLength(128);
            builder.Property(e => e.Aciklama).IsRequired(false);
            //builder.HasOne(e => e.YetkiErisimleri).WithMany(e => e.ErisimAlanlari).HasForeignKey(e => e.YetkiErisimId);
            //builder.HasMany(e=>e.YetkiErisimleri)
           // builder.HasOne(k => k.Menular).WithOne(k => k.ErisimAlanlari).HasForeignKey<Menular>(k => k.ErisimAlanlariId);
        }
    }
}
