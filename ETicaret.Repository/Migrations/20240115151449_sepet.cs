using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class sepet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "SepetId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciSifre",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciEmail",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Sepetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdet = table.Column<int>(type: "int", nullable: false),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeSekli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdemeMiktari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    urunId = table.Column<int>(type: "int", nullable: false),
                    KargoAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    indirimKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiparisDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriNot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Sepetler_KullaniciId",
                table: "Sepetler",
                column: "KullaniciId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "SepetId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "sepetlerId",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "SepetId",
                table: "Siparisler");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciSifre",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciEmail",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
