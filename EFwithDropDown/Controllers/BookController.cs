using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFwithDropDown.Models;

namespace EFwithDropDown.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (DbBooksEntities bentity = new DbBooksEntities())
            {
                var dataEF = new SelectList(bentity.tbl_Books.ToList(), "BookId", "Title");
                ViewData["BokEF"] = dataEF;
            }
            

            return View();
        }
    }
}