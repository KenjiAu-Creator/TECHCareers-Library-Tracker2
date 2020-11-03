using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LIbrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

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
      return View();
    }

    public IActionResult List()
    {
      return View();
    }

    public IActionResult Details(int id)
    {
      return View();
    }
    
    // Methods
    public static void CreateBook(int _id, string _title, string _author, DateTime _pubDate, DateTime _checkedOutDate)
    {
      // This method will create a Book object and add it to the Books list.
      
    }

    public static Book GetBookByID(int _id)
    {
      // This method will return a Book object with the given ID from the Books list.
      return Books.Where(x => x.ID == _id).SingleOrDefault();
    }

    public static void ExtendDueDateForBookByID(int _id)
    {
      // This method will extend the given book with the IDs due date by 7 days.
      
    }

    public static void ReturnBookByID(int _id)
    {
      // This method will set the ReturnedDate of the Book object with the given ID to the current date.
      
    }
    public static void DeleteBookByID(int _id)
    {
      // This method will remove the Book object with the given ID from the Books list.
     
    }
  }
}
