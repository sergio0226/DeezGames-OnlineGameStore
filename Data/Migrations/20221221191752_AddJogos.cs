using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab4t1.Data.Migrations
{
    public partial class AddJogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    ProdutoraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogos_Produtoras_ProdutoraID",
                        column: x => x.ProdutoraID,
                        principalTable: "Produtoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_CategoriaID",
                table: "Jogos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_ProdutoraID",
                table: "Jogos",
                column: "ProdutoraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
