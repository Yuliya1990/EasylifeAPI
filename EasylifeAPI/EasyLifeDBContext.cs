using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasylifeAPI
{
    public partial class EasyLifeDBContext : DbContext
    {
        public EasyLifeDBContext()
        {
        }

        public EasyLifeDBContext(DbContextOptions<EasyLifeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CleaningComponent> CleaningComponents { get; set; } = null!;
        public virtual DbSet<CleaningType> CleaningTypes { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<RealEstate> RealEstates { get; set; } = null!;
        public virtual DbSet<SelectedComponent> SelectedComponents { get; set; } = null!;
        public virtual DbSet<TypeComponent> TypeComponents { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;
        public virtual DbSet<WorkerOrder> WorkerOrders { get; set; } = null!;
        public virtual DbSet<WorkerSkill> WorkerSkills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= LAPTOP-F3BNFL5F; Database=EasyLifeDB; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CleaningComponent>(entity =>
            {
                entity.HasKey(e => e.CleaningComponentsid)
                    .HasName("PK__ServiceC__B80E5879D65785FC");

                entity.HasIndex(e => e.Name, "UQ__ServiceC__737584F6AA6BDFC9")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.TimeMinuts).HasColumnName("time_minuts");
            });

            modelBuilder.Entity<CleaningType>(entity =>
            {
                entity.ToTable("CleaningType");

                entity.HasIndex(e => e.Name, "UQ__Service__737584F69C077536")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TimeStart).HasColumnType("time(0)");

                entity.HasOne(d => d.RealEstate)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RealEstateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_RealEstate1");
            });

            modelBuilder.Entity<RealEstate>(entity =>
            {
                entity.ToTable("RealEstate");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.RealEstates)
                    .HasForeignKey(d => d.Clientid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RealEstate_Client");
            });

            modelBuilder.Entity<SelectedComponent>(entity =>
            {
                entity.HasKey(e => e.SelectedComponentsid)
                    .HasName("PK__ServiceO__8E1BB94DECEA74E4");

                entity.HasOne(d => d.CleaningComponent)
                    .WithMany(p => p.SelectedComponents)
                    .HasForeignKey(d => d.CleaningComponentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SelectedComponents_CleaningComponents");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SelectedComponents)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SelectedComponents_Order");
            });

            modelBuilder.Entity<TypeComponent>(entity =>
            {
                entity.ToTable("Type_Component");

                entity.HasIndex(e => new { e.Typeid, e.Componentid }, "UC_TC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.TypeComponents)
                    .HasForeignKey(d => d.Componentid)
                    .HasConstraintName("FK_Type_Component_CleaningComponents");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TypeComponents)
                    .HasForeignKey(d => d.Typeid)
                    .HasConstraintName("FK_Type_Component_CleaningType");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<WorkerOrder>(entity =>
            {
                entity.ToTable("Worker_Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.WorkerOrders)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Order_Order");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.WorkerOrders)
                    .HasForeignKey(d => d.Workerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Order_Worker");
            });

            modelBuilder.Entity<WorkerSkill>(entity =>
            {
                entity.ToTable("Worker_Skill");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SkillId).HasColumnName("Skill_id");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.WorkerSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Skill_CleaningComponents");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.WorkerSkills)
                    .HasForeignKey(d => d.Workerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Skill_Worker");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
