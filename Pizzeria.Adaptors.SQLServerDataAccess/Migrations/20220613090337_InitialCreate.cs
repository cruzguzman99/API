using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    AdministradoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.AdministradoID);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    IngredienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.IngredienteID);
                });

            migrationBuilder.CreateTable(
                name: "Root",
                columns: table => new
                {
                    RootID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Root", x => x.RootID);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tamaño = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCompound = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    FacturaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpleadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.FacturaID);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrearProducto",
                columns: table => new
                {
                    CrearProductoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CantidadIngrediente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoDeIngredientes = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrearProducto", x => x.CrearProductoID);
                    table.ForeignKey(
                        name: "FK_CrearProducto_Ingrediente_IngredienteID",
                        column: x => x.IngredienteID,
                        principalTable: "Ingrediente",
                        principalColumn: "IngredienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrearProducto_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalle",
                columns: table => new
                {
                    ProductoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacturaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatidadProductosVendido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoProductosVendido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioProductosVendido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalle", x => new { x.ProductoID, x.FacturaID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Factura_FacturaID",
                        column: x => x.FacturaID,
                        principalTable: "Factura",
                        principalColumn: "FacturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrearProducto_IngredienteID",
                table: "CrearProducto",
                column: "IngredienteID");

            migrationBuilder.CreateIndex(
                name: "IX_CrearProducto_ProductoID",
                table: "CrearProducto",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteID",
                table: "Factura",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_EmpleadoID",
                table: "Factura",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_FacturaID",
                table: "FacturaDetalle",
                column: "FacturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaID",
                table: "Producto",
                column: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "CrearProducto");

            migrationBuilder.DropTable(
                name: "FacturaDetalle");

            migrationBuilder.DropTable(
                name: "Root");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
