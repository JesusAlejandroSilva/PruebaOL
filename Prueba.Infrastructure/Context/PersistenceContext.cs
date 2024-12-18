using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prueba.Domain.Entities;
using Prueba.Domain.Entities.Base;

namespace Prueba.Infrastructure.Context
{
    public class PersistenceContext:DbContext
    {
        private readonly IConfiguration _config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            _config = config;

        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }


        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }



            // Itera solo las entidades que heredan de DomainEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                if (typeof(DomainEntity).IsAssignableFrom(clrType))
                {
                    // Configura las propiedades SOLO si no están definidas explícitamente
                    var entityBuilder = modelBuilder.Entity(clrType);

                    if (!entityBuilder.Metadata.FindProperty("CreatedAt").IsPrimaryKey())
                    {
                        entityBuilder.Property<DateTime>("CreatedAt").HasDefaultValueSql("NOW()");
                    }

                    if (!entityBuilder.Metadata.FindProperty("UpdatedAt").IsPrimaryKey())
                    {
                        entityBuilder.Property<DateTime>("UpdatedAt").HasDefaultValueSql("NOW()");
                    }

                    if (!entityBuilder.Metadata.FindProperty("DeletedOn").IsPrimaryKey())
                    {
                        entityBuilder.Property<DateTime?>("DeletedOn").HasDefaultValueSql("NULL");
                    }

                    if (!entityBuilder.Metadata.FindProperty("IsDeleted").IsPrimaryKey())
                    {
                        entityBuilder.Property<bool>("IsDeleted").HasDefaultValue(false);
                    }
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            // Llama al método base
            base.OnModelCreating(modelBuilder);
        }
    }
}
