﻿// <auto-generated />
using System;
using ACSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ACSystem.Persistence.Migrations
{
    [DbContext(typeof(ACSystemDbContext))]
    partial class ACSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ACSystem.Domain.Entity.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDateMl")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateDateSh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdentityCode")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.Letter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateMl")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateDateSh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LetterTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LetterTypeId");

                    b.ToTable("Letter");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterAttach", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDateMl")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateDateSh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("LetterReferenceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LetterReferenceId");

                    b.ToTable("LetterAttach");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterNote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDateMl")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateDateSh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("LetterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LetterId");

                    b.ToTable("LetterNote");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterReference", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDateMl")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateDateSh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FromEmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("LetterId")
                        .HasColumnType("bigint");

                    b.Property<string>("ReplyText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ToEmployeeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FromEmployeeId");

                    b.HasIndex("LetterId");

                    b.HasIndex("ToEmployeeId");

                    b.ToTable("LetterReference");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateMl")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateDateSh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LetterType");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.Letter", b =>
                {
                    b.HasOne("ACSystem.Domain.Entity.Employee", "Employee")
                        .WithMany("Letters")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSystem.Domain.Entity.LetterType", "LetterType")
                        .WithMany("Letters")
                        .HasForeignKey("LetterTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LetterType");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterAttach", b =>
                {
                    b.HasOne("ACSystem.Domain.Entity.LetterReference", "LetterReference")
                        .WithMany("attaches")
                        .HasForeignKey("LetterReferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LetterReference");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterNote", b =>
                {
                    b.HasOne("ACSystem.Domain.Entity.Employee", "Employee")
                        .WithMany("LetterNotes")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSystem.Domain.Entity.Letter", "Letter")
                        .WithMany("LetterNotes")
                        .HasForeignKey("LetterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Letter");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterReference", b =>
                {
                    b.HasOne("ACSystem.Domain.Entity.Employee", "FromEmployee")
                        .WithMany()
                        .HasForeignKey("FromEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSystem.Domain.Entity.Letter", "Letter")
                        .WithMany("LetterReferences")
                        .HasForeignKey("LetterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ACSystem.Domain.Entity.Employee", "ToEmployee")
                        .WithMany()
                        .HasForeignKey("ToEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromEmployee");

                    b.Navigation("Letter");

                    b.Navigation("ToEmployee");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.Employee", b =>
                {
                    b.Navigation("LetterNotes");

                    b.Navigation("Letters");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.Letter", b =>
                {
                    b.Navigation("LetterNotes");

                    b.Navigation("LetterReferences");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterReference", b =>
                {
                    b.Navigation("attaches");
                });

            modelBuilder.Entity("ACSystem.Domain.Entity.LetterType", b =>
                {
                    b.Navigation("Letters");
                });
#pragma warning restore 612, 618
        }
    }
}
