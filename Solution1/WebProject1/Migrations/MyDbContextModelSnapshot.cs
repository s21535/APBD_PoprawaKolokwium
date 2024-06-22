﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProject1;

#nullable disable

namespace WebProject1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebProject1.Models.Access", b =>
                {
                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdProject", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("Accesses");
                });

            modelBuilder.Entity("WebProject1.Models.Project", b =>
                {
                    b.Property<int>("IdProject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProject"));

                    b.Property<int>("IdDefaultAssignee")
                        .HasColumnType("int");

                    b.Property<int>("IdDefaultAssigneeNaivgationIdUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProject");

                    b.HasIndex("IdDefaultAssigneeNaivgationIdUser");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WebProject1.Models.Task", b =>
                {
                    b.Property<int>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTask"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAssignee")
                        .HasColumnType("int");

                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.Property<int>("IdReporter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTask");

                    b.HasIndex("IdAssignee");

                    b.HasIndex("IdProject");

                    b.HasIndex("IdReporter");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WebProject1.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebProject1.Models.Access", b =>
                {
                    b.HasOne("WebProject1.Models.Project", "IdProjectNavigation")
                        .WithMany("Accesses")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebProject1.Models.User", "IdUserNavigation")
                        .WithMany("Accesses")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("IdProjectNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("WebProject1.Models.Project", b =>
                {
                    b.HasOne("WebProject1.Models.User", "IdDefaultAssigneeNaivgation")
                        .WithMany()
                        .HasForeignKey("IdDefaultAssigneeNaivgationIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdDefaultAssigneeNaivgation");
                });

            modelBuilder.Entity("WebProject1.Models.Task", b =>
                {
                    b.HasOne("WebProject1.Models.User", "IdAssigneeNavigation")
                        .WithMany("AssignedTasks")
                        .HasForeignKey("IdAssignee")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebProject1.Models.Project", "IdProjectNavigation")
                        .WithMany("Tasks")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebProject1.Models.User", "IdReporterNavigation")
                        .WithMany("ReportedTasks")
                        .HasForeignKey("IdReporter")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("IdAssigneeNavigation");

                    b.Navigation("IdProjectNavigation");

                    b.Navigation("IdReporterNavigation");
                });

            modelBuilder.Entity("WebProject1.Models.Project", b =>
                {
                    b.Navigation("Accesses");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("WebProject1.Models.User", b =>
                {
                    b.Navigation("Accesses");

                    b.Navigation("AssignedTasks");

                    b.Navigation("ReportedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
