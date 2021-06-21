using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MVCwithDapper.Models;
using System.Configuration;
using System.Data;
using Dapper;

namespace MVCwithDapper.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> BKlist = new List<BookModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                BKlist = dbcon.Query<BookModel>("select * from tbl_Books").ToList();
            }
                return View(BKlist);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            BookModel bookdetails = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bookdetails = dbcon.Query<BookModel>("select * from tbl_Books where BookId =" + id, new { id }).SingleOrDefault();
            }
            return View(bookdetails);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookModel bk)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))

            {

                string sqlQuery = "insert Into tbl_Books (Title,AuthorId,Price) " 
                    +"Values('" +bk.Title + "'," + bk.AuthorId+ "," + bk.Price + ")";

                int rowsAffected = dbcon.Execute(sqlQuery); 
            }

            return RedirectToAction("Index");
        }
        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            BookModel bk= new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("select * from tbl_Books where BookId =" + id, new { id }).SingleOrDefault();
            }

                return View(bk);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookModel bk)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string sqlQuery = "update tbl_Books set Title='" + bk.Title + "',AuthorId=" + bk.AuthorId + ",Price=" + bk.Price + "where BookId=" + bk.BookId;

                int rowsAffected = dbcon.Execute(sqlQuery);
            }
            return RedirectToAction("Index");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            BookModel bk = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bk = dbcon.Query<BookModel>("select * from tbl_Books where BookId =" + id, new { id }).SingleOrDefault();
            }

            return View(bk);
        }


        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using(IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string sqlQuery = "delete from tbl_Books where BookId = " + id;

                int rowsAffected = dbcon.Execute(sqlQuery);
            }
            return RedirectToAction("Index");
        }
    }
    }

