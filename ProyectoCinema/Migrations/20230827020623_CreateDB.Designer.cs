﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoCinema;

#nullable disable

namespace ProyectoCinema.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20230827020623_CreateDB")]
    partial class CreateDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoCinema.Funcion", b =>
                {
                    b.Property<int>("FuncionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("FuncionId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funciones");
                });

            modelBuilder.Entity("ProyectoCinema.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ProyectoCinema.Pelicula", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeliculaId"));

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sonopsis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeliculaId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("ProyectoCinema.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaId"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalaId");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("ProyectoCinema.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FuncionId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.HasIndex("FuncionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ProyectoCinema.Funcion", b =>
                {
                    b.HasOne("ProyectoCinema.Pelicula", "Pelicula")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoCinema.Sala", "Sala")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("ProyectoCinema.Pelicula", b =>
                {
                    b.HasOne("ProyectoCinema.Genero", "Genero")
                        .WithMany("Peliculas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("ProyectoCinema.Ticket", b =>
                {
                    b.HasOne("ProyectoCinema.Funcion", "Funcion")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcion");
                });

            modelBuilder.Entity("ProyectoCinema.Funcion", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ProyectoCinema.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("ProyectoCinema.Pelicula", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("ProyectoCinema.Sala", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
