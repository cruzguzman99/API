using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class EFactura : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(F => F.FacturaID);
            builder
              .HasOne(F => F.clienteNav)
              .WithMany(C => C.facturasNav);
            builder
               .HasOne(F => F.empleadoNav)
               .WithMany(E => E.facturasNav);
            builder
             .HasMany(F => F.facturaDetallesNav)
             .WithOne(FD => FD.facturaNav);
        }

    }
}
