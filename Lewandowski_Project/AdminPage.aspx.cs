using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lewandowski_Project
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();

            users.Add(new Users("John Doe, jDoe@gmail.com, 216-397-1886"));
            users.Add(new Users("Jane Smith, jSmith@gmail.com, 216-397-1886"));

            usersListView.DataSource = users;

            usersListView.DataBind();

        }

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