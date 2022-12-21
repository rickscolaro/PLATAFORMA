using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Formularios",
                columns: table => new
                {
                    FormularioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formularios", x => x.FormularioId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "OrdemProducoes",
                columns: table => new
                {
                    OrdemProducaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemProducoes", x => x.OrdemProducaoId);
                    table.ForeignKey(
                        name: "FK_OrdemProducoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemProducoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServicos",
                columns: table => new
                {
                    OrdemServicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    OrdemProducaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicos", x => x.OrdemServicoId);
                    table.ForeignKey(
                        name: "FK_OrdemServicos_OrdemProducoes_OrdemProducaoId",
                        column: x => x.OrdemProducaoId,
                        principalTable: "OrdemProducoes",
                        principalColumn: "OrdemProducaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemServicos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Descricao" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "Microsoft" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "Descricao", "Quantidade" },
                values: new object[,]
                {
                    { 1, "IPhone", 5000 },
                    { 2, "SmartPhone", 1000 },
                    { 3, "Windos", 1000 },
                    { 4, "XBOX", 1000 }
                });

            migrationBuilder.InsertData(
                table: "OrdemProducoes",
                columns: new[] { "OrdemProducaoId", "ClienteId", "Descricao", "ProdutoId", "Situacao" },
                values: new object[] { 1, 1, "Producao Apple", 1, 1 });

            migrationBuilder.InsertData(
                table: "OrdemProducoes",
                columns: new[] { "OrdemProducaoId", "ClienteId", "Descricao", "ProdutoId", "Situacao" },
                values: new object[] { 2, 2, "Producao Microsof", 3, 1 });

            migrationBuilder.InsertData(
                table: "OrdemServicos",
                columns: new[] { "OrdemServicoId", "Descricao", "OrdemProducaoId", "ProdutoId", "Situacao" },
                values: new object[,]
                {
                    { 1, "Servico Apple", 1, 1, 1 },
                    { 2, "Servico Apple", 1, 2, 1 },
                    { 3, "Servico Microsof", 2, 3, 1 },
                    { 4, "Servico Microsof", 2, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducoes_ClienteId",
                table: "OrdemProducoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducoes_ProdutoId",
                table: "OrdemProducoes",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicos_OrdemProducaoId",
                table: "OrdemServicos",
                column: "OrdemProducaoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicos_ProdutoId",
                table: "OrdemServicos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formularios");

            migrationBuilder.DropTable(
                name: "OrdemServicos");

            migrationBuilder.DropTable(
                name: "OrdemProducoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
