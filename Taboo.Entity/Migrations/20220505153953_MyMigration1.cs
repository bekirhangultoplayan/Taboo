using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taboo.Entity.Migrations
{
    public partial class MyMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Word",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Word", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ForbiddenWord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForbiddenWord = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ForbiddenWord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ForbiddenWord_TBL_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "TBL_Word",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBL_OutWord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_OutWord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_OutWord_TBL_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "TBL_Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBL_OutWord_TBL_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "TBL_Word",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ForbiddenWord_WordId",
                table: "TBL_ForbiddenWord",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_OutWord_GameId",
                table: "TBL_OutWord",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_OutWord_WordId",
                table: "TBL_OutWord",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ForbiddenWord");

            migrationBuilder.DropTable(
                name: "TBL_OutWord");

            migrationBuilder.DropTable(
                name: "TBL_Game");

            migrationBuilder.DropTable(
                name: "TBL_Word");
        }
    }
}
