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
    public class SiparislerConfiguration : IEntityTypeConfiguration<Siparisler>
    {
        public void Configure(EntityTypeBuilder<Siparisler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.EklenmeTarih).IsRequired();
            builder.Property(k => k.ToplamUrunAdet).IsRequired();
            builder.Property(k => k.ToplamFiyat).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(k => k.MusteriId).IsRequired();
            builder.HasMany(k => k.SiparisDetay).WithOne(k => k.Siparisler).HasForeignKey(k => k.SiparisId);

        }
    }
}
