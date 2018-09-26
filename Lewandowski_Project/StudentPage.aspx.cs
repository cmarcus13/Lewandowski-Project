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
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();

            users.Add(new Users("Dr. Paul, 312-123-4569, University of Chicago - 1995, Radiology, paul@uchicago.com, Radiology Informatics"));
            users.Add(new Users("Dr. John, 312-645-4645, Northwestern - 1960, Cardiology, john@northwestern.com,Heart Research"));
            users.Add(new Users("Dr. Susan, 216-789-1234, Ohio State - 1940, Oncology, susan@ostate.com, Cancer"));


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