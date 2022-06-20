using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class EEmpleado : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.HasKey(E => E.EmpleadoID);
            builder.HasMany(E => E.facturasNav)
                   .WithOne(factura => factura.empleadoNav);
        }

    }
}
