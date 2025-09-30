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
    public class YorumlarConfiguration : IEntityTypeConfiguration<Yorumlar>
    {
        public void Configure(EntityTypeBuilder<Yorumlar> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).UseIdentityColumn();
            builder.Property(k => k.Yorum).IsRequired().HasMaxLength(250);
            builder.Property(k => k.EklenmeTarih).IsRequired(true);
            //builder.Property(k => k.YorumUstId).IsRequired(false);
            //builder.HasOne(k => k.Kullanicilar).WithMany(k => k.Yorumlar).HasForeignKey(k => k.KullaniciId);
            //test için oluşturuldu
            //builder.HasOne(k => k.Urunler).WithMany(k => k.Yorumlar).HasForeignKey(k => k.Id);
        }
    }
}
