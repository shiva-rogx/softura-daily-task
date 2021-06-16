using MVCWithADOProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithADOProject.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook();
            return View("Home", dt);
        }
        public ActionResult Insert()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View("Create", dt);
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                string AuthorName = frm["txtAuthorName"];
                double Price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.NewBook(Title, AuthorName, Price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int BookId)
        {
            CRUDModel mdl = new CRUDModel();
            int rowIns = mdl.DeleteBook(BookId);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateRecord(int BookId)
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook(BookId);
            return View("Edit", dt);
        }
        public ActionResult Update(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                int AuthorId = Convert.ToInt32(frm["txtAuthorId"]);
                double Price = Convert.ToDouble(frm["txtPrice"]);
                int BookId = Convert.ToInt32(frm["txtBookId"]);
                int uprow = mdl.UpdateBook(BookId, Title, AuthorId, Price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Authors()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View(dt);
        }
        public ActionResult InsertAuthor()
        {
            return View("CreateAuthor");
        }
        public ActionResult InsertAuthorRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Name = frm["txtName"];
                int rowIns = mdl.NewAuthor(Name);
                return RedirectToAction("Authors");
            }
            else
            {
                return RedirectToAction("Authors");
            }
        }
    }
}