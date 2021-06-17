using EmplDropDown.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmplDropDown.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            employee objuser = new employee();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-8J9PFGLH;Integrated Security=true;Initial Catalog=DbEmpl"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from employee", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    List<employee> employee = new List<employee>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        employee uobj = new employee();
                        uobj.EmpId= Convert.ToInt32(ds.Tables[0].Rows[i]["EmpId"].ToString());
                        uobj.Department = ds.Tables[0].Rows[i]["Department"].ToString();
                        uobj.FName = ds.Tables[0].Rows[i]["FName"].ToString();
                        uobj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                        uobj.MaritalStatus = ds.Tables[0].Rows[i]["MaritalStatus"].ToString();
                        employee.Add(uobj);
                    }
                    objuser.usersinfo = employee;
                }
                con.Close();
            }
            return View(objuser);
        }
    }
}