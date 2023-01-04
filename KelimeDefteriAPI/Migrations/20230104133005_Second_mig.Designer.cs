﻿// <auto-generated />
using System;
using KelimeDefteriAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KelimeDefteriAPI.Migrations
{
    [DbContext(typeof(KelifeDefteriAPIContext))]
    [Migration("20230104133005_Second_mig")]
    partial class Secondmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KelimeDefteriAPI.Context.EntityConcretes.Definition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WordId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("Definitions");

                    b.HasData(
                        new
                        {
                            Id = -1L,
                            Description = "test1description",
                            DescriptionType = "test1descriptionType",
                            WordId = -1L
                        },
                        new
                        {
                            Id = -2L,
                            Description = "test1description",
                            DescriptionType = "test1descriptionType",
                            WordId = -1L
                        },
                        new
                        {
                            Id = -3L,
                            Description = "test2description",
                            DescriptionType = "test2descriptionType",
                            WordId = -2L
                        },
                        new
                        {
                            Id = -4L,
                            Description = "test2description",
                            DescriptionType = "test2descriptionType",
                            WordId = -2L
                        },
                        new
                        {
                            Id = -5L,
                            Description = "test3description",
                            DescriptionType = "test3descriptionType",
                            WordId = -3L
                        },
                        new
                        {
                            Id = -6L,
                            Description = "test3description",
                            DescriptionType = "test3descriptionType",
                            WordId = -3L
                        },
                        new
                        {
                            Id = -7L,
                            Description = "test4description",
                            DescriptionType = "test4descriptionType",
                            WordId = -4L
                        },
                        new
                        {
                            Id = -8L,
                            Description = "test4description",
                            DescriptionType = "test4descriptionType",
                            WordId = -4L
                        });
                });

            modelBuilder.Entity("KelimeDefteriAPI.Context.EntityConcretes.Record", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            Id = -1L,
                            Created = new DateTime(2023, 1, 4, 16, 30, 5, 690, DateTimeKind.Local).AddTicks(3061)
                        });
                });

            modelBuilder.Entity("KelimeDefteriAPI.Context.EntityConcretes.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecordId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.ToTable("Words");

                    b.HasData(
                        new
                        {
                            Id = -1L,
                            Name = "TEST1",
                            RecordId = -1L
                        },
                        new
                        {
                            Id = -2L,
                            Name = "TEST2",
                            RecordId = -1L
                        },
                        new
                        {
                            Id = -3L,
                            Name = "TEST3",
                            RecordId = -1L
                        },
                        new
                        {
                            Id = -4L,
                            Name = "TEST4",
                            RecordId = -1L
                        });
                });

            modelBuilder.Entity("KelimeDefteriAPI.Context.EntityConcretes.Definition", b =>
                {
                    b.HasOne("KelimeDefteriAPI.Context.EntityConcretes.Word", null)
                        .WithMany("Definitions")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KelimeDefteriAPI.Context.EntityConcretes.Word", b =>
                {
                    b.HasOne("KelimeDefteriAPI.Context.EntityConcretes.Record", null)
                        .WithMany("Words")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KelimeDefteriAPI.Context.EntityConcretes.Record", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("KelimeDefteriAPI.Context.EntityConcretes.Word", b =>
                {
                    b.Navigation("Definitions");
                });
#pragma warning restore 612, 618
        }
    }
}