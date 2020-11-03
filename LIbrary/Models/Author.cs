using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Models
{
  [Table("author")]
  public class Author
  {
    public Author()
    {
      Books = new HashSet<Book>();
    }

    [Key]
    [Column(TypeName = "int(10)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime DeathDate { get; set; }

    // Create virtual property for linking the foreign key. Link the Inverse property to each other.
    [InverseProperty(nameof(Models.Book.Author))]
    public virtual ICollection<Book> Books { get; set; }
  }
}
