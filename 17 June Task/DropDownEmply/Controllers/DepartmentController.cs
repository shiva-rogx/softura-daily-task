using DropDownEmply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownEmply.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            DepartmentModel dm = new DepartmentModel();
            dm.Departments = dm.PopulateDepartments();
            return View(dm);
        }
        [HttpPost]
        public ActionResult Index(DepartmentModel department, string action)
        {

            department.Departments = department.PopulateDepartments();
            var selectedItem = department.PopulateDepartments().Find(p => p.Value == department.DepartmentID.ToString());
            if (selectedItem != null && action == "Submit")
            {
                department.dt = department.DisplayEmployees(Convert.ToInt32(selectedItem.Value));
            }
            return View(department);
        }
    }
}