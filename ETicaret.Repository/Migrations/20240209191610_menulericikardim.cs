using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class menulericikardim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menular");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "FotografAdi",
                table: "Fotograflar");

            migrationBuilder.RenameColumn(
                name: "kullaniciId",
                table: "Personeller",
                newName: "KullaniciId");

            migrationBuilder.AddColumn<int>(
                name: "YetkiId",
                table: "Yetkiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "YetkiAdi",
                table: "YetkiErisim",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SiparisTarihi",
                table: "Siparisler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UrunId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Kullanici_Id",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YetkiId",
                table: "Yetkiler");

            migrationBuilder.DropColumn(
                name: "YetkiAdi",
                table: "YetkiErisim");

            migrationBuilder.DropColumn(
                name: "SiparisTarihi",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "UrunId",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "Kullanici_Id",
                table: "Personeller");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "Personeller",
                newName: "kullaniciId");

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

            migrationBuilder.AddColumn<string>(
                name: "FotografAdi",
                table: "Fotograflar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Menular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErisimAlanlariId = table.Column<int>(type: "int", nullable: false),
                    UstMenuId = table.Column<int>(type: "int", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    MenuAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuSirasi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menular_ErisimAlanlari_ErisimAlanlariId",
                        column: x => x.ErisimAlanlariId,
                        principalTable: "ErisimAlanlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menular_Menular_UstMenuId",
                        column: x => x.UstMenuId,
                        principalTable: "Menular",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menular_ErisimAlanlariId",
                table: "Menular",
                column: "ErisimAlanlariId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menular_UstMenuId",
                table: "Menular",
                column: "UstMenuId");
        }
    }
}
