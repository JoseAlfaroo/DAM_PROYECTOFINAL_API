﻿// <auto-generated />
using System;
using DAMI_WEBAPI_PROYECTOFINAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAMIWEBAPIPROYECTOFINAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAMI_WEBAPI_PROYECTOFINAL.Models.DetallePrestamoModel", b =>
                {
                    b.Property<int?>("DetallePrestamoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("DetallePrestamoID"));

                    b.Property<int?>("LibroID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PrestamoID")
                        .HasColumnType("int");

                    b.HasKey("DetallePrestamoID");

                    b.HasIndex("LibroID");

                    b.HasIndex("PrestamoID");

                    b.ToTable("DetallesPrestamos");
                });

            modelBuilder.Entity("DAMI_WEBAPI_PROYECTOFINAL.Models.LibroModel", b =>
                {
                    b.Property<int?>("LibroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LibroID"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibroID");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("DAMI_WEBAPI_PROYECTOFINAL.Models.PrestamoModel", b =>
                {
                    b.Property<int?>("PrestamoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PrestamoID"));

                    b.Property<DateTime?>("FechaPrestamo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("PrestamoID");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("DAMI_WEBAPI_PROYECTOFINAL.Models.UserModel", b =>
                {
                    b.Property<int?>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UserID"));

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAMI_WEBAPI_PROYECTOFINAL.Models.DetallePrestamoModel", b =>
                {
                    b.HasOne("DAMI_WEBAPI_PROYECTOFINAL.Models.LibroModel", "Libro")
                        .WithMany("DetallesPrestamos")
                        .HasForeignKey("LibroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAMI_WEBAPI_PROYECTOFINAL.Models.PrestamoModel", "Prestamo")
                        .WithMany("DetallesPrestamos")
                        .HasForeignKey("PrestamoID");

                    b.Navigation("Libro");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("DAMI_WEBAPI_PROYECTOFINAL.Models.LibroModel", b =>
                {
                    b.Navigation("DetallesPrestamos");
                });

            modelBuilder.Entity("DAMI_WEBAPI_PROYECTOFINAL.Models.PrestamoModel", b =>
                {
                    b.Navigation("DetallesPrestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
