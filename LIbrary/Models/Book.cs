using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Models
{
  public class Book
  {
    public int ID { get; set; }
    public string Title { get; set; }

    public DateTime PublicationDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime ReturnedDate { get; set; }
    public string Author { get; set; }

    public Book(int _id, string _title, string _author, DateTime _pubDate, DateTime _checkedOutDate)
    {

      this.ID = _id;
      this.Title = _title;
      this.Author = _author;
      this.PublicationDate = _pubDate;

      // The due date should be set to 14 days after the checkout.
      this.DueDate = _checkedOutDate;
    }
  }
}
