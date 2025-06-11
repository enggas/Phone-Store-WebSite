using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore_Website.Migrations
{
    /// <inheritdoc />
    public partial class Migracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cliente_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client_Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cliente_Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cliente_Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado_Pagos",
                columns: table => new
                {
                    Id_Estado_Pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Pagos", x => x.Id_Estado_Pago);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca_State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id_Marca);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Prov_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prov_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prov_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prov_State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Prov_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id_Sucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id_Sucursal);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Pagos",
                columns: table => new
                {
                    Id_Tipo_Pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Pagos", x => x.Id_Tipo_Pago);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta_Web",
                columns: table => new
                {
                    Cuenta_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Cliente_Id = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado_Cuenta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta_Web", x => x.Cuenta_Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Web_Clientes_Cliente_Id",
                        column: x => x.Cliente_Id,
                        principalTable: "Clientes",
                        principalColumn: "Cliente_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Prod_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Cod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prod_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prod_Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Marca = table.Column<int>(type: "int", nullable: false),
                    MarcaId_Marca = table.Column<int>(type: "int", nullable: false),
                    Prod_Stock = table.Column<int>(type: "int", nullable: false),
                    Purchase_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prod_Estado = table.Column<bool>(type: "bit", nullable: false),
                    Prod_Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Prod_Id);
                    table.ForeignKey(
                        name: "FK_Producto_Marca_MarcaId_Marca",
                        column: x => x.MarcaId_Marca,
                        principalTable: "Marca",
                        principalColumn: "Id_Marca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id_Empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Sucursal_Id = table.Column<int>(type: "int", nullable: false),
                    SucursalId_Sucursal = table.Column<int>(type: "int", nullable: false),
                    User_State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id_Empleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Sucursales_SucursalId_Sucursal",
                        column: x => x.SucursalId_Sucursal,
                        principalTable: "Sucursales",
                        principalColumn: "Id_Sucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Purchase_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Empleado = table.Column<int>(type: "int", nullable: false),
                    empleadoId_Empleado = table.Column<int>(type: "int", nullable: false),
                    Id_Prov = table.Column<int>(type: "int", nullable: false),
                    proveedoresProv_Id = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Purchase_Id);
                    table.ForeignKey(
                        name: "FK_Compras_Empleado_empleadoId_Empleado",
                        column: x => x.empleadoId_Empleado,
                        principalTable: "Empleado",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_proveedoresProv_Id",
                        column: x => x.proveedoresProv_Id,
                        principalTable: "Proveedores",
                        principalColumn: "Prov_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historial_Actividades",
                columns: table => new
                {
                    Historial_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empleado = table.Column<int>(type: "int", nullable: false),
                    EmpId_Empleado = table.Column<int>(type: "int", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_Actividades", x => x.Historial_Id);
                    table.ForeignKey(
                        name: "FK_Historial_Actividades_Empleado_EmpId_Empleado",
                        column: x => x.EmpId_Empleado,
                        principalTable: "Empleado",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Sale_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Empleado = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId_Empleado = table.Column<int>(type: "int", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    ClientesCliente_Id = table.Column<int>(type: "int", nullable: false),
                    Pay_Type = table.Column<int>(type: "int", nullable: false),
                    Sale_Status = table.Column<int>(type: "int", nullable: false),
                    Pay_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Change_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado_PagoId_Estado_Pago = table.Column<int>(type: "int", nullable: true),
                    Tipos_PagoId_Tipo_Pago = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Sale_Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClientesCliente_Id",
                        column: x => x.ClientesCliente_Id,
                        principalTable: "Clientes",
                        principalColumn: "Cliente_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Empleado_EmpleadoId_Empleado",
                        column: x => x.EmpleadoId_Empleado,
                        principalTable: "Empleado",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Estado_Pagos_Estado_PagoId_Estado_Pago",
                        column: x => x.Estado_PagoId_Estado_Pago,
                        principalTable: "Estado_Pagos",
                        principalColumn: "Id_Estado_Pago");
                    table.ForeignKey(
                        name: "FK_Ventas_Tipos_Pagos_Tipos_PagoId_Tipo_Pago",
                        column: x => x.Tipos_PagoId_Tipo_Pago,
                        principalTable: "Tipos_Pagos",
                        principalColumn: "Id_Tipo_Pago");
                });

            migrationBuilder.CreateTable(
                name: "Det_Compras",
                columns: table => new
                {
                    Det_Compra_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase_Id = table.Column<int>(type: "int", nullable: false),
                    compraPurchase_Id = table.Column<int>(type: "int", nullable: false),
                    Id_Producto = table.Column<int>(type: "int", nullable: false),
                    productoProd_Id = table.Column<int>(type: "int", nullable: false),
                    Purchase_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Det_Compras", x => x.Det_Compra_Id);
                    table.ForeignKey(
                        name: "FK_Det_Compras_Compras_compraPurchase_Id",
                        column: x => x.compraPurchase_Id,
                        principalTable: "Compras",
                        principalColumn: "Purchase_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Det_Compras_Producto_productoProd_Id",
                        column: x => x.productoProd_Id,
                        principalTable: "Producto",
                        principalColumn: "Prod_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonos",
                columns: table => new
                {
                    Abono_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_Id = table.Column<int>(type: "int", nullable: false),
                    ventaSale_Id = table.Column<int>(type: "int", nullable: false),
                    Abono_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Abono_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Empleado = table.Column<int>(type: "int", nullable: false),
                    empleadoId_Empleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonos", x => x.Abono_Id);
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
                name: "Det_Ventas",
                columns: table => new
                {
                    Det_Sale_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sucursal = table.Column<int>(type: "int", nullable: false),
                    sucursalId_Sucursal = table.Column<int>(type: "int", nullable: false),
                    Venta_Id = table.Column<int>(type: "int", nullable: false),
                    ventaSale_Id = table.Column<int>(type: "int", nullable: false),
                    Prod_Id = table.Column<int>(type: "int", nullable: false),
                    ProductoProd_Id = table.Column<int>(type: "int", nullable: false),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Det_Ventas", x => x.Det_Sale_Id);
                    table.ForeignKey(
                        name: "FK_Det_Ventas_Producto_ProductoProd_Id",
                        column: x => x.ProductoProd_Id,
                        principalTable: "Producto",
                        principalColumn: "Prod_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Det_Ventas_Sucursales_sucursalId_Sucursal",
                        column: x => x.sucursalId_Sucursal,
                        principalTable: "Sucursales",
                        principalColumn: "Id_Sucursal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Det_Ventas_Ventas_ventaSale_Id",
                        column: x => x.ventaSale_Id,
                        principalTable: "Ventas",
                        principalColumn: "Sale_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonos_empleadoId_Empleado",
                table: "Abonos",
                column: "empleadoId_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Abonos_ventaSale_Id",
                table: "Abonos",
                column: "ventaSale_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_empleadoId_Empleado",
                table: "Compras",
                column: "empleadoId_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_proveedoresProv_Id",
                table: "Compras",
                column: "proveedoresProv_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_Web_Cliente_Id",
                table: "Cuenta_Web",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Compras_compraPurchase_Id",
                table: "Det_Compras",
                column: "compraPurchase_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Compras_productoProd_Id",
                table: "Det_Compras",
                column: "productoProd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Ventas_ProductoProd_Id",
                table: "Det_Ventas",
                column: "ProductoProd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Ventas_sucursalId_Sucursal",
                table: "Det_Ventas",
                column: "sucursalId_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Det_Ventas_ventaSale_Id",
                table: "Det_Ventas",
                column: "ventaSale_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_SucursalId_Sucursal",
                table: "Empleado",
                column: "SucursalId_Sucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Actividades_EmpId_Empleado",
                table: "Historial_Actividades",
                column: "EmpId_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaId_Marca",
                table: "Producto",
                column: "MarcaId_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClientesCliente_Id",
                table: "Ventas",
                column: "ClientesCliente_Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonos");

            migrationBuilder.DropTable(
                name: "Cuenta_Web");

            migrationBuilder.DropTable(
                name: "Det_Compras");

            migrationBuilder.DropTable(
                name: "Det_Ventas");

            migrationBuilder.DropTable(
                name: "Historial_Actividades");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Estado_Pagos");

            migrationBuilder.DropTable(
                name: "Tipos_Pagos");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
