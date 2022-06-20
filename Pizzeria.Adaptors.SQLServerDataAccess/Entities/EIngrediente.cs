using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class EIngrediente : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.ToTable("Ingrediente");
            builder.HasKey(e => e.IngredienteID);
            builder
              .HasMany(E => E.crearProductosNav)
              .WithOne(CR => CR.ingredienteNav);
        }

    }
}
