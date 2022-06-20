using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class ECategoria : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(e => e.CategoriaID);

            builder.ToTable("Categoria");
            builder
                .HasMany(categoria => categoria.productosNav)
                .WithOne(producto => producto.categoriaNav);
        }

    }
}
