﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAPI.Migration;

#nullable disable

namespace MoviesAPI.Migrations
{
    [DbContext(typeof(ApplicationData))]
    [Migration("20231107101538_AddedIsDeletedColumn")]
    partial class AddedIsDeletedColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoviesAPI.Model.Genre", b =>
                {
                    b.Property<long>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GenreId"));

                    b.Property<long?>("MoviesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.HasIndex("MoviesId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MoviesAPI.Model.Movies", b =>
                {
                    b.Property<long>("MoviesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MoviesId"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("MoviesId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesAPI.Model.Genre", b =>
                {
                    b.HasOne("MoviesAPI.Model.Movies", "Movies")
                        .WithMany("TheGenre")
                        .HasForeignKey("MoviesId");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MoviesAPI.Model.Movies", b =>
                {
                    b.Navigation("TheGenre");
                });
#pragma warning restore 612, 618
        }
    }
}
