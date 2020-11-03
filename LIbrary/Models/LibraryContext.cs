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
      // Since the Shelf model has a Name property which is a string (text) we need to apply Collation.
      modelBuilder.Entity<Book>(entity =>
      {
        string keyName = "FK_" + nameof(Book) + "_" + nameof(Author);
        // Collation text fields
        entity.Property(e => e.Title)
        .HasCharSet("utf8mb4")
        .HasCollation("utf8mb4_general_ci");

        // Index Creation
        entity.HasIndex(e=> e.AuthorID)
        .HasName(keyName);

        // FK Creation
        entity.HasOne(thisEntity => thisEntity.Author)
        .WithMany(parent => parent.Books)
        .HasForeignKey(thisEntity => thisEntity.AuthorID)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName(keyName);

      });

      modelBuilder.Entity<Author>(entity =>
      {
        // Collation text fields
        entity.Property(e => e.Name)
        .HasCharSet("utf8mb4")
        .HasCollation("utf8mb4_general_ci");

        entity.OwnsMany(thisEntity => thisEntity.Books)
        .OnDelete(DeleteBehavior.Restrict);
      });

      modelBuilder.Entity<Borrow>(entity =>
      {
        string keyName = "FK_" + nameof(Borrow) + "_" + nameof(Book);
        // Index Creation
        entity.HasIndex(e => e.BookID)
        .HasName(keyName);

        // FK Creation
        entity.HasOne(thisEntity => thisEntity.Book)
        .WithMany(parent => parent.Borrows)
        .HasForeignKey(thisEntity => thisEntity.BookID)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName(keyName);
      });
    }
}
