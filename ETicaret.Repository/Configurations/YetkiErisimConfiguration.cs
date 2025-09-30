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
    public class YetkiErisimConfiguration : IEntityTypeConfiguration<YetkiErisim>
    {
        public void Configure(EntityTypeBuilder<YetkiErisim> builder)
        {
            builder.HasKey(y=>new
            {
                y.ErisimAlaniId,
                y.YetkiId
            });
            //builder.HasKey(y => y.ErisimAlaniId);
            //builder.HasKey(y => y.YetkiId);

            builder.Property(k => k.Aciklama).IsRequired(false);
            builder.Property(k => k.EklenmeTarihi).IsRequired();

            builder.HasOne(k => k.ErisimAlanlari).WithMany(k => k.YetkiErisimleri).HasForeignKey(k => k.ErisimAlaniId);
            builder.HasOne(k => k.Yetkiler).WithMany(k => k.YetkiErisimleri).HasForeignKey(k => k.YetkiId);
            //
        }
    }
}
