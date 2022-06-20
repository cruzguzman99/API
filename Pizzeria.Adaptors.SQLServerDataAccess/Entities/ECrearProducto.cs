using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class ECrearProducto : IEntityTypeConfiguration<CrearProducto>
    {
        public void Configure(EntityTypeBuilder<CrearProducto> builder)
        {
            builder.ToTable("CrearProducto");
            builder.HasKey(CR => CR.CrearProductoID);
            builder
              .HasOne(crearProducto => crearProducto.productoNav)
              .WithMany(producto => producto.crearProductosNav);
            builder
               .HasOne(crearProducto => crearProducto.ingredienteNav)
               .WithMany(ingrediente => ingrediente.crearProductosNav);
        }

    }
}
