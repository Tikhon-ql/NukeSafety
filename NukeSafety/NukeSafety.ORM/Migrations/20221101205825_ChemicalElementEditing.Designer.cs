﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NukeSafety.ORM.Context;

#nullable disable

namespace NukeSafety.ORM.Migrations
{
    [DbContext(typeof(NukeSafetyContext))]
    [Migration("20221101205825_ChemicalElementEditing")]
    partial class ChemicalElementEditing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BombCountry", b =>
                {
                    b.Property<int>("BombsId")
                        .HasColumnType("int");

                    b.Property<int>("OnArmsId")
                        .HasColumnType("int");

                    b.HasKey("BombsId", "OnArmsId");

                    b.HasIndex("OnArmsId");

                    b.ToTable("BombCountry");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Bomb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("BlastYield")
                        .HasColumnType("float");

                    b.Property<int>("FillingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FillingId");

                    b.ToTable("Bombs");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.ChemicalElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("HalfLive")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.Explosion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BombId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BombId");

                    b.ToTable("Explosions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Explosion");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.AirExplosion", b =>
                {
                    b.HasBaseType("NukeSafety.ORM.Models.Explosions.Explosion");

                    b.HasDiscriminator().HasValue("AirExplosion");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.CosmicExplosion", b =>
                {
                    b.HasBaseType("NukeSafety.ORM.Models.Explosions.Explosion");

                    b.HasDiscriminator().HasValue("CosmicExplosion");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.GroundExplosion", b =>
                {
                    b.HasBaseType("NukeSafety.ORM.Models.Explosions.Explosion");

                    b.HasDiscriminator().HasValue("GroundExplosion");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.HeightExplosion", b =>
                {
                    b.HasBaseType("NukeSafety.ORM.Models.Explosions.Explosion");

                    b.HasDiscriminator().HasValue("HeightExplosion");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.UndergroundExplosion", b =>
                {
                    b.HasBaseType("NukeSafety.ORM.Models.Explosions.Explosion");

                    b.HasDiscriminator().HasValue("UndergroundExplosion");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.UnderwaterExplosion", b =>
                {
                    b.HasBaseType("NukeSafety.ORM.Models.Explosions.Explosion");

                    b.HasDiscriminator().HasValue("UnderwaterExplosion");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.WaterExplosion", b =>
                {
                    b.HasBaseType("NukeSafety.ORM.Models.Explosions.Explosion");

                    b.HasDiscriminator().HasValue("WaterExplosion");
                });

            modelBuilder.Entity("BombCountry", b =>
                {
                    b.HasOne("NukeSafety.ORM.Models.Bomb", null)
                        .WithMany()
                        .HasForeignKey("BombsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NukeSafety.ORM.Models.Country", null)
                        .WithMany()
                        .HasForeignKey("OnArmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Bomb", b =>
                {
                    b.HasOne("NukeSafety.ORM.Models.ChemicalElement", "Filling")
                        .WithMany()
                        .HasForeignKey("FillingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filling");
                });

            modelBuilder.Entity("NukeSafety.ORM.Models.Explosions.Explosion", b =>
                {
                    b.HasOne("NukeSafety.ORM.Models.Bomb", "Bomb")
                        .WithMany()
                        .HasForeignKey("BombId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bomb");
                });
#pragma warning restore 612, 618
        }
    }
}
