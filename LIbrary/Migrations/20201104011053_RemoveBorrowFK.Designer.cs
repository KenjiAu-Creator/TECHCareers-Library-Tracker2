﻿// <auto-generated />
using System;
using LIbrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LIbrary.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20201104011053_RemoveBorrowFK")]
    partial class RemoveBorrowFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LIbrary.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(60)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("author");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            BirthDate = new DateTime(1958, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mitch Albom"
                        },
                        new
                        {
                            ID = -2,
                            BirthDate = new DateTime(1970, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Daniel Handler"
                        },
                        new
                        {
                            ID = -3,
                            BirthDate = new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(1973, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "J.R.R. Tolkien"
                        },
                        new
                        {
                            ID = -4,
                            BirthDate = new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "George R. R. Martin"
                        },
                        new
                        {
                            ID = -5,
                            BirthDate = new DateTime(1904, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(1991, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dr. Seuss"
                        });
                });

            modelBuilder.Entity("LIbrary.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID")
                        .HasName("FK_Book_Author");

                    b.ToTable("book");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            AuthorID = -5,
                            PublicationDate = new DateTime(1957, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Cat in the Hat"
                        },
                        new
                        {
                            ID = -2,
                            AuthorID = -5,
                            PublicationDate = new DateTime(1960, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Green Eggs and Ham"
                        },
                        new
                        {
                            ID = -3,
                            AuthorID = -5,
                            PublicationDate = new DateTime(1990, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Oh, the Places You'll Go!"
                        });
                });

            modelBuilder.Entity("LIbrary.Models.Borrow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<int>("BookID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("CheckedOutDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.ToTable("borrow");
                });

            modelBuilder.Entity("LIbrary.Models.Book", b =>
                {
                    b.HasOne("LIbrary.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .HasConstraintName("FK_Book_Author")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("LIbrary.Models.Borrow", b =>
                {
                    b.HasOne("LIbrary.Models.Book", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
