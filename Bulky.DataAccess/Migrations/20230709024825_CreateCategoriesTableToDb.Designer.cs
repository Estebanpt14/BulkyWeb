﻿// <auto-generated />
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
  [DbContext(typeof(ApplicationDbContext))]
  [Migration("20230709024825_CreateCategoriesTableToDb")]
  partial class CreateCategoriesTableToDb
  {
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
          .HasAnnotation("Relational:MaxIdentifierLength", 63);

      NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

      modelBuilder.Entity("BulkyWeb.Models.Category", b =>
          {
            b.Property<int>("CategoryId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer");

            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

            b.Property<int>("DisplayOrder")
                      .HasColumnType("integer");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("text");

            b.HasKey("CategoryId");

            b.ToTable("Categories");
          });
#pragma warning restore 612, 618
    }
  }
}