﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Service.Data;
using System;

namespace Service.Migrations
{
    [DbContext(typeof(PoseidonContext))]
    [Migration("20171002210023_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Service.Models.Entity.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseType");

                    b.Property<int>("LengthInMinutes");

                    b.Property<string>("Location");

                    b.Property<string>("Schedule");

                    b.Property<int>("SubjectID");

                    b.HasKey("CourseID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Service.Models.Entity.Student", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<string>("Name");

                    b.Property<string>("NeptuneCode");

                    b.HasKey("StudentId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Service.Models.Entity.StudentSubject", b =>
                {
                    b.Property<int>("Grade");

                    b.Property<int>("EnrollmentSemenster");

                    b.Property<bool>("Passed");

                    b.Property<bool>("Signature");

                    b.Property<int>("StudentID");

                    b.Property<int>("SubjectID");

                    b.HasKey("Grade", "EnrollmentSemenster");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("Service.Models.Entity.Subject", b =>
                {
                    b.Property<int>("SubjectID");

                    b.Property<string>("Code");

                    b.Property<int>("Credit");

                    b.Property<string>("Name");

                    b.Property<int>("RecomendedSemester");

                    b.Property<string>("ResponsibleProfessor");

                    b.HasKey("SubjectID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Service.Models.Entity.Course", b =>
                {
                    b.HasOne("Service.Models.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Service.Models.Entity.StudentSubject", b =>
                {
                    b.HasOne("Service.Models.Entity.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Service.Models.Entity.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}