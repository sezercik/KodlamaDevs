﻿// <auto-generated />
using Kodlama.io.Devs.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.PLTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgrammingLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("PLTechnologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Greate technology for Java",
                            ImageUrl = "",
                            Name = "Spring",
                            ProgrammingLanguageId = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "From META to Javascript",
                            ImageUrl = "",
                            Name = "React",
                            ProgrammingLanguageId = 3
                        },
                        new
                        {
                            Id = 3,
                            Description = "Google's answer for React",
                            ImageUrl = "",
                            Name = "Angular",
                            ProgrammingLanguageId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Amazing C# Tecnlogy",
                            ImageUrl = "",
                            Name = ".NET",
                            ProgrammingLanguageId = 1
                        });
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "JAVA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "JavaScript"
                        });
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.PLTechnology", b =>
                {
                    b.HasOne("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("PLTechnologies")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("Kodlama.io.Devs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("PLTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
