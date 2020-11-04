using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

    public IActionResult Create()
    {
      return View();
    }

    public static void ExtendDueDateForBorrowByID(int _id)
    {
      // This method will extend the DueDate on the borrow table for a given ID.
    }

    public static void ReturnBorrowByID(int _id)
    {
      // This method will return the book on the borrow table for a given ID.
    }

    public static void CreateBorrow(int _bookID)
    {
      // This method will create a new Borrow entity.
    }

  }
}
