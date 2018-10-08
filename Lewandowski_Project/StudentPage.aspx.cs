using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lewandowski_Project.Account
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        

        public class Users
        {
            public String UserName { get; set; }
            public Users(string name)
            {
                UserName = name;
            }
        }
    }
}