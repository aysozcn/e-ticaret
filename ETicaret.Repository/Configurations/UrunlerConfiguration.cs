using ETicaret.Core.ETicaretDatabase;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.Configurations
{
    public class UrunlerConfiguration : IEntityTypeConfiguration<Urunler>
    {
        public void Configure(EntityTypeBuilder<Urunler> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k=>k.Id).UseIdentityColumn();
            builder.Property(k=>k.UrunAdi).IsRequired().HasMaxLength(100);
            builder.Property(k=>k.Aciklama).IsRequired(false);
            builder.Property(k=>k.UrunFiyat).IsRequired(true).HasColumnType("decimal(18,2)");
            //Urunler ile Kategoriler arasında diagram bağlantısı oluşturmak
            builder.HasOne(k=>k.Kategoriler).WithMany(k=>k.Urunler).HasForeignKey(k=>k.KategoriId);//1-sonsuz ilişki sağlanmış olur
            builder.HasMany(k => k.SiparisDetay).WithOne(k => k.Urunler).HasForeignKey(k => k.UrunId);
            builder.HasMany(k => k.Yorumlar).WithOne(k => k.Urunler).HasForeignKey(k => k.UrunId);
            builder.HasMany(k => k.Fotograflar).WithOne(k => k.Urunler).HasForeignKey(k => k.UrunId);
            

        }
    }
}
