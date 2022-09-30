using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasylifeAPI
{
    public partial class EasyLifeApiDBContext : DbContext
    {
        public EasyLifeApiDBContext()
        {
        }

        public EasyLifeApiDBContext(DbContextOptions<EasyLifeApiDBContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Cleaning> Cleanings { get; set; } = null!;
        public virtual DbSet<Component> Components { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<RealEstate> RealEstates { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__ServiceC__737584F6AA6BDFC9")
                     .IsUnique();

                entity.HasMany(c => c.Workers)
                    .WithMany(w => w.Components)
                    .UsingEntity(j => j.ToTable("WorkerSkills"));


                entity.HasMany(c => c.Orders)
                    .WithMany(o => o.Components)
                    .UsingEntity(j => j.ToTable("ComponentOrder"));

            });

            modelBuilder.Entity<Cleaning>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Service__737584F69C077536")
                    .IsUnique();

                entity.HasMany(cleaning => cleaning.Components)
                    .WithMany(component => component.Cleanings)
                    .UsingEntity(j => j.ToTable("CleaningComponent"));


            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.RealEstate)
                    .WithMany(r => r.Orders)
                    .HasForeignKey(j => j.RealEstateid)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(o => o.Workers)
                    .WithMany(w => w.Orders)
                    .UsingEntity(j => j.ToTable("WorkerOrder"));
            });

            modelBuilder.Entity<RealEstate>(entity =>
            {
                entity.HasOne(r => r.Client)
                    .WithMany(c => c.RealEstates)
                    .HasForeignKey(d => d.Clientid)
                    .OnDelete(DeleteBehavior.Cascade);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
