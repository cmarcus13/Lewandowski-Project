using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace LewandowskiProject
{
    public partial class SiteMaster : MasterPage
    {
        //Connection String for the MySQL Database
        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                //Session variable to hold the Person ID
                Session["PersonID"] = Context.User.Identity.GetUserId();
                //Initially making all the pages invisible
                StudentPage.Visible = false;
                PractitionerPage.Visible = false;
                AdminPage.Visible = false;

                //Testing to see if a user is logged in by using Identity's feature of getting the user id. If it is blank, the user is not logged in
                if (Context.User.Identity.GetUserId() != "")
                {
                    //Getting the user type by calling the get_userType method
                    string userType = get_userType(Context.User.Identity.GetUserId());
                    if (userType == "Admin")
                    {
                        AdminPage.Visible = true;
                    }
                    else if (userType == "Student")
                    {
                        StudentPage.Visible = true;
                    }
                    else if (userType == "Practitioner")
                    {
                        PractitionerPage.Visible = true;
                    }
                }
        }

        //Method to get the user type for a particular user
        private string get_userType(string PersonId)
        {
            //Local variable
            string UserType = "";

            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_userType", con))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //input variable

                    cmd.Parameters.AddWithValue("PersonId", PersonId);
                    cmd.Parameters["PersonId"].Direction = System.Data.ParameterDirection.Input;

                    //output variable

                    cmd.Parameters.AddWithValue("UserType", UserType);
                    cmd.Parameters["UserType"].Direction = System.Data.ParameterDirection.Output;

                    cmd.ExecuteScalar();
                    
                    //setting the local variable to the result of the query
                    UserType = cmd.Parameters["UserType"].Value.ToString();
                }
            }
            //Return the UserType
            return UserType;
        }


        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}