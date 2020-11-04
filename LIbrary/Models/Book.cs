using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Models
{
  [Table("book")]
  public class Book
  {
    public Book()
    {
      Borrows = new HashSet<Borrow>();
    }

    [Key]
    [Column(TypeName = "int(10)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Column(TypeName = "varchar(100)")]
    public string Title { get; set; }

    [Column(TypeName = "date")]
    public DateTime PublicationDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime CheckedOutDate { get; set; }

    [Column(TypeName = "int(10)")]
    public int AuthorID { get; set; }

    // Create the foreign key link to Author
    // Point the Inverse property at each other.
    [ForeignKey(nameof(AuthorID))]
    [InverseProperty(nameof(Models.Author.Books))]
    public virtual Author Author { get; set; }

    // Point Inverse property to Borrow.
    // One Book Title can have zero to many borrows associated with it.
    [InverseProperty(nameof(Models.Borrow.Book))]
    public virtual ICollection<Borrow> Borrows { get; set; }
  }
}
