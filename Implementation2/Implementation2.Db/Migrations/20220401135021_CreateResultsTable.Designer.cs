﻿// <auto-generated />
using Implementation2.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Implementation2.Db.Migrations
{
    [DbContext(typeof(I2Context))]
    [Migration("20220401135021_CreateResultsTable")]
    partial class CreateResultsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Implementation2.Db.GeneratorResult", b =>
                {
                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.ToTable("GeneratorResult", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("Implementation2.Db.IteratorResult", b =>
                {
                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("IteratorResult", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("Implementation2.Db.ProcResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
