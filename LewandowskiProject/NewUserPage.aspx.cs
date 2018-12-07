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
using System.Text.RegularExpressions;

namespace LewandowskiProject
{
    public partial class NewUserPage : System.Web.UI.Page
    {
        // Variable holding the connection string to the database
        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // On Click Method for submit button
        protected void submitButton_Click(object sender, EventArgs e)
        {
            // Save all data from the form in local variables to be inputed into the database
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

            // If statement to check whether the users entered password matches the password criteria of a letter, capital letter, number, special symbol
            //and is between 6 and 20 characters long
            if (validatePassword(userPassword) == true)
            {
                // Call to insert_newuser with the saved form data, clear the form fields, and displays a message thanking the user for registering
                insert_newuser(UserType, FirstName, LastName, Suffix, Title, Bio, City, State, Gender, Email, userPassword);
                clearForm();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Thank you for requesting access.')", true);
            }
            else
            {
                // Display a message for the user that the entered password did not meet password criteria
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Check password requirements.')", true);
            }
        }

        // This method uses a regular expression to validate that the users entered password matches the databases password criteria
        private Boolean validatePassword(string password)
        {
            // Regular expression saying that the string entered should contain a letter, capital letter, number, special symbol and is between 6 and 20 characters long
            string regex = @"(?=.*\d)(?=.*[\W])(?=.*[A-Z])(?=.*[a-z]).{6,20}";

            // Default boolean result to false
            Boolean result = false;

            // If the users entered password meets the password criteria then the result is true, if not then the result is false 
            if (Regex.IsMatch(password, regex))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            // Return the result
            return result;
        }

        // Stored Procedure to inserting the new user information into the database for the admin to use.
        private void insert_newuser(string UserType, string FirstName, string LastName, string Suffix, string Title, string Bio, string City, string State, string Gender, string Email, string userPassword)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert_newuser", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Input parameters

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

                    // After getting all the fields, execeute the query to insert them into the newuser table in the database
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Clears the form data and resets it to its default state
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
            passwordTextBox.Text = "";
            confirmPasswordTextBox.Text = "";
        }

    }
}