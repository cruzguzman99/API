USE master
GO

CREATE DATABASE PizzeriaEveling
GO

USE PizzeriaEveling
GO

CREATE TABLE Administrador(
	AdministradoID uniqueidentifier NOT NULL,
	Nombre varchar(25) NOT NULL,
	Correo varchar(25) NOT NULL,
	tipo int NOT NULL,
	Apellido varchar(25) NOT NULL,
	Imagen varchar(70) NOT NULL,
	telefono int NOT NULL,
	genero char(1) NULL,
	Contraseña varchar(30) NULL,
)

CREATE TABLE Categoria(
	CategoriaID uniqueidentifier NOT NULL,
	Nombre varchar(25) NOT NULL,
	Descripcion text NULL,
) 

CREATE TABLE Cliente(
	ClienteID uniqueidentifier NOT NULL,
	Nombre varchar(25) NOT NULL,
	Apellido varchar(25) NOT NULL,
	Correo varchar(25) NOT NULL,
	telefono int NOT NULL,
	Imagen varchar(70) NOT NULL,
	genero char(1) NULL,
	tipo int NOT NULL,
	Contraseña varchar(30) NULL,
)

CREATE TABLE CrearProducto(
	CrearProductoID uniqueidentifier NOT NULL,
	ProductoID uniqueidentifier NOT NULL,
	IngredienteID uniqueidentifier NOT NULL,
	CantidadIngrediente decimal(18, 0) NOT NULL,
	CostoDeIngredientes decimal(18, 0) NOT NULL,
)

CREATE TABLE Empleado(
	EmpleadoID uniqueidentifier NOT NULL,
	Nombre varchar(25) NOT NULL,
	Apellido varchar(25) NOT NULL,
	telefono int NOT NULL,
	genero char(1) NULL,
	Imagen varchar(70) NOT NULL,
	Correo varchar(25) NOT NULL,
	tipo int NOT NULL,
	Contraseña varchar(30) NULL,
)

CREATE TABLE Factura(
	FacturaID uniqueidentifier NOT NULL,
	EmpleadoID uniqueidentifier NOT NULL,
	ClienteID uniqueidentifier NOT NULL,
	Total decimal(18, 0) NOT NULL,
	Fecha datetime NOT NULL,
)

CREATE TABLE FacturaDetalle(
	ProductoID uniqueidentifier NOT NULL,
	FacturaID uniqueidentifier NOT NULL,
	CatidadProductosVendido decimal(18, 0) NOT NULL,
	CostoProductosVendido decimal(18, 0) NOT NULL,
	PrecioProductosVendido decimal(18, 0) NOT NULL,
)

CREATE TABLE Ingrediente(
	IngredienteID uniqueidentifier NOT NULL,
	Nombre varchar(25) NOT NULL,
	precio decimal(18, 0) NOT NULL,
	Stock decimal(18, 0) NOT NULL,
	Imagen varchar(70) NOT NULL,
	unidadMedida varchar(10) NOT NULL,
)

CREATE TABLE Producto(
	ProductoID uniqueidentifier NOT NULL,
	CategoriaID uniqueidentifier NOT NULL,
	Nombre varchar(25) NOT NULL,
	Precio decimal(18, 0) NOT NULL,
	Costo decimal(18, 0) NOT NULL,
	Tamaño varchar(25) NOT NULL,
	Stock decimal(18, 0) NOT NULL,
	Imagen varchar(70) NOT NULL,
	isCompound bit NOT NULL,
	Descripcion text NULL,
) 

CREATE TABLE Root(
	RootID uniqueidentifier NOT NULL,
	Nombre varchar(25) NOT NULL,
	Apellido varchar(25) NOT NULL,
	telefono int NOT NULL,
	Imagen varchar(70) NOT NULL,
	genero char(1) NULL,
	Correo varchar(25) NOT NULL,
	tipo int NOT NULL,
	Contraseña varchar(30) NULL,
)
