using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using LewandowskiProject.Models;
using System.Web.UI.WebControls;

//Admin Page

namespace LewandowskiProject
{
    public partial class AdminPage : System.Web.UI.Page
    {
        //Global Variables
        //Connection String to be used for accessing data from the database
        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private List<int> idList = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //If the page has not post backed yet, then we do the following
            if (!IsPostBack)
            {
                // Default Databinding of the Gridview that displays the pending users
                BindListView();
                // Session variable that stores the list that contains the users ids
                Session["UserIds"] = idList;
            }
        }

        //BindGridView. This method get all the pending users that are currently in the Database and displays them in a gridview
        //It also saves a list of their ID's for use in displaying their information to the admin
        public void BindListView()
        {
            //Create a connection to the database and make a DataTable object
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            DataTable dt = new DataTable();
            //A MySQL query to select basic pending user information. Refer to database of need be
            MySqlCommand cmd = new MySqlCommand("Select FirstName as 'First Name',LastName as 'Last Name',Email as 'Email' From newuser;", con);
            //Create an MySqlAdapter object to run the command query just made and use the adapter to fill the DataTable
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
            myAdapter.Fill(dt);
            //Set the Gridview's DataSource as the DataTable and Databind it to make it visible on the page
            NewUsersGridView.DataSource = dt;
            NewUsersGridView.DataBind();
            //Another Command query to get all the UserID's from the table into a list for use in displaying the view full profile modal
            cmd = new MySqlCommand("Select idnewuser as 'ID' from newuser;", con);
            using (var command = new MySqlCommand(cmd.CommandText, con))
            {
                //Open Connection
                con.Open();
                //Read through the database and collect the userID's
                using (var reader = command.ExecuteReader())
                {
                    var list = new List<int>();
                    while (reader.Read())
                        list.Add(reader.GetInt32(0));
                    idList = list;
                    //Session Variable for the list to persist between postbacks. Whenever the list is updated, save it to a session variable so it
                    //will not be null when trying to use it.
                    Session["UserIds"] = idList;
                }
            }
            //Close Connection
            con.Close();
        }

        //OnClick for View Full Profile button in the gridView, which gets the current row index that the button was clicked in and 
        //gets the appropriate information into the modal for the pending users information.
        protected void BtnViewUserProfile_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;
            //Fill the idList
            idList = (List<int>)Session["UserIds"];
            //set the id from the index in the idlist
            int id = idList[rowindex];
            //Call to method to display the content from the database to the objects in the modal
            get_newuser(idList[rowindex]);
            //Making the modal visible to the user by showing the modal popup extender
            UserModalPopupExtender.Show();//ajax call to show the modal panel
        }

        // On-Click event for the accept button on the modal. This method inserts data into both the MySQL and SQL Server databases. 
        protected void acceptUser_Click(object sender, EventArgs e)
        {
                //Built in application manager that supports the process to add new users and get the userIDs
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //Built in application sign in manager that supports the process to sign in to get the userID
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                //Process of creating a new user by passing the users email and requested passwords
                var user = new ApplicationUser() { UserName = EmailInputLabel.Text, Email = EmailInputLabel.Text };
                //Saving a new user to the SQL Server database
                IdentityResult result = manager.Create(user, passwordHiddenField.Value);
                //Testing to see if the user was successfully added to the SQL Server database
                if (result.Succeeded)
                {
                    //Getting the id that was associated to the pending user    
                    int idnewuser = Convert.ToInt16(userIdHiddenField.Value);
                    //Getting the new id that is associated with the user
                    string userID = user.Id;
                    //Call to the method that adds data to the MySQL database
                    insert_acceptedPerson(userID);
                    //Call to the method that deletes the pending user data from the MySQL database
                    delete_newuser(idnewuser);
                    //Call to the method that clears the objects in the modal
                    clearModalForm();
                    //Call to method that fills the gridview with the pending users in the MySQL database
                    BindListView();
            }
            else
                {
                    //Message Box that tells the user that there was an error.
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error: Please try again.');", true);
                }
        }

        //On-Click event for the delete button in the modal
        protected void denyUser_Click(object sender, EventArgs e)
        {
            //The id that refers to the pending user
            int idnewuser = Convert.ToInt16(userIdHiddenField.Value);
            //Call to the method that deletes the pending user data from the MySQL database
            delete_newuser(idnewuser);
            //Call to method that fills the gridview with pending users in the MySQL database
            BindListView();
        }

        //Method that clears all the objects in the modal
        private void clearModalForm()
        {
            userIdHiddenField.Value = "";
            UserTypeInputLabel.Text = "";
            FirstNameInputLabel.Text = "";
            LastNameInputLabel.Text = "";
            SuffixInputLabel.Text = "";
            TitleInputLabel.Text = "";
            BioInputLabel.Text = "";
            CityInputLabel.Text = "";
            StateInputLabel.Text = "";
            GenderInputLabel.Text = "";
            EmailInputLabel.Text = "";
            passwordHiddenField.Value = "";
        }

        //On-Click event for the close button in the modal. This event hides the popup extender, which changes the visibilty of the modal. 
        protected void CloseButton_Click(object sender, EventArgs e)
        {
            //ajax call to close the panel
            UserModalPopupExtender.Hide();
        }

        //Method that leverages a stored procedures to get data from the MySQL database and then present the data to the objects in the modal
        private void get_newuser(int userId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //Local variables
                string UserType = "";
                string FirstName = "";
                string LastName = "";
                string Suffix = "";
                string Title = "";
                string Bio = "";
                string City = "";
                string State = "";
                string Gender = "";
                string Email = "";
                string userPassword = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_newuser", con))
                {    
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    //For use of Stored Procedures from MySql, use of input and/or output variables are used in order to get the needed information 
                    //from the database

                    //input parameter
                    //Local variables are used to hold the values used in the stored procedures parameters and to input values as well
                    //When using an input variable, the direction is input and it is output when using an output variable


                    //an in parameter

                    cmd.Parameters.AddWithValue("idnewuser", userId);
                    cmd.Parameters["idnewuser"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("UserType", UserType);
                    cmd.Parameters["UserType"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("FirstName", FirstName);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", LastName);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Suffix", Suffix);
                    cmd.Parameters["Suffix"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Title", Title);
                    cmd.Parameters["Title"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Bio", Bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", City);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", State);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Gender", Gender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("userPassword", userPassword);
                    cmd.Parameters["userPassword"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters["Email"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the global variables to the stored proc output variables. 
                    UserType = cmd.Parameters["UserType"].Value.ToString();
                    FirstName = cmd.Parameters["FirstName"].Value.ToString();
                    LastName = cmd.Parameters["LastName"].Value.ToString();
                    Suffix = cmd.Parameters["Suffix"].Value.ToString();
                    Title = cmd.Parameters["Title"].Value.ToString();
                    Bio = cmd.Parameters["Bio"].Value.ToString();
                    City = cmd.Parameters["City"].Value.ToString();
                    State = cmd.Parameters["State"].Value.ToString();
                    Gender = cmd.Parameters["Gender"].Value.ToString();
                    Email = cmd.Parameters["Email"].Value.ToString();
                    userPassword = cmd.Parameters["userPassword"].Value.ToString();

                    //Assigning the global variables to the text field values.
                    userIdHiddenField.Value = userId.ToString();
                    UserTypeInputLabel.Text = UserType;
                    FirstNameInputLabel.Text = FirstName;
                    LastNameInputLabel.Text = LastName;
                    SuffixInputLabel.Text = Suffix;
                    TitleInputLabel.Text = Title;
                    BioInputLabel.Text = Bio;
                    CityInputLabel.Text = City;
                    StateInputLabel.Text = State;
                    GenderInputLabel.Text = Gender;
                    EmailInputLabel.Text = Email;
                    passwordHiddenField.Value = userPassword;
                }
            }
        }

        //Method that leverages a stored procedure to send data to the MySQL database. This sends the data of the user that was accepted by the admin. 
        private void insert_acceptedPerson(string PersonId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //Local variables
                string UserType = UserTypeInputLabel.Text;
                string FirstName = FirstNameInputLabel.Text;
                string LastName = LastNameInputLabel.Text;
                string Suffix = SuffixInputLabel.Text;
                string Title = TitleInputLabel.Text;
                string Bio = BioInputLabel.Text;
                string City = CityInputLabel.Text;
                string State = StateInputLabel.Text;
                string Gender = GenderInputLabel.Text;
                string Email = EmailInputLabel.Text;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert_acceptedPerson", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //For use of Stored Procedures from MySql, use of input and/or output variables are used in order to get the needed information 
                    //from the database

                    //input parameter
                    //Local variables are used to hold the values used in the stored procedures parameters and to input values as well
                    //When using an input variable, the direction is input and it is output when using an output variable


                    //an in parameter

                    cmd.Parameters.AddWithValue("PersonId", PersonId);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

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

                    cmd.Parameters.AddWithValue("Email1", Email);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //Method that leverages a stored procedure to delete a record from the MySQL database
        private void delete_newuser(int idnewuser)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("delete_newuser", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    //For use of Stored Procedures from MySql, use of input and/or output variables are used in order to get the needed information 
                    //from the database

                    //input parameter
                    //Local variables are used to hold the values used in the stored procedures parameters and to input values as well
                    //When using an input variable, the direction is input and it is output when using an output variable

                   
                    //an in parameter

                    cmd.Parameters.AddWithValue("idnewuser", idnewuser);
                    cmd.Parameters["idnewuser"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}