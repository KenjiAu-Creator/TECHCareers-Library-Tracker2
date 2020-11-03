﻿using Microsoft.EntityFrameworkCore;
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
        entity.Property(e => e.Title)
        .HasCharSet("utf8mb4")
        .HasCollation("utf8mb4_general_ci");

        entity.Property(e => e.Author)
        .HasCharSet("utf8mb4")
        .HasCollation("utf8mb4_general_ci");

        // Seed the database with existing data
        /*        entity.HasData(

                );*/

      });
    }
}
