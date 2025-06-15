using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore_Website.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInicialv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Det_Ventas_Sucursales_sucursalId_Sucursal",
                table: "Det_Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Det_Ventas_Ventas_ventaSale_Id",
                table: "Det_Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Sucursales_SucursalId_Sucursal",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cliente_ClientesClient_Id",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Empleado_EmpleadoId_Empleado",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Estado_Pagos_Estado_PagoId_Estado_Pago",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Tipos_Pagos_Tipos_PagoId_Tipo_Pago",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Abonos");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_SucursalId_Sucursal",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Det_Ventas_sucursalId_Sucursal",
                table: "Det_Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ClientesClient_Id",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_EmpleadoId_Empleado",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_Estado_PagoId_Estado_Pago",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_Tipos_PagoId_Tipo_Pago",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "SucursalId_Sucursal",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "Sucursal_Id",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "Sucursal_Id",
                table: "Det_Ventas");

            migrationBuilder.DropColumn(
                name: "sucursalId_Sucursal",
                table: "Det_Ventas");

            migrationBuilder.DropColumn(
                name: "ClientesClient_Id",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "EmpleadoId_Empleado",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Estado_PagoId_Estado_Pago",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Tipos_PagoId_Tipo_Pago",
                table: "Ventas");

            migrationBuilder.RenameTable(
                name: "Ventas",
                newName: "Venta");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Empleado",
                newName: "Pssword");

            migrationBuilder.RenameColumn(
                name: "Sale_Status",
                table: "Venta",
                newName: "Id_Tipo_Pago");

            migrationBuilder.RenameColumn(
                name: "Pay_Type",
                table: "Venta",
                newName: "Id_Estado_Pago");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Empleado",
                table: "Venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venta",
                table: "Venta",
                column: "Sale_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Client_Id",
                table: "Venta",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Id_Empleado",
                table: "Venta",
                column: "Id_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Id_Estado_Pago",
                table: "Venta",
                column: "Id_Estado_Pago");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_Id_Tipo_Pago",
                table: "Venta",
                column: "Id_Tipo_Pago");

            migrationBuilder.AddForeignKey(
                name: "FK_Det_Ventas_Venta_ventaSale_Id",
                table: "Det_Ventas",
                column: "ventaSale_Id",
                principalTable: "Venta",
                principalColumn: "Sale_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Cliente_Client_Id",
                table: "Venta",
                column: "Client_Id",
                principalTable: "Cliente",
                principalColumn: "Client_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Empleado_Id_Empleado",
                table: "Venta",
                column: "Id_Empleado",
                principalTable: "Empleado",
                principalColumn: "Id_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Estado_Pagos_Id_Estado_Pago",
                table: "Venta",
                column: "Id_Estado_Pago",
                principalTable: "Estado_Pagos",
                principalColumn: "Id_Estado_Pago",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Tipos_Pagos_Id_Tipo_Pago",
                table: "Venta",
                column: "Id_Tipo_Pago",
                principalTable: "Tipos_Pagos",
                principalColumn: "Id_Tipo_Pago",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Det_Ventas_Venta_ventaSale_Id",
                table: "Det_Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Cliente_Client_Id",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Empleado_Id_Empleado",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Estado_Pagos_Id_Estado_Pago",
                table: "Venta");

            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Tipos_Pagos_Id_Tipo_Pago",
                table: "Venta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venta",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_Client_Id",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_Id_Empleado",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_Id_Estado_Pago",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_Id_Tipo_Pago",
                table: "Venta");

            migrationBuilder.RenameTable(
                name: "Venta",
                newName: "Ventas");

            migrationBuilder.RenameColumn(
                name: "Pssword",
                table: "Empleado",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Id_Tipo_Pago",
                table: "Ventas",
                newName: "Sale_Status");

            migrationBuilder.RenameColumn(
                name: "Id_Estado_Pago",
                table: "Ventas",
                newName: "Pay_Type");

            migrationBuilder.AddColumn<int>(
                name: "SucursalId_Sucursal",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sucursal_Id",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sucursal_Id",
                table: "Det_Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sucursalId_Sucursal",
                table: "Det_Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Empleado",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientesClient_Id",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId_Empleado",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado_PagoId_Estado_Pago",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipos_PagoId_Tipo_Pago",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas",
                column: "Sale_Id");

            migrationBuilder.CreateTable(
                name: "Abonos",
                columns: table => new
                {
                    empleadoId_Empleado = table.Column<int>(type: "int", nullable: true),
                    ventaSale_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Abonos_Empleado_empleadoId_Empleado",
                        column: x => x.empleadoId_Empleado,
                        principalTable: "Empleado",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonos_Ventas_ventaSale_Id",
                        column: x => x.ventaSale_Id,
                        principalTable: "Ventas",
                        principalColumn: "Sale_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id_Sucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre_Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id_Sucursal);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_SucursalId_Sucursal",
                table: "Empleado",
                column: "SucursalId_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Ventas_sucursalId_Sucursal",
                table: "Det_Ventas",
                column: "sucursalId_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClientesClient_Id",
                table: "Ventas",
                column: "ClientesClient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EmpleadoId_Empleado",
                table: "Ventas",
                column: "EmpleadoId_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Estado_PagoId_Estado_Pago",
                table: "Ventas",
                column: "Estado_PagoId_Estado_Pago");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Tipos_PagoId_Tipo_Pago",
                table: "Ventas",
                column: "Tipos_PagoId_Tipo_Pago");

            migrationBuilder.AddForeignKey(
                name: "FK_Det_Ventas_Sucursales_sucursalId_Sucursal",
                table: "Det_Ventas",
                column: "sucursalId_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Id_Sucursal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Det_Ventas_Ventas_ventaSale_Id",
                table: "Det_Ventas",
                column: "ventaSale_Id",
                principalTable: "Ventas",
                principalColumn: "Sale_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Sucursales_SucursalId_Sucursal",
                table: "Empleado",
                column: "SucursalId_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Id_Sucursal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cliente_ClientesClient_Id",
                table: "Ventas",
                column: "ClientesClient_Id",
                principalTable: "Cliente",
                principalColumn: "Client_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Empleado_EmpleadoId_Empleado",
                table: "Ventas",
                column: "EmpleadoId_Empleado",
                principalTable: "Empleado",
                principalColumn: "Id_Empleado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Estado_Pagos_Estado_PagoId_Estado_Pago",
                table: "Ventas",
                column: "Estado_PagoId_Estado_Pago",
                principalTable: "Estado_Pagos",
                principalColumn: "Id_Estado_Pago");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Tipos_Pagos_Tipos_PagoId_Tipo_Pago",
                table: "Ventas",
                column: "Tipos_PagoId_Tipo_Pago",
                principalTable: "Tipos_Pagos",
                principalColumn: "Id_Tipo_Pago");
        }
    }
}
