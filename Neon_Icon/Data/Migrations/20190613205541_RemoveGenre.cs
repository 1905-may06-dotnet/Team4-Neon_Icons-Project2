using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Preferenc__genre__5535A963",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK__Weather__default__5070F446",
                table: "Weather");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Weather_default_genre",
                table: "Weather");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_genre_id",
                table: "Preferences");

            migrationBuilder.AlterColumn<string>(
                name: "default_genre",
                table: "Weather",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "genre_id",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "default_genre",
                table: "Weather",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "genre_id",
                table: "Preferences",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Test = table.Column<int>(nullable: false),
                    type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_default_genre",
                table: "Weather",
                column: "default_genre");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_genre_id",
                table: "Preferences",
                column: "genre_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Preferenc__genre__5535A963",
                table: "Preferences",
                column: "genre_id",
                principalTable: "Genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Weather__default__5070F446",
                table: "Weather",
                column: "default_genre",
                principalTable: "Genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
