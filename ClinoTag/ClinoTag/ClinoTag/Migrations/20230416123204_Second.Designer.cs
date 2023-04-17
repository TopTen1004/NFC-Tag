﻿// <auto-generated />
using System;
using ClinoTag.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinoTag.Migrations
{
    [DbContext(typeof(CLINOTAGContext))]
    [Migration("20230416123204_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ClinoTag.Models.Agent", b =>
                {
                    b.Property<int>("IdAgent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_AGENT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .HasColumnName("CODE")
                        .IsFixedLength();

                    b.Property<int>("Lang")
                        .HasColumnType("int")
                        .HasColumnName("LANG");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOM");

                    b.HasKey("IdAgent");

                    b.HasIndex(new[] { "Code" }, "AgentCodeUnique")
                        .IsUnique();

                    b.ToTable("AGENT");
                });

            modelBuilder.Entity("ClinoTag.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CLIENT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOM");

                    b.HasKey("IdClient");

                    b.ToTable("CLIENT");
                });

            modelBuilder.Entity("ClinoTag.Models.Lieu", b =>
                {
                    b.Property<int>("IdLieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_LIEU");

                    b.Property<int>("IdClient")
                        .HasColumnType("int")
                        .HasColumnName("ID_CLIENT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOM");

                    b.Property<string>("UidTag")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("UID_TAG");

                    b.HasKey("IdLieu");

                    b.HasIndex("IdClient");

                    b.ToTable("LIEU");
                });

            modelBuilder.Entity("ClinoTag.Models.Passage", b =>
                {
                    b.Property<int>("IdPassage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_PASSAGE");

                    b.Property<string>("Commentaire")
                        .HasColumnType("longtext")
                        .HasColumnName("COMMENTAIRE");

                    b.Property<DateTime>("DhDebut")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DH_DEBUT");

                    b.Property<DateTime>("DhFin")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DH_FIN");

                    b.Property<int>("IdAgent")
                        .HasColumnType("int")
                        .HasColumnName("ID_AGENT");

                    b.Property<int>("IdLieu")
                        .HasColumnType("int")
                        .HasColumnName("ID_LIEU");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("longblob")
                        .HasColumnName("PHOTO");

                    b.HasKey("IdPassage");

                    b.HasIndex("IdAgent");

                    b.HasIndex("IdLieu");

                    b.ToTable("PASSAGE");
                });

            modelBuilder.Entity("ClinoTag.Models.PassageTache", b =>
                {
                    b.Property<int>("IdPt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_PT");

                    b.Property<bool>("Fait")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("FAIT");

                    b.Property<int>("IdPassage")
                        .HasColumnType("int")
                        .HasColumnName("ID_PASSAGE");

                    b.Property<int>("IdTl")
                        .HasColumnType("int")
                        .HasColumnName("ID_TL");

                    b.HasKey("IdPt");

                    b.HasIndex("IdPassage");

                    b.HasIndex("IdTl");

                    b.ToTable("PASSAGE_TACHE");
                });

            modelBuilder.Entity("ClinoTag.Models.Tache", b =>
                {
                    b.Property<int>("IdTache")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TACHE");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOM");

                    b.HasKey("IdTache");

                    b.ToTable("TACHE");
                });

            modelBuilder.Entity("ClinoTag.Models.TacheLieu", b =>
                {
                    b.Property<int>("IdTl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TL");

                    b.Property<int>("IdLieu")
                        .HasColumnType("int")
                        .HasColumnName("ID_LIEU");

                    b.Property<int>("IdTache")
                        .HasColumnType("int")
                        .HasColumnName("ID_TACHE");

                    b.HasKey("IdTl");

                    b.HasIndex("IdTache");

                    b.HasIndex(new[] { "IdLieu", "IdTache" }, "IX_TACHE_LIEU")
                        .IsUnique();

                    b.ToTable("TACHE_LIEU");
                });

            modelBuilder.Entity("ClinoTag.Models.Lieu", b =>
                {
                    b.HasOne("ClinoTag.Models.Client", "IdClientNavigation")
                        .WithMany("Lieus")
                        .HasForeignKey("IdClient")
                        .IsRequired()
                        .HasConstraintName("FK_LIEU_CLIENT");

                    b.Navigation("IdClientNavigation");
                });

            modelBuilder.Entity("ClinoTag.Models.Passage", b =>
                {
                    b.HasOne("ClinoTag.Models.Agent", "IdAgentNavigation")
                        .WithMany("Passages")
                        .HasForeignKey("IdAgent")
                        .IsRequired()
                        .HasConstraintName("FK_PASSAGE_PASSAGE");

                    b.HasOne("ClinoTag.Models.Lieu", "IdLieuNavigation")
                        .WithMany("Passages")
                        .HasForeignKey("IdLieu")
                        .IsRequired()
                        .HasConstraintName("FK_PASSAGE_LIEU");

                    b.Navigation("IdAgentNavigation");

                    b.Navigation("IdLieuNavigation");
                });

            modelBuilder.Entity("ClinoTag.Models.PassageTache", b =>
                {
                    b.HasOne("ClinoTag.Models.Passage", "IdPassageNavigation")
                        .WithMany("PassageTaches")
                        .HasForeignKey("IdPassage")
                        .IsRequired()
                        .HasConstraintName("FK_PASSAGE_TACHE_PASSAGE");

                    b.HasOne("ClinoTag.Models.TacheLieu", "IdTlNavigation")
                        .WithMany("PassageTaches")
                        .HasForeignKey("IdTl")
                        .IsRequired()
                        .HasConstraintName("FK_PASSAGE_TACHE_TACHE_LIEU");

                    b.Navigation("IdPassageNavigation");

                    b.Navigation("IdTlNavigation");
                });

            modelBuilder.Entity("ClinoTag.Models.TacheLieu", b =>
                {
                    b.HasOne("ClinoTag.Models.Lieu", "IdLieuNavigation")
                        .WithMany("TacheLieus")
                        .HasForeignKey("IdLieu")
                        .IsRequired()
                        .HasConstraintName("FK_TACHE_LIEU_LIEU");

                    b.HasOne("ClinoTag.Models.Tache", "IdTacheNavigation")
                        .WithMany("TacheLieus")
                        .HasForeignKey("IdTache")
                        .IsRequired()
                        .HasConstraintName("FK_TACHE_LIEU_TACHE");

                    b.Navigation("IdLieuNavigation");

                    b.Navigation("IdTacheNavigation");
                });

            modelBuilder.Entity("ClinoTag.Models.Agent", b =>
                {
                    b.Navigation("Passages");
                });

            modelBuilder.Entity("ClinoTag.Models.Client", b =>
                {
                    b.Navigation("Lieus");
                });

            modelBuilder.Entity("ClinoTag.Models.Lieu", b =>
                {
                    b.Navigation("Passages");

                    b.Navigation("TacheLieus");
                });

            modelBuilder.Entity("ClinoTag.Models.Passage", b =>
                {
                    b.Navigation("PassageTaches");
                });

            modelBuilder.Entity("ClinoTag.Models.Tache", b =>
                {
                    b.Navigation("TacheLieus");
                });

            modelBuilder.Entity("ClinoTag.Models.TacheLieu", b =>
                {
                    b.Navigation("PassageTaches");
                });
#pragma warning restore 612, 618
        }
    }
}
