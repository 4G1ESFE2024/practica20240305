using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Practica20240305.Models
{
    public partial class Practica20240305DBContext : DbContext
    {
        public Practica20240305DBContext()
        {
        }

        public Practica20240305DBContext(DbContextOptions<Practica20240305DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetFacturaVenta> DetFacturaVentas { get; set; } = null!;
        public virtual DbSet<FacturaVenta> FacturaVentas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Practica20240305DB;Integrated Security=True;Encrypt=False");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetFacturaVenta>(entity =>
            {
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Producto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFacturaVentaNavigation)
                    .WithMany(p => p.DetFacturaVenta)
                    .HasForeignKey(d => d.IdFacturaVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetFactur__IdFac__3D5E1FD2");
            });

            modelBuilder.Entity<FacturaVenta>(entity =>
            {
                entity.Property(e => e.Cliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correlativo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVenta).HasColumnType("date");

                entity.Property(e => e.TotalVenta).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
