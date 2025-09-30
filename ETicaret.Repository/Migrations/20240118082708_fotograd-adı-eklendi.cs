using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fotogradadıeklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresler_Ilceler_IlceKod",
                table: "Adresler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Personeller_PersonelId",
                table: "Kullanicilar");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Sepetler_SepetId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Sepetler_sepetlerId",
                table: "Urunler");

            migrationBuilder.DropTable(
                name: "Sepetler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_sepetlerId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Siparisler_SepetId",
                table: "Siparisler");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_PersonelId",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "SepetId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "sepetlerId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "Personeller",
                newName: "kullaniciId");

            migrationBuilder.RenameColumn(
                name: "IlceKod",
                table: "Adresler",
                newName: "IlceKodu");

            migrationBuilder.RenameIndex(
                name: "IX_Adresler_IlceKod",
                table: "Adresler",
                newName: "IX_Adresler_IlceKodu");

            migrationBuilder.AlterColumn<int>(
                name: "kullaniciId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "Personeller",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KullanicilarId",
                table: "Personeller",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FotografYolu",
                table: "Fotograflar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FotografAdi",
                table: "Fotograflar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdresMusteri",
                columns: table => new
                {
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    AdresBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MusteriAdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlceAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_KullanicilarId",
                table: "Personeller",
                column: "KullanicilarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresler_Ilceler_IlceKodu",
                table: "Adresler",
                column: "IlceKodu",
                principalTable: "Ilceler",
                principalColumn: "IlceKodu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Kullanicilar_KullanicilarId",
                table: "Personeller",
                column: "KullanicilarId",
                principalTable: "Kullanicilar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresler_Ilceler_IlceKodu",
                table: "Adresler");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Kullanicilar_KullanicilarId",
                table: "Personeller");

            migrationBuilder.DropTable(
                name: "AdresMusteri");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_KullanicilarId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "KullanicilarId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "FotografAdi",
                table: "Fotograflar");

            migrationBuilder.RenameColumn(
                name: "kullaniciId",
                table: "Personeller",
                newName: "KullaniciId");

            migrationBuilder.RenameColumn(
                name: "IlceKodu",
                table: "Adresler",
                newName: "IlceKod");

            migrationBuilder.RenameIndex(
                name: "IX_Adresler_IlceKodu",
                table: "Adresler",
                newName: "IX_Adresler_IlceKod");

            migrationBuilder.AddColumn<int>(
                name: "SepetId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sepetlerId",
                table: "Urunler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Kullanicilar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FotografYolu",
                table: "Fotograflar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Sepetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KargoAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KartNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriNot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OdemeSekli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiparisDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamOdeme = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunAdet = table.Column<int>(type: "int", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    kullanicilarId = table.Column<int>(type: "int", nullable: false),
                    urunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepetler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sepetler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_sepetlerId",
                table: "Urunler",
                column: "sepetlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_SepetId",
                table: "Siparisler",
                column: "SepetId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_PersonelId",
                table: "Kullanicilar",
                column: "PersonelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sepetler_KullaniciId",
                table: "Sepetler",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresler_Ilceler_IlceKod",
                table: "Adresler",
                column: "IlceKod",
                principalTable: "Ilceler",
                principalColumn: "IlceKodu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Personeller_PersonelId",
                table: "Kullanicilar",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Sepetler_SepetId",
                table: "Siparisler",
                column: "SepetId",
                principalTable: "Sepetler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Sepetler_sepetlerId",
                table: "Urunler",
                column: "sepetlerId",
                principalTable: "Sepetler",
                principalColumn: "Id");
        }
    }
}
