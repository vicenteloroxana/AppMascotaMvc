﻿// <auto-generated />
using System;
using AppMascotaMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppMascotaMvc.Migrations
{
    [DbContext(typeof(MascotaContext))]
    partial class MascotaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AppMascotaMvc.Models.Ficha", b =>
                {
                    b.Property<Guid>("FichaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Control")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Fr")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("MascotaID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Medicacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mucosa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pelaje")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pulso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Raza")
                        .HasColumnType("TEXT");

                    b.Property<string>("SSP")
                        .HasColumnType("TEXT");

                    b.Property<string>("SignosClinicos")
                        .HasColumnType("TEXT");

                    b.Property<string>("T")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tllc")
                        .HasColumnType("TEXT");

                    b.HasKey("FichaID");

                    b.HasIndex("MascotaID")
                        .IsUnique();

                    b.ToTable("Fichas");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Mascota", b =>
                {
                    b.Property<Guid>("MascotaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Caracteristica")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacion")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropietarioID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Raza")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .HasColumnType("TEXT");

                    b.HasKey("MascotaID");

                    b.HasIndex("PropietarioID");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Movil", b =>
                {
                    b.Property<Guid>("MovilID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Barrio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<string>("Servicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Telefono")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Zona")
                        .HasColumnType("TEXT");

                    b.HasKey("MovilID");

                    b.ToTable("Moviles");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Propietario", b =>
                {
                    b.Property<Guid>("PropietarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<int>("CantidadMascotasPermitidas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DNI")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Domicilio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombrePersona")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("PropietarioID");

                    b.ToTable("Propietarios");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Turno", b =>
                {
                    b.Property<Guid>("TurnoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Atendido")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacion")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PropietarioID")
                        .HasColumnType("TEXT");

                    b.HasKey("TurnoID");

                    b.HasIndex("PropietarioID");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Ficha", b =>
                {
                    b.HasOne("AppMascotaMvc.Models.Mascota", "Mascota")
                        .WithOne("Ficha")
                        .HasForeignKey("AppMascotaMvc.Models.Ficha", "MascotaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Mascota", b =>
                {
                    b.HasOne("AppMascotaMvc.Models.Propietario", "Propietario")
                        .WithMany("Mascotas")
                        .HasForeignKey("PropietarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Turno", b =>
                {
                    b.HasOne("AppMascotaMvc.Models.Propietario", "Propietario")
                        .WithMany("Turnos")
                        .HasForeignKey("PropietarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Mascota", b =>
                {
                    b.Navigation("Ficha");
                });

            modelBuilder.Entity("AppMascotaMvc.Models.Propietario", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Turnos");
                });
#pragma warning restore 612, 618
        }
    }
}