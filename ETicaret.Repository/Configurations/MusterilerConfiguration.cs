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
    public class MusterilerConfiguration : IEntityTypeConfiguration<Musteriler>
    {
        public void Configure(EntityTypeBuilder<Musteriler> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Adi).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Soyadi).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Cinsiyet).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Telefonu).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Meslek).IsRequired(false).HasDefaultValue(50);
            builder.Property(m => m.DogumTarihi).IsRequired();
            builder.HasMany(m => m.Siparisler).WithOne(m => m.Musteriler).HasForeignKey(m => m.MusteriId);
        }
    }
}
