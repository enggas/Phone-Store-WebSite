using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore_Website.Migrations
{
    /// <inheritdoc />
    public partial class FixClienteForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Web_Clientes_Cliente_Id",
                table: "Cuenta_Web");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Marca_MarcaId_Marca",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClientesCliente_Id",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Producto_MarcaId_Marca",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "MarcaId_Marca",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ClientesCliente_Id",
                table: "Ventas",
                newName: "ClientesClient_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ClientesCliente_Id",
                table: "Ventas",
                newName: "IX_Ventas_ClientesClient_Id");

            migrationBuilder.RenameColumn(
                name: "Prod_Stock",
                table: "Producto",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "Prod_Imagen",
                table: "Producto",
                newName: "Prod_Description");

            migrationBuilder.RenameColumn(
                name: "Prod_Estado",
                table: "Producto",
                newName: "Prod_State");

            migrationBuilder.RenameColumn(
                name: "Prod_Descripcion",
                table: "Producto",
                newName: "Imagen");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Empleado",
                newName: "Pssword");

            migrationBuilder.RenameColumn(
                name: "Venta_Id",
                table: "Det_Ventas",
                newName: "Sucursal_Id");

            migrationBuilder.RenameColumn(
                name: "Sucursal",
                table: "Det_Ventas",
                newName: "Sale_Id");

            migrationBuilder.RenameColumn(
                name: "Id_Producto",
                table: "Det_Compras",
                newName: "Prod_Id");

            migrationBuilder.RenameColumn(
                name: "Det_Compra_Id",
                table: "Det_Compras",
                newName: "Purc_Det_Id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Cuenta_Web",
                newName: "Pssword");

            migrationBuilder.RenameColumn(
                name: "Estado_Cuenta",
                table: "Cuenta_Web",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Cliente_Id",
                table: "Cuenta_Web",
                newName: "ClienteClient_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_Web_Cliente_Id",
                table: "Cuenta_Web",
                newName: "IX_Cuenta_Web_ClienteClient_Id");

            migrationBuilder.RenameColumn(
                name: "Type_Document",
                table: "Compras",
                newName: "Doc_Type");

            migrationBuilder.RenameColumn(
                name: "Id_Prov",
                table: "Compras",
                newName: "Prov_ID");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Compras",
                newName: "Doc_Num");

            migrationBuilder.RenameColumn(
                name: "Cliente_Estado",
                table: "Clientes",
                newName: "Client_State");

            migrationBuilder.RenameColumn(
                name: "Cliente_Id",
                table: "Clientes",
                newName: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Id_Marca",
                table: "Producto",
                column: "Id_Marca");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Web_Clientes_ClienteClient_Id",
                table: "Cuenta_Web",
                column: "ClienteClient_Id",
                principalTable: "Clientes",
                principalColumn: "Client_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Marca_Id_Marca",
                table: "Producto",
                column: "Id_Marca",
                principalTable: "Marca",
                principalColumn: "Id_Marca",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClientesClient_Id",
                table: "Ventas",
                column: "ClientesClient_Id",
                principalTable: "Clientes",
                principalColumn: "Client_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Web_Clientes_ClienteClient_Id",
                table: "Cuenta_Web");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Marca_Id_Marca",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Clientes_ClientesClient_Id",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Producto_Id_Marca",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "ClientesClient_Id",
                table: "Ventas",
                newName: "ClientesCliente_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_ClientesClient_Id",
                table: "Ventas",
                newName: "IX_Ventas_ClientesCliente_Id");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Producto",
                newName: "Prod_Stock");

            migrationBuilder.RenameColumn(
                name: "Prod_State",
                table: "Producto",
                newName: "Prod_Estado");

            migrationBuilder.RenameColumn(
                name: "Prod_Description",
                table: "Producto",
                newName: "Prod_Imagen");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Producto",
                newName: "Prod_Descripcion");

            migrationBuilder.RenameColumn(
                name: "Pssword",
                table: "Empleado",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Sucursal_Id",
                table: "Det_Ventas",
                newName: "Venta_Id");

            migrationBuilder.RenameColumn(
                name: "Sale_Id",
                table: "Det_Ventas",
                newName: "Sucursal");

            migrationBuilder.RenameColumn(
                name: "Prod_Id",
                table: "Det_Compras",
                newName: "Id_Producto");

            migrationBuilder.RenameColumn(
                name: "Purc_Det_Id",
                table: "Det_Compras",
                newName: "Det_Compra_Id");

            migrationBuilder.RenameColumn(
                name: "Pssword",
                table: "Cuenta_Web",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Cuenta_Web",
                newName: "Estado_Cuenta");

            migrationBuilder.RenameColumn(
                name: "ClienteClient_Id",
                table: "Cuenta_Web",
                newName: "Cliente_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_Web_ClienteClient_Id",
                table: "Cuenta_Web",
                newName: "IX_Cuenta_Web_Cliente_Id");

            migrationBuilder.RenameColumn(
                name: "Prov_ID",
                table: "Compras",
                newName: "Id_Prov");

            migrationBuilder.RenameColumn(
                name: "Doc_Type",
                table: "Compras",
                newName: "Type_Document");

            migrationBuilder.RenameColumn(
                name: "Doc_Num",
                table: "Compras",
                newName: "Document");

            migrationBuilder.RenameColumn(
                name: "Client_State",
                table: "Clientes",
                newName: "Cliente_Estado");

            migrationBuilder.RenameColumn(
                name: "Client_Id",
                table: "Clientes",
                newName: "Cliente_Id");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId_Marca",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaId_Marca",
                table: "Producto",
                column: "MarcaId_Marca");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Web_Clientes_Cliente_Id",
                table: "Cuenta_Web",
                column: "Cliente_Id",
                principalTable: "Clientes",
                principalColumn: "Cliente_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Marca_MarcaId_Marca",
                table: "Producto",
                column: "MarcaId_Marca",
                principalTable: "Marca",
                principalColumn: "Id_Marca",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Clientes_ClientesCliente_Id",
                table: "Ventas",
                column: "ClientesCliente_Id",
                principalTable: "Clientes",
                principalColumn: "Cliente_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
