using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab4t1.Data.Migrations
{
    public partial class ComprasClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    JogoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Jogos_JogoID",
                        column: x => x.JogoID,
                        principalTable: "Jogos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compras_Perfils_UserID",
                        column: x => x.UserID,
                        principalTable: "Perfils",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_JogoID",
                table: "Compras",
                column: "JogoID");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UserID",
                table: "Compras",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wishlists_Jogos_GameID",
                        column: x => x.GameID,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlists_Perfils_UserID",
                        column: x => x.UserID,
                        principalTable: "Perfils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_GameID",
                table: "Wishlists",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserID",
                table: "Wishlists",
                column: "UserID");
        }
    }
}
