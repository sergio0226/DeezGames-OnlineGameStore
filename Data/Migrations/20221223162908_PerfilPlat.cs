using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab4t1.Data.Migrations
{
    public partial class PerfilPlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Categorias_CategoriaID",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Produtoras_ProdutoraID",
                table: "Jogos");

            migrationBuilder.RenameColumn(
                name: "Consola",
                table: "Jogos",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoraID",
                table: "Jogos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaID",
                table: "Jogos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioID",
                table: "Jogos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlataformaID",
                table: "Jogos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Jogos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Perfils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plataformas_Perfils_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfils",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_FuncionarioID",
                table: "Jogos",
                column: "FuncionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_PlataformaID",
                table: "Jogos",
                column: "PlataformaID");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_PerfilId",
                table: "Categorias",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_PerfilId",
                table: "Plataformas",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Perfils_PerfilId",
                table: "Categorias",
                column: "PerfilId",
                principalTable: "Perfils",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Categorias_CategoriaID",
                table: "Jogos",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Perfils_FuncionarioID",
                table: "Jogos",
                column: "FuncionarioID",
                principalTable: "Perfils",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Plataformas_PlataformaID",
                table: "Jogos",
                column: "PlataformaID",
                principalTable: "Plataformas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Produtoras_ProdutoraID",
                table: "Jogos",
                column: "ProdutoraID",
                principalTable: "Produtoras",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Perfils_PerfilId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Categorias_CategoriaID",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Perfils_FuncionarioID",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Plataformas_PlataformaID",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Produtoras_ProdutoraID",
                table: "Jogos");

            migrationBuilder.DropTable(
                name: "Plataformas");

            migrationBuilder.DropTable(
                name: "Perfils");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_FuncionarioID",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_PlataformaID",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_PerfilId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "FuncionarioID",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "PlataformaID",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Categorias");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Jogos",
                newName: "Consola");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoraID",
                table: "Jogos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaID",
                table: "Jogos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Categorias_CategoriaID",
                table: "Jogos",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Produtoras_ProdutoraID",
                table: "Jogos",
                column: "ProdutoraID",
                principalTable: "Produtoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
