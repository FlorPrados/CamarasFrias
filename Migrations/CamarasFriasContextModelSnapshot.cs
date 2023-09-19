﻿// <auto-generated />
using System;
using CamarasFrias.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CamarasFrias.Migrations
{
    [DbContext(typeof(CamarasFriasContext))]
    partial class CamarasFriasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CamarasFrias.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Dni")
                        .HasColumnType("int")
                        .HasColumnName("DNI");

                    b.Property<string>("Domicilio")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nchar(15)")
                        .IsFixedLength();

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Dni");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.DetalleVentum", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("PorcDescuento")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("money");

                    b.Property<int>("VentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("DetalleVenta");
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<decimal>("Precio")
                        .HasColumnType("money");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.Ventum", b =>
                {
                    b.Property<int>("NroComprobante")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Nota")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<decimal>("PrecioFinal")
                        .HasColumnType("money");

                    b.HasKey("NroComprobante");

                    b.HasIndex("ClienteId");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.DetalleVentum", b =>
                {
                    b.HasOne("CamarasFrias.Domain.Entities.Producto", "Producto")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleVenta_Productos");

                    b.HasOne("CamarasFrias.Domain.Entities.Ventum", "Venta")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("VentaId")
                        .IsRequired()
                        .HasConstraintName("FK_DetalleVenta_Venta");

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.Ventum", b =>
                {
                    b.HasOne("CamarasFrias.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Venta")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK_Venta_Cliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.Producto", b =>
                {
                    b.Navigation("DetalleVenta");
                });

            modelBuilder.Entity("CamarasFrias.Domain.Entities.Ventum", b =>
                {
                    b.Navigation("DetalleVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
