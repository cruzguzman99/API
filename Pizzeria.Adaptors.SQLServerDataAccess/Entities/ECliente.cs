using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class ECliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(C => C.ClienteID);
            builder
              .HasMany(C => C.facturasNav)
              .WithOne(F => F.clienteNav);
        }

    }
}
