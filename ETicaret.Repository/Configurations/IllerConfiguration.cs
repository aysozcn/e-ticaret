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
    public class IllerConfiguration : IEntityTypeConfiguration<Iller>
    {
        public void Configure(EntityTypeBuilder<Iller> builder)
        {
            builder.HasKey(k => k.IlKodu);
            builder.Property(k=>k.IlAdi).IsRequired().HasMaxLength(128);
          // builder.HasMany(k=>k.Ilceler).WithOne(k=>k.Iller).HasForeignKey(k=>k.IlKodu);

        }
    }
}
