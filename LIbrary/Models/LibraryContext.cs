using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Models
{
  public class LibraryContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        string connection =
          "server=localhost;" +
          "port=3306;" +
          "user=root;" +
          "database=mvc_library;";                    // This will create the database using the name defined.
        string version = "10.4.14-MariaDB";           // Database server version (Found on myPHPAdmin)
        optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Book>(entity =>
      {
        string keyName = "FK_" + nameof(Book) + "_" + nameof(Author);
        // Collation text fields
        entity.Property(e => e.Title)
        .HasCharSet("utf8mb4")
        .HasCollation("utf8mb4_general_ci");

        // Index Creation
        entity.HasIndex(e => e.AuthorID)
        .HasName(keyName);

        // FK Creation
        entity.HasOne(thisEntity => thisEntity.Author)
        .WithMany(parent => parent.Books)
        .HasForeignKey(thisEntity => thisEntity.AuthorID)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName(keyName);

        entity.HasData(
          new Book()
          {
            ID = -1,
            Title = "The Cat in the Hat",
            PublicationDate = new DateTime(1957,3,12),
            AuthorID = -5
          },
          new Book()
          {
            ID = -2,
            Title = "Green Eggs and Ham",
            PublicationDate = new DateTime(1960,8,12),
            AuthorID = -5
            },
          new Book()
          {
            ID = -3,
            Title = "Oh, the Places You'll Go!",
            PublicationDate = new DateTime(1990,1,22),
            AuthorID = -5
          }
        );
      });

      modelBuilder.Entity<Author>(entity =>
      {
        // Collation text fields
        entity.Property(e => e.Name)
        .HasCharSet("utf8mb4")
        .HasCollation("utf8mb4_general_ci");

        // Authors have many books
        // Books only have one author
        entity.HasMany(thisEntity => thisEntity.Books)
        .WithOne(parent => parent.Author)
        .OnDelete(DeleteBehavior.Restrict);

        entity.HasData(
          new Author()
          {
            // DateTime gots yyyy-mm-dd
            ID = -1,
            Name = "Mitch Albom",
            BirthDate = new DateTime(1958,6,23),
            DeathDate = null
          },
          new Author()
          {
            ID = -2,
            Name = "Daniel Handler",
            BirthDate = new DateTime(1970,02,28),
            DeathDate = null
          },
          new Author()
          {
            ID = -3,
            Name = "J.R.R. Tolkien",
            BirthDate = new DateTime(1892,1,3),
            DeathDate = new DateTime(1973,9,2)
          },
          new Author()
          {
            ID = -4,
            Name = "George R. R. Martin",
            BirthDate = new DateTime(1948, 9, 20),
            DeathDate = null
          },
          new Author()
          {
            ID = -5,
            Name = "Dr. Seuss",
            BirthDate = new DateTime(1904,3,4),
            DeathDate = new DateTime(1991,9,24)
          }) ;
      });

      modelBuilder.Entity<Borrow>(entity =>
      {
        string keyName = "FK_" + nameof(Borrow) + "_" + nameof(Book);
        // Index Creation
        entity.HasIndex(e => e.BookID)
        .HasName(keyName);

        // FK Creation
        entity.HasOne(thisEntity => thisEntity.Book)
        .WithOne(parent => parent.Borrow)
        .HasForeignKey<Borrow>(thisEntity => thisEntity.BookID)
        .OnDelete(DeleteBehavior.NoAction)
        .HasConstraintName(keyName);
      });
    }
  }
}
