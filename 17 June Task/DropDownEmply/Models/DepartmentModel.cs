using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DropDownEmply.Models
{
    public class DepartmentModel
    {
        readonly SqlConnection conn;
        private SqlCommand cmd;
        public DepartmentModel()
        {
            conn = new SqlConnection(@"data source=LAPTOP-8J9PFGLH;Integrated Security=true;database=AdventureWorks2017;");
            cmd = new SqlCommand();
        }
        public List<SelectListItem> Departments { get; set; }
        public int? DepartmentID { get; set; }
        public DataTable Dt { get; set; }


        public List<SelectListItem> PopulateDepartments()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string query = "select DepartmentID,Name from HumanResources.Department";
            using (cmd = new SqlCommand(query))
            {
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        items.Add(new SelectListItem
                        {
                            Text = sdr["Name"].ToString(),
                            Value = sdr["DepartmentID"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return items;
        }
        public DataTable DisplayEmployees(int DeptID)
        {
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select e.BusinessEntityID,p.FirstName,e.BirthDate,e.MaritalStatus,e.Gender,e.HireDate " +
                            "from HumanResources.EmployeeDepartmentHistory dh join HumanResources.Department d on d.DepartmentID = dh.DepartmentID " +
                            "join HumanResources.Employee e on e.BusinessEntityID = dh.BusinessEntityID " +
                            "join Person.Person p on p.BusinessEntityID = e.BusinessEntityID where d.DepartmentID =" + DeptID;
            DataTable data = new DataTable();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            conn.Close();
            return data;
        }
    }
}