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
    internal class KategorilerConfiguration : IEntityTypeConfiguration<Kategoriler>
    {
        public void Configure(EntityTypeBuilder<Kategoriler> builder)
        {
            builder.HasKey(k => k.Id);
            //builder.Property(k => k.Id).HasColumnName("KategorilerId");//BaseEntity'den alınan Id adını KategorilerId olarak Db de tutar
            //builder.ToTable("Tbl_Kategoriler");//tablo adını db ye Tbl_Kategoriler isminde kayıt eder
            builder.Property(k=>k.Id).UseIdentityColumn();
            builder.Property(k => k.Aciklama).IsRequired(false);
            builder.Property(k => k.KategoriAdi).IsRequired().HasMaxLength(100);

        }
    }
}
