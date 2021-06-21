using Dapper;
using MoviesDaapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesDaapper.Controllers
{
    public class MovieController : Controller
    {
        public ActionResult Index()
        {
            List<MovieModel> MVlist = new List<MovieModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                MVlist = dbcon.Query<MovieModel>("select * from tbl_movies").ToList();
            }
            return View(MVlist);
        }
        public ActionResult Details(int id)
        {
            MovieModel moviedetails = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                moviedetails = dbcon.Query<MovieModel>("select * from tbl_movies where Movie_Id =" + id, new { id }).SingleOrDefault();
            }
            return View(moviedetails);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MovieModel mv)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))

            {

                string sqlQuery = "insert Into tbl_movies (Movie_Id,Movie_Name) "
                    + "Values('" + mv.Movie_Id + "'," + mv.Movie_Name + " )";

                int rowsAffected = dbcon.Execute(sqlQuery);
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            MovieModel mv = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                mv = dbcon.Query<MovieModel>("select * from tbl_movies where Movie_Id =" + id, new { id }).SingleOrDefault();
            }

            return View(mv);
        }
        [HttpPost]
        public ActionResult Edit(MovieModel mv)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                string sqlQuery = "update tbl_movies set Movie_Name='" + mv.Movie_Name + "',Movie_Id=" + mv.Movie_Id + "where Movie_Id=" + mv.Movie_Id;

                int rowsAffected = dbcon.Execute(sqlQuery);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            MovieModel moviedetails = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
            {
                moviedetails = dbcon.Query<MovieModel>("select * from tbl_movies where Movie_Id =" + id, new { id }).SingleOrDefault();
            }
            return View(moviedetails);
        }
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
        using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MVConStr"].ConnectionString))
        {
            string sqlQuery = "delete from tbl_movies where Movie_Id = " + id;

            int rowsAffected = dbcon.Execute(sqlQuery);
        }
        return RedirectToAction("Index");
    }
}
}

