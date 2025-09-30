using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Repository.Migrations
{
	/// <inheritdoc />
	public partial class personelDuzenleme : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Musteriler_Kullanicilar_KullaniciId",
				table: "Musteriler");

			migrationBuilder.DropForeignKey(
				name: "FK_Personeller_Kullanicilar_KullanicilarId",
				table: "Personeller");

			migrationBuilder.DropIndex(
				name: "IX_Personeller_KullanicilarId",
				table: "Personeller");

			migrationBuilder.DropIndex(
				name: "IX_Personeller_PersonelKullaniciBilgileriId",
				table: "Personeller");

			migrationBuilder.DropIndex(
				name: "IX_Musteriler_KullaniciId",
				table: "Musteriler");

			migrationBuilder.DropColumn(
				name: "KullaniciId",
				table: "Personeller");

			migrationBuilder.DropColumn(
				name: "KullanicilarId",
				table: "Personeller");

			//migrationBuilder.DropColumn(
			//    name: "MusteriId",
			//    table: "Kullanicilar");

			//migrationBuilder.RenameColumn(
			//    name: "kullaniciId",
			//    table: "Personeller",
			//    newName: "KullaniciId");

			migrationBuilder.AlterColumn<int>(
				name: "KullaniciId",
				table: "Personeller",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AddColumn<int>(
				name: "KullanicilarId",
				table: "Musteriler",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
	        name: "KullaniciId",
	        table: "Personeller",
	        type: "int",
	        nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Personeller_PersonelKullaniciBilgileriId",
				table: "Personeller",
				column: "PersonelKullaniciBilgileriId");

			migrationBuilder.CreateIndex(
				name: "IX_Musteriler_KullanicilarId",
				table: "Musteriler",
				column: "KullanicilarId");

			migrationBuilder.CreateIndex(
				name: "IX_Kullanicilar_PersonelId",
				table: "Kullanicilar",
				column: "PersonelId",
				unique: true);

			migrationBuilder.AddForeignKey(
				name: "FK_Kullanicilar_Personeller_PersonelId",
				table: "Kullanicilar",
				column: "PersonelId",
				principalTable: "Personeller",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Musteriler_Kullanicilar_KullanicilarId",
				table: "Musteriler",
				column: "KullanicilarId",
				principalTable: "Kullanicilar",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Kullanicilar_Personeller_PersonelId",
				table: "Kullanicilar");

			migrationBuilder.DropForeignKey(
				name: "FK_Musteriler_Kullanicilar_KullanicilarId",
				table: "Musteriler");

			migrationBuilder.DropIndex(
				name: "IX_Personeller_PersonelKullaniciBilgileriId",
				table: "Personeller");

			migrationBuilder.DropIndex(
				name: "IX_Musteriler_KullanicilarId",
				table: "Musteriler");

			migrationBuilder.DropIndex(
				name: "IX_Kullanicilar_PersonelId",
				table: "Kullanicilar");

			migrationBuilder.DropColumn(
				name: "KullanicilarId",
				table: "Musteriler");

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

			migrationBuilder.AddColumn<int>(
				name: "KullanicilarId",
				table: "Personeller",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "MusteriId",
				table: "Kullanicilar",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_Personeller_KullanicilarId",
				table: "Personeller",
				column: "KullanicilarId");

			migrationBuilder.CreateIndex(
				name: "IX_Personeller_PersonelKullaniciBilgileriId",
				table: "Personeller",
				column: "PersonelKullaniciBilgileriId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Musteriler_KullaniciId",
				table: "Musteriler",
				column: "KullaniciId",
				unique: true,
				filter: "[KullaniciId] IS NOT NULL");

			migrationBuilder.AddForeignKey(
				name: "FK_Musteriler_Kullanicilar_KullaniciId",
				table: "Musteriler",
				column: "KullaniciId",
				principalTable: "Kullanicilar",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Personeller_Kullanicilar_KullanicilarId",
				table: "Personeller",
				column: "KullanicilarId",
				principalTable: "Kullanicilar",
				principalColumn: "Id");
		}
	}
}
