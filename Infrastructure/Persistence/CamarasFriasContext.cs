using System;
using System.Collections.Generic;
using CamarasFrias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CamarasFrias.Infrastructure.Persistence
{
    public partial class CamarasFriasContext : DbContext
    {
        public CamarasFriasContext()
        {
        }

        public CamarasFriasContext(DbContextOptions<CamarasFriasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.ToTable("Cliente");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("DNI");

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.Property(e => e.Subtotal).HasColumnType("money");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleVenta_Productos");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleVenta_Venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Precio).HasColumnType("money");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.NroComprobante);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nota)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.PrecioFinal).HasColumnType("money");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
