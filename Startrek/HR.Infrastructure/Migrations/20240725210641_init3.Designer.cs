﻿// <auto-generated />
using System;
using HR.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HR.Infrastructure.Migrations
{
    [DbContext(typeof(DbContextEF))]
    [Migration("20240725210641_init3")]
    partial class init3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CandidateVacancy", b =>
                {
                    b.Property<Guid>("CandidatesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VacanciesId")
                        .HasColumnType("uuid");

                    b.HasKey("CandidatesId", "VacanciesId");

                    b.HasIndex("VacanciesId");

                    b.ToTable("CandidateVacancy");
                });

            modelBuilder.Entity("HR.Domain.Entities.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("HR.Domain.Entities.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<bool>("Conducted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateOfEvent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Feedback")
                        .HasColumnType("text");

                    b.Property<Guid>("VacancyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("HR.Domain.Entities.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateOfIssue")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("InterviewId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("HR.Domain.Entities.Vacancy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("CandidateVacancy", b =>
                {
                    b.HasOne("HR.Domain.Entities.Candidate", null)
                        .WithMany()
                        .HasForeignKey("CandidatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR.Domain.Entities.Vacancy", null)
                        .WithMany()
                        .HasForeignKey("VacanciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
