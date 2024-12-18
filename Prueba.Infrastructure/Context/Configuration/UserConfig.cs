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
    public class UserConfig: IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            builder.ToTable("Users");

            builder.HasKey(e => e.Id)
                    .HasName("PK_Users");


            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(e => e.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                    .HasColumnName("PasswordHash")
                    .HasMaxLength(100);

            builder.Property(e => e.Role)
                    .HasColumnName("Role")
                    .HasColumnType("text");

        }
    }
}
