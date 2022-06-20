using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;


namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class EAdministrador : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.HasKey(A => A.AdministradoID);

            builder.ToTable("Administrador");
        }

    }
}
