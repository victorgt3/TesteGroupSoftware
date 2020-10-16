using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupSoftware.Repository.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "idPedido",
                table: "ProdutoPedido",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPedido_idPedido",
                table: "ProdutoPedido",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPedido_idProduto",
                table: "ProdutoPedido",
                column: "idProduto");

            migrationBuilder.AddForeignKey(
                name: "pedido_fk_produto",
                table: "ProdutoPedido",
                column: "idPedido",
                principalTable: "Pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "produto_fk_pedido",
                table: "ProdutoPedido",
                column: "idProduto",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "pedido_fk_produto",
                table: "ProdutoPedido");

            migrationBuilder.DropForeignKey(
                name: "produto_fk_pedido",
                table: "ProdutoPedido");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoPedido_idPedido",
                table: "ProdutoPedido");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoPedido_idProduto",
                table: "ProdutoPedido");

            migrationBuilder.DropColumn(
                name: "idPedido",
                table: "ProdutoPedido");
        }
    }
}
