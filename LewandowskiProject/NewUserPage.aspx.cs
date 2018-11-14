using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace LewandowskiProject
{
    public partial class NewUserPage : System.Web.UI.Page
    {

        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string temp = User.Identity.GetUserId();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('user id "+temp+"');", true);


            string UserType = userTypeRadioButtonList.SelectedItem.ToString();
            string FirstName = firstNameTextBox.Text;
            string LastName = lastNameTextBox.Text;
            string Suffix = suffixTextBox.Text;
            string Title = titleTextBox.Text;
            string Bio = bioTextArea.Text;
            string City = cityTextBox.Text;
            string State = stateDropDownList.SelectedItem.ToString();
            string Gender = genderRadioButtonList.SelectedItem.ToString();
            string Email = emailTextBox.Text;
            string userPassword = confirmPasswordTextBox.Text;

            insert_newuser(UserType,FirstName,LastName,Suffix,Title,Bio,City,State,Gender,Email,userPassword);
            clearForm();
            
           
        }

        private void insert_newuser(string UserType, string FirstName, string LastName, string Suffix, string Title, string Bio, string City, string State, string Gender, string Email, string userPassword)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert_newuser", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("UserType", UserType);
                    cmd.Parameters["UserType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("FirstName", FirstName);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("LastName", LastName);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Suffix", Suffix);
                    cmd.Parameters["Suffix"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Title", Title);
                    cmd.Parameters["Title"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Bio", Bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("City", City);
                    cmd.Parameters["City"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("State", State);
                    cmd.Parameters["State"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Gender", Gender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters["Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("userPassword", userPassword);
                    cmd.Parameters["userPassword"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void clearForm()
        {
            userTypeRadioButtonList.SelectedIndex = 0;
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            suffixTextBox.Text = "";
            titleTextBox.Text = "";
            bioTextArea.Text = "";
            cityTextBox.Text = "";
            stateDropDownList.SelectedIndex = 0;
            genderRadioButtonList.SelectedIndex = 0;
            emailTextBox.Text = "";
            confirmPasswordTextBox.Text = "";
        }

    }
}