using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Repository.Migrations
{
    /// <inheritdoc />
    public partial class sepeteVeriEkleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "indirimKodu",
                table: "Sepetler");

            migrationBuilder.RenameColumn(
                name: "ToplamFiyat",
                table: "Sepetler",
                newName: "UrunFiyati");

            migrationBuilder.RenameColumn(
                name: "OdemeMiktari",
                table: "Sepetler",
                newName: "ToplamOdeme");

            migrationBuilder.AddColumn<string>(
                name: "KartNumarasi",
                table: "Sepetler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "kullanicilarId",
                table: "Sepetler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KartNumarasi",
                table: "Sepetler");

            migrationBuilder.DropColumn(
                name: "kullanicilarId",
                table: "Sepetler");

            migrationBuilder.RenameColumn(
                name: "UrunFiyati",
                table: "Sepetler",
                newName: "ToplamFiyat");

            migrationBuilder.RenameColumn(
                name: "ToplamOdeme",
                table: "Sepetler",
                newName: "OdemeMiktari");

            migrationBuilder.AddColumn<string>(
                name: "indirimKodu",
                table: "Sepetler",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
