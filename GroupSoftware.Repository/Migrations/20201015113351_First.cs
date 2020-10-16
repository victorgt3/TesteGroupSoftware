using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupSoftware.Repository.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 255, nullable: false),
                    datacadastro = table.Column<DateTime>(name: "data-cadastro", nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoPedido",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    idProduto = table.Column<Guid>(nullable: false),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPedido", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    datacadastro = table.Column<DateTime>(name: "data-cadastro", nullable: false),
                    idCliente = table.Column<Guid>(nullable: false),
                    statusentrega = table.Column<string>(name: "status-entrega", nullable: false),
                    ProdutoPedidoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "pedido_fk",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_ProdutoPedido_ProdutoPedidoId",
                        column: x => x.ProdutoPedidoId,
                        principalTable: "ProdutoPedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 255, nullable: false),
                    valor = table.Column<double>(nullable: false),
                    disponivel = table.Column<bool>(nullable: false),
                    ProdutoPedidoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_ProdutoPedido_ProdutoPedidoId",
                        column: x => x.ProdutoPedidoId,
                        principalTable: "ProdutoPedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_idCliente",
                table: "Pedido",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ProdutoPedidoId",
                table: "Pedido",
                column: "ProdutoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ProdutoPedidoId",
                table: "Produto",
                column: "ProdutoPedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ProdutoPedido");
        }
    }
}
