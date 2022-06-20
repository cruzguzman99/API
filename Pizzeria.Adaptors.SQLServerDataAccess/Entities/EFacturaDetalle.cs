using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class EFacturaDetalle : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            builder.ToTable("FacturaDetalle");
            builder.HasKey(e => new { e.ProductoID, e.FacturaID })
                   .IsClustered(false);
            builder
              .HasOne(FD => FD.productoNav)
              .WithMany(P => P.facturaDetalleNav);
            builder
               .HasOne(FD => FD.facturaNav)
               .WithMany(F => F.facturaDetallesNav);
        }

    }
}
