using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore_Website.Migrations
{
    /// <inheritdoc />
    public partial class migracionGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClientesClient_Id",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Card_Num",
                table: "Ventas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Card_Num",
                table: "Abonos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Client_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cliente_ClientesClient_Id",
                table: "Ventas",
                column: "ClientesClient_Id",
                principalTable: "Cliente",
                principalColumn: "Client_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cliente_ClientesClient_Id",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Card_Num",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Card_Num",
                table: "Abonos");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Client_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClientesClient_Id",
                table: "Ventas",
                column: "ClientesClient_Id",
                principalTable: "Clientes",
                principalColumn: "Client_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
