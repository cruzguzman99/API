using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Core.Domain.Models;

namespace Pizzeria.Adaptors.SQLServerDataAccess.Entities
{
    public class ERoot : IEntityTypeConfiguration<Root>
    {
        public void Configure(EntityTypeBuilder<Root> builder)
        {
            builder.HasKey(A => A.RootID);

            builder.ToTable("Root");
        }

    }
}
