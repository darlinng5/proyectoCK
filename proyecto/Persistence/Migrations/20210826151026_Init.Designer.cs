﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210826151026_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ClienteDomain", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Apellido");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("idCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Domain.ControldeAprobacionPedido", b =>
                {
                    b.Property<int>("idControlDeAprobacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PedidoidPedido")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioidUduario")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaAprobacion")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2")
                        .HasColumnName("Nombre");

                    b.Property<int>("idPedido")
                        .HasColumnType("int")
                        .HasColumnName("idPedido1");

                    b.Property<int>("idUduario")
                        .HasColumnType("int")
                        .HasColumnName("idPedido");

                    b.HasKey("idControlDeAprobacion");

                    b.HasIndex("PedidoidPedido");

                    b.HasIndex("UsuarioidUduario");

                    b.ToTable("ControlAprobacionPedido");
                });

            modelBuilder.Entity("Domain.DetallePedidoDomain", b =>
                {
                    b.Property<int>("idDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PedidoidPedido")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoidProducto")
                        .HasColumnType("int");

                    b.Property<long>("cantidad")
                        .HasColumnType("bigint")
                        .HasColumnName("Cantidad");

                    b.Property<int>("idPedido")
                        .HasColumnType("int")
                        .HasColumnName("idPedido");

                    b.Property<int>("idProducto")
                        .HasColumnType("int")
                        .HasColumnName("idProducto");

                    b.HasKey("idDetalle");

                    b.HasIndex("PedidoidPedido");

                    b.HasIndex("ProductoidProducto");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("Domain.PedidoDomain", b =>
                {
                    b.Property<int>("idPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("clientePedidoidCliente")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Estado");

                    b.Property<DateTime>("fechaRegistro")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha Registro");

                    b.Property<int>("idCliente")
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    b.HasKey("idPedido");

                    b.HasIndex("clientePedidoidCliente");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Domain.ProductoDomain", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("Precio");

                    b.HasKey("idProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Domain.UsuarioDomain", b =>
                {
                    b.Property<int>("idUduario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Apellido");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("idUduario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Domain.ControldeAprobacionPedido", b =>
                {
                    b.HasOne("Domain.PedidoDomain", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoidPedido")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.UsuarioDomain", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioidUduario")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Pedido");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.DetallePedidoDomain", b =>
                {
                    b.HasOne("Domain.PedidoDomain", "Pedido")
                        .WithMany("DetallePedido")
                        .HasForeignKey("PedidoidPedido")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.ProductoDomain", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoidProducto")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Domain.PedidoDomain", b =>
                {
                    b.HasOne("Domain.ClienteDomain", "clientePedido")
                        .WithMany()
                        .HasForeignKey("clientePedidoidCliente")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("clientePedido");
                });

            modelBuilder.Entity("Domain.PedidoDomain", b =>
                {
                    b.Navigation("DetallePedido");
                });
#pragma warning restore 612, 618
        }
    }
}
