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
    public class YetkilerConfiguration : IEntityTypeConfiguration<Yetkiler>
    {
        public void Configure(EntityTypeBuilder<Yetkiler> builder)
        {
            builder.HasKey(y => y.Id);
            builder.Property(y => y.Id).UseIdentityColumn();
            builder.Property(y => y.AktifMi).IsRequired();
            builder.Property(y => y.YetkiAdi).IsRequired().HasMaxLength(100);
         
        }
    }
}
