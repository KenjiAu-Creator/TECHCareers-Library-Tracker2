using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Models
{
  public class Book
  {
    public int ID { get; private set; }
    public string Title { get; private set; }

    public DateTime PublicationDate { get; private set; }
    public DateTime CheckedOutDate { get; private set; }

    public DateTime DueDate { get; set; }

    public DateTime ReturnedDate { get; set; }
    public string Author { get; private set; }

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
