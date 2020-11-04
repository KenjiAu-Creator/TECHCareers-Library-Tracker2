using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LIbrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace LIbrary.Controllers
{
  public class BookController : Controller
  {
    public IActionResult Index()
    {
      return RedirectToAction("List");
    }

    // The GET parameters name must match the variables names exactly.
    public IActionResult Create(int id, string title, string author, string pub_date)
    {
      ViewBag.Authors = AuthorsController.GetAuthors();
        return View();
    }

    public IActionResult List()
    {
      ViewBag.Overdue = GetOverdueBooks();
      return View();
    }

    public IActionResult Details(int id)
    {
      return View();
    }
    
    // Methods
    public static void CreateBook( string _title, int _authorID, DateTime _pubDate)
    {
      // This method will create a Book object and add it to the Books list.
      using (LibraryContext context = new LibraryContext())
      {
        context.Books.Add(new Book()
        {
          Title = _title,
          PublicationDate = _pubDate,
          AuthorID = _authorID
        });
        Book newBook = context.Books.Last();
        BorrowController.CreateBorrow(newBook.ID);
        context.SaveChanges();
      }
      
    }

    public static List<Book> GetBooks()
    {
      // This method will return a list of Book objects in the database.
      using (LibraryContext context = new LibraryContext())
      {
        return context.Books.ToList();
      }
    }

    public static void ExtendDueDateForBookByID(int _id)
    {
      // This method will extend the given book with the IDs due date by 7 days.
      BorrowController.ExtendDueDateForBorrowByID(_id);
      
    }

    public static void ReturnBookByID(int _id)
    {
      // This method will set the ReturnedDate of the Book object with the given ID to the current date.
      BorrowController.ReturnBorrowByID(_id);
      
    }
    public static void DeleteBookByID(int _id)
    {
      // This method will remove the Book object with the given ID from the Books list.
      using (LibraryContext context = new LibraryContext())
      {
        context.Books.Remove(GetBookByID(_id));
      }
    }
    public static Book GetBookByID(int _id)
    {
      // This method will return a specific book with the given ID.
      using (LibraryContext context = new LibraryContext())
      {
        return context.Books.Where(x => x.ID == _id).SingleOrDefault();
      }
    }
    public static List<Book> GetOverdueBooks()
    {
      // This method will get a list of all books that have a duedate prior to the current date.
      using (LibraryContext context = new LibraryContext())
      {
        // Stuck on this SQL Statement.

        // Collection of Books overdue
        // Grab their BookID
        // Compare to collection of Books ID
        /*context.Books.Where(x => x.ID == context.Borrows.Where(z=>z.BookID == context.Borrows.Where(y => y.DueDate < DateTime.Today)));*/
        return context.Books.Where(x => x.Borrows.Any(y => y.DueDate < DateTime.Today)).ToList();
      }
    }
  }
}
