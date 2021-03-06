﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P01_StudentSystem.Data;

namespace P01_StudentSystem.Data.Migrations
{
    [DbContext(typeof(StudentSystemContext))]
    [Migration("20180711123133_AddData")]
    partial class AddData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new { CourseId = 1, Description = "C# Advanced", EndDate = new DateTime(2018, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "C#", Price = 330m, StartDate = new DateTime(2018, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { CourseId = 2, Description = "Java Advanced", EndDate = new DateTime(2018, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Java", Price = 330m, StartDate = new DateTime(2018, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Homework", b =>
                {
                    b.Property<int>("HomeworkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsUnicode(false);

                    b.Property<int>("ContentType");

                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.Property<DateTime>("SubmissionTime");

                    b.HasKey("HomeworkId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("HomeworkSubmissions");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ResourceType");

                    b.Property<string>("Url")
                        .IsUnicode(false);

                    b.HasKey("ResourceId");

                    b.HasIndex("CourseId");

                    b.ToTable("Resources");

                    b.HasData(
                        new { ResourceId = 1, CourseId = 1, Name = "C#", ResourceType = 2, Url = "url" },
                        new { ResourceId = 2, CourseId = 1, Name = "C# Video", ResourceType = 0, Url = "url" }
                    );
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("CHAR(10)")
                        .IsUnicode(false);

                    b.Property<DateTime>("RegisteredOn");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new { StudentId = 1, Birthday = new DateTime(2000, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Pesho", PhoneNumber = "0123456789", RegisteredOn = new DateTime(2018, 7, 11, 15, 31, 31, 974, DateTimeKind.Local) },
                        new { StudentId = 2, Birthday = new DateTime(2000, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Peshka", PhoneNumber = "0123456789", RegisteredOn = new DateTime(2018, 7, 11, 15, 31, 31, 976, DateTimeKind.Local) },
                        new { StudentId = 3, Birthday = new DateTime(1985, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Gosho", PhoneNumber = "0123456789", RegisteredOn = new DateTime(2018, 7, 11, 15, 31, 31, 976, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("CourseId");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new { StudentId = 1, CourseId = 1 },
                        new { StudentId = 2, CourseId = 1 },
                        new { StudentId = 1, CourseId = 2 }
                    );
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Homework", b =>
                {
                    b.HasOne("P01_StudentSystem.Data.Models.Course", "Course")
                        .WithMany("HomeworkSubmissions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("P01_StudentSystem.Data.Models.Student", "Student")
                        .WithMany("HomeworkSubmissions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Resource", b =>
                {
                    b.HasOne("P01_StudentSystem.Data.Models.Course", "Course")
                        .WithMany("Resources")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.StudentCourse", b =>
                {
                    b.HasOne("P01_StudentSystem.Data.Models.Course", "Course")
                        .WithMany("StudentsEnrolled")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("P01_StudentSystem.Data.Models.Student", "Student")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
