using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba.Domain.Entities;

namespace Prueba.Infrastructure.Context.Configuration
{
    public class TaskConfig : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {

            builder.ToTable("Tasks");

            builder.HasKey(e => e.Id)
                    .HasName("PK_Task");


            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(e => e.Title)
                    .HasColumnName("Title")
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.Status)
                    .HasColumnName("Status")
                    .HasMaxLength(100);


            builder.Property(e => e.AssignedUserId)
                    .HasColumnName("AssignedUserId")
                    .HasDefaultValue(null);


            // Validación de tipo de dato
           
            builder.Property(e => e.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(e => e.UpdatedAt).HasColumnName("UpdatedAt");


        }
    }
}
