﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using zadaniya.Data;

#nullable disable

namespace zadaniya.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220927185816_initials1")]
    partial class initials1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("zadaniya.Entites.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PesonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pet1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pet1Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pet2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pet2Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pet3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pet3Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });
#pragma warning restore 612, 618
        }
    }
}