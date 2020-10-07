using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cpf = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    dtnascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    cor = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idcliente = table.Column<int>(nullable: false),
                    clienteid = table.Column<int>(nullable: true),
                    idvendedor = table.Column<int>(nullable: false),
                    vendedorid = table.Column<int>(nullable: true),
                    valortotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cadastros_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cadastros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Cadastros_vendedorid",
                        column: x => x.vendedorid,
                        principalTable: "Cadastros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    login = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    cadastroid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cadastros_cadastroid",
                        column: x => x.cadastroid,
                        principalTable: "Cadastros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dtfabricacao = table.Column<DateTime>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    produtoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lotes_Produtos_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pedidoid = table.Column<int>(nullable: false),
                    produtoid = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItens", x => x.id);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Pedidos_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "Pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Produtos_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_produtoid",
                table: "Lotes",
                column: "produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_pedidoid",
                table: "PedidoItens",
                column: "pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_produtoid",
                table: "PedidoItens",
                column: "produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_clienteid",
                table: "Pedidos",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_vendedorid",
                table: "Pedidos",
                column: "vendedorid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_cadastroid",
                table: "Usuarios",
                column: "cadastroid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "PedidoItens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Cadastros");
        }
    }
}
