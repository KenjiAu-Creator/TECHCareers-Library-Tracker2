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
    [Key]
    [Column(TypeName = "int(10)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; private set; }

    [Column(TypeName = "varchar(100)")]
    public string Title { get; private set; }

    [Column(TypeName = "date")]
    public DateTime PublicationDate { get; private set; }

    [Column(TypeName = "int(10)")]
    public int AuthorID { get; private set; }

    public Book(int _id, string _title, string _author, DateTime _pubDate, DateTime _checkedOutDate)
    {

      this.ID = _id;
      this.Title = _title;
      this.Author = _author;
      this.PublicationDate = _pubDate;
      this.CheckedOutDate = _checkedOutDate;

      // The due date should be set to 14 days after the checkout.
      this.DueDate = _checkedOutDate.AddDays(14);
    }
  }
}
