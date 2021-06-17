using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmplDropDown.Models
{
    public class employee
    {
        public int EmpId { get; set; }
        public string  Department { get; set; }
        public string FName{ get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public List<employee> usersinfo { get; set; }


    }
}