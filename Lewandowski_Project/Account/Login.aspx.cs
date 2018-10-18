using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Lewandowski_Project.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Lewandowski_Project.Account
{
    public partial class Login : Page
    {
        string dbConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LogIn(object sender, EventArgs e)
        {
            this.Master.FindControl("studentPage").Visible = true;
            this.Master.FindControl("practitionerPage").Visible = true;
            this.Master.FindControl("adminPage").Visible = true;

            validateLogIn(Email.Text, Password.Text);
        }

        protected void validateLogIn(string emailInput, string passwordInput)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("login_procedure", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("users_UserName", emailInput);
                    cmd.Parameters["users_UserName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("users_Password", passwordInput);
                    cmd.Parameters["users_Password"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("users_PersonId", MySqlDbType.Int32);
                    cmd.Parameters["users_PersonId"].Direction = ParameterDirection.Output;


                    Email.Text =  cmd.ExecuteNonQuery().ToString();

                   
                }
            }
        }
    }
}