using LIbrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Controllers
{
  public class BorrowController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Create(int bookID)
    {
      CreateBorrow(bookID);
      // Code snippet for getting the proper parameters to be passed into the redirect.
      // https://www.codegrepper.com/code-examples/csharp/asp.net+core+redirecttoaction+with+parameters
      // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.redirecttoaction?view=aspnetcore-3.1
      return RedirectToAction("Details", "Book", new { id = bookID });
    }

    public IActionResult ExtendDueDate(int id)
    {
      ExtendDueDateForBorrowByID(id);
      int bookID;
      using (LibraryContext context = new LibraryContext())
      {
        bookID = context.Borrows.Where(x => x.ID == id).SingleOrDefault().BookID;
      }
      return RedirectToAction("Details", "Book", new { id = bookID });
    }
    public IActionResult Return(int id)
    {
      int bookID;
      ReturnBorrowByID(id);
      using (LibraryContext context = new LibraryContext())
      {
        bookID = context.Borrows.Where(x => x.ID == id).SingleOrDefault().BookID;
      }
      return RedirectToAction("Details", "Book", new { id = bookID });
    }

    public static void ExtendDueDateForBorrowByID(int _id)
    {
      // This method will extend the DueDate on the borrow table for a given ID.
      Debug.WriteLine(_id);
      using (LibraryContext context = new LibraryContext())
      {
        Borrow borrowedBook = context.Borrows.Where(x => x.ID == _id).SingleOrDefault();
        borrowedBook.DueDate.AddDays(7);
      }

    }

    public static void ReturnBorrowByID(int _id)
    {
      // This method will return the book on the borrow table for a given ID.
      using( LibraryContext context = new LibraryContext())
      {
        Borrow borrowedBook = context.Borrows.Where(x => x.ID == _id).SingleOrDefault();
        borrowedBook.ReturnedDate = DateTime.Today;
      }
    }

    public static void CreateBorrow(int _bookID)
    {
      // This method will create a new Borrow entity.
      DateTime _checkOut = DateTime.Today;
      Borrow newBorrow = new Borrow()
      {
        CheckedOutDate = _checkOut,
        DueDate = _checkOut.AddDays(14),
        ReturnedDate = null,
        BookID = _bookID
      };

      using (LibraryContext context = new LibraryContext())
      {
        context.Add(newBorrow);
        context.SaveChanges();
      }
    }
  }
}
