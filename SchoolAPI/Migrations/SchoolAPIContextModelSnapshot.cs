﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolAPI.Data;

namespace SchoolAPI.Migrations
{
    [DbContext(typeof(SchoolAPIContext))]
    partial class SchoolAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SchoolAPI.Models.AssignedCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("courseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("courseID")
                        .HasColumnType("int");

                    b.Property<int>("teacherID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("courseID");

                    b.HasIndex("teacherID");

                    b.ToTable("AssignedCourses");
                });

            modelBuilder.Entity("SchoolAPI.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchoolAPI.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AssignedCourseId")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedCourseId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolAPI.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolAPI.Models.AssignedCourse", b =>
                {
                    b.HasOne("SchoolAPI.Models.Course", "course")
                        .WithMany()
                        .HasForeignKey("courseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Models.Teacher", "teacher")
                        .WithMany()
                        .HasForeignKey("teacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("SchoolAPI.Models.Student", b =>
                {
                    b.HasOne("SchoolAPI.Models.AssignedCourse", null)
                        .WithMany("student")
                        .HasForeignKey("AssignedCourseId");
                });

            modelBuilder.Entity("SchoolAPI.Models.AssignedCourse", b =>
                {
                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
