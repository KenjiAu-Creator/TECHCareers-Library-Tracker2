using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LIbrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.Controllers
{
  public class BookController : Controller
  {
    public static List<Book> Books = new List<Book>();

    public IActionResult Index()
    {
      return RedirectToAction("List");
    }

    // The GET parameters name must match the variables names exactly.
    public IActionResult Create(int id, string title, string author, string pub_date)
    {
      if ((title != null && author != null) && pub_date != null)
      {
        // Year-month-date
        // 2020-11-04
        DateTime pubDate = DateTime.Parse(pub_date);
        CreateBook(id, title, author, pubDate, DateTime.Now);
        return RedirectToAction("Index");
      }
      return View();
    }

    public IActionResult List()
    {
      // Testing add new book.
      DateTime _a = new DateTime(2020, 5, 1);
      DateTime _b = new DateTime(2020, 6, 1);
      Book testBook = new Book(1, "Hoopers", "Daniel Ross", _a, _b);

      Books.Add(testBook);
      ViewBag.Books = Books;
      return View();
    }

    public IActionResult Details()
    {
      return View();
    }
    
    // Methods
    public static void CreateBook(int _id, string _title, string _author, DateTime _pubDate, DateTime _checkedOutDate)
    {
      // This method will create a Book object and add it to the Books list.
      Book newBook = new Book(_id, _title, _author, _pubDate, _checkedOutDate);
      Books.Add(newBook);
    }

    public static Book GetBookByID(int _id)
    {
      // This method will return a Book object with the given ID from the Books list.
      return Books.Where(x => x.ID == _id).SingleOrDefault();
    }

    public static void ExtendDueDateForBookByID()
    {
      // This method will extend the given book with the IDs due date by 7 days.
    }

    public static void ReturnBookByID()
    {
      // This method will set the ReturnedDate of the Book object with the given ID to the current date.
    }
    public static void DeleteBookByID(int _id)
    {
      // This method will remove the Book object with the given ID from the Books list.
      Books.Remove(GetBookByID(_id));
    }
  }
}
