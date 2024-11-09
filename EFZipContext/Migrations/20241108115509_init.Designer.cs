﻿// <auto-generated />
using EFZipContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFZipContext.Migrations
{
    [DbContext(typeof(ArchiveContext))]
    [Migration("20241108115509_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFZipContext.Models.ArchiveEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Size")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Archives");
                });

            modelBuilder.Entity("EFZipContext.Models.FileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArchiveId")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("FileSize")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ArchiveId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("EFZipContext.Models.FileEntity", b =>
                {
                    b.HasOne("EFZipContext.Models.ArchiveEntity", "Archive")
                        .WithMany("Files")
                        .HasForeignKey("ArchiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Archive");
                });

            modelBuilder.Entity("EFZipContext.Models.ArchiveEntity", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}