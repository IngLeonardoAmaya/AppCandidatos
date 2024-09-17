﻿// <auto-generated />
using System;
using AppCandidatos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppCandidatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppCandidatos.Models.Candidate", b =>
                {
                    b.Property<int>("IdCandidate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidate"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdCandidate");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("AppCandidatos.Models.CandidateExperience", b =>
                {
                    b.Property<int>("IdCandidateExperience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidateExperience"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCandidate")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCandidateExperience");

                    b.HasIndex("IdCandidate");

                    b.ToTable("CandidateExperiences");
                });

            modelBuilder.Entity("AppCandidatos.Models.CandidateExperience", b =>
                {
                    b.HasOne("AppCandidatos.Models.Candidate", "Candidate")
                        .WithMany("CandidateExperiences")
                        .HasForeignKey("IdCandidate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("AppCandidatos.Models.Candidate", b =>
                {
                    b.Navigation("CandidateExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
