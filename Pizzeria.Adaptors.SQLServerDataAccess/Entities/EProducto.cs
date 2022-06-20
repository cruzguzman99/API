using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class EProducto : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(P => P.ProductoID);
            builder.HasOne(producto => producto.categoriaNav)
             .WithMany(categoria => categoria.productosNav);

            builder.HasMany(producto => producto.crearProductosNav)
            .WithOne(crearProduc => crearProduc.productoNav);
        }

    }
}
