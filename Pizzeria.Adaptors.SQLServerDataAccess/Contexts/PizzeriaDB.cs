using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Pizzeria.Core.Domain.Models;
using Pizzeria.Adaptors.SQLServerDataAccess.Entities;
using Pizzeria.Adaptors.SQLServerDataAccess.Utils;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Contexts
{
    public class PizzeriaDB : DbContext
    {
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CrearProducto> CrearProducto { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalle { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Root> Root { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ECrearProducto());
            modelBuilder.ApplyConfiguration(new EAdministrador());
            modelBuilder.ApplyConfiguration(new ECategoria());
            modelBuilder.ApplyConfiguration(new EEmpleado());
            modelBuilder.ApplyConfiguration(new EFactura());
            modelBuilder.ApplyConfiguration(new EFacturaDetalle());
            modelBuilder.ApplyConfiguration(new EIngrediente());
            modelBuilder.ApplyConfiguration(new EProducto());
            modelBuilder.ApplyConfiguration(new ECliente());
            modelBuilder.ApplyConfiguration(new ERoot());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GlobalSetting.SqlServerConnectionString);
        }
    }

}
