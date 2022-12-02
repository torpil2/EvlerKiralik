﻿// <auto-generated />
using System;
using EvlerKiralik.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EvlerKiralik.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20221123080408_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_catalog", "adminpack");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRole");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique();

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.Ilceler", b =>
                {
                    b.Property<int>("IlceId")
                        .HasColumnType("integer")
                        .HasColumnName("ilce_id");

                    b.Property<string>("IlAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("il_adi");

                    b.Property<int?>("IlId")
                        .HasColumnType("integer")
                        .HasColumnName("il_id");

                    b.Property<string>("IlceAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("ilce_adi");

                    b.HasKey("IlceId")
                        .HasName("ilceler_pkey");

                    b.ToTable("ilceler", (string)null);
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.Iller", b =>
                {
                    b.Property<int>("IlId")
                        .HasColumnType("integer")
                        .HasColumnName("il_id");

                    b.Property<string>("İlAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("İl_adi");

                    b.HasKey("IlId")
                        .HasName("iller_pkey");

                    b.ToTable("iller", (string)null);
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.Mahalleler", b =>
                {
                    b.Property<int>("MahalleId")
                        .HasColumnType("integer")
                        .HasColumnName("mahalle_id");

                    b.Property<string>("IlAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("il_adi");

                    b.Property<int?>("IlId")
                        .HasColumnType("integer")
                        .HasColumnName("il_id");

                    b.Property<string>("IlceAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("ilce_adi");

                    b.Property<int?>("IlceId")
                        .HasColumnType("integer")
                        .HasColumnName("ilce_id");

                    b.Property<string>("MahalleAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("mahalle_adi");

                    b.HasKey("MahalleId")
                        .HasName("mahalleler_pkey");

                    b.ToTable("mahalleler", (string)null);
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.Sokaklar", b =>
                {
                    b.Property<int>("SokakId")
                        .HasColumnType("integer")
                        .HasColumnName("sokak_id");

                    b.Property<string>("IlAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("il_adi");

                    b.Property<int?>("IlId")
                        .HasColumnType("integer")
                        .HasColumnName("il_id");

                    b.Property<string>("IlceAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("ilce_adi");

                    b.Property<int?>("IlceId")
                        .HasColumnType("integer")
                        .HasColumnName("ilce_id");

                    b.Property<string>("MahalleAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("mahalle_adi");

                    b.Property<int?>("MahalleId")
                        .HasColumnType("integer")
                        .HasColumnName("mahalle_id");

                    b.Property<string>("SokakAdi")
                        .HasColumnType("character varying")
                        .HasColumnName("sokak_adi");

                    b.HasKey("SokakId")
                        .HasName("sokaklar_pkey");

                    b.ToTable("sokaklar", (string)null);
                });

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.HasOne("EvlerKiralik.DAL.Entities.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvlerKiralik.DAL.Entities.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetRoleClaim", b =>
                {
                    b.HasOne("EvlerKiralik.DAL.Entities.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUserClaim", b =>
                {
                    b.HasOne("EvlerKiralik.DAL.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUserLogin", b =>
                {
                    b.HasOne("EvlerKiralik.DAL.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUserToken", b =>
                {
                    b.HasOne("EvlerKiralik.DAL.Entities.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");
                });

            modelBuilder.Entity("EvlerKiralik.DAL.Entities.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
