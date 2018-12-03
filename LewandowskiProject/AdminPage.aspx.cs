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


namespace LewandowskiProject
{
    public partial class AdminPage : System.Web.UI.Page
    {

        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private List<int> idList = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the code that gets the "logged in" person ID from the state.
            if (!IsPostBack)
            {
                BindListView();
                Session["UserIds"] = idList;
            }
        }

        public void BindListView()
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("Select FirstName as 'First Name',LastName as 'Last Name',Email as 'Email' From newuser;", con);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
            myAdapter.Fill(dt);
            NewUsersGridView.DataSource = dt;
            NewUsersGridView.DataBind();
            cmd = new MySqlCommand("Select idnewuser as 'ID' from newuser;", con);
            using (var command = new MySqlCommand(cmd.CommandText, con))
            {
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    var list = new List<int>();
                    while (reader.Read())
                        list.Add(reader.GetInt32(0));
                    idList = list;
                    Session["UserIds"] = idList;
                }
            }

            con.Close();
        }

        protected void BtnViewUserProfile_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;
            idList = (List<int>)Session["UserIds"];
            int id = idList[rowindex];
            get_newuser(idList[rowindex]);
            UserModalPopupExtender.Show();//ajax call to show the modal panel
        }

        protected void acceptUser_Click(object sender, EventArgs e)
        {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = EmailLabel.Text, Email = EmailLabel.Text };
                IdentityResult result = manager.Create(user, passwordHiddenField.Value);
                if (result.Succeeded)
                {
                    int idnewuser = Convert.ToInt16(userIdHiddenField.Value);
                    string userID = user.Id;
                    insert_acceptedPerson(userID);
                    delete_newuser(idnewuser);
                    clearModalForm();
                    BindListView();
            }
            else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error: Please try again.');", true);
                }
        }

        protected void denyUser_Click(object sender, EventArgs e)
        {
            int idnewuser = Convert.ToInt16(userIdHiddenField.Value);
            delete_newuser(idnewuser);
            BindListView();
        }

        private void clearModalForm()
        {
            userIdHiddenField.Value = "";
            UserTypeLabel.Text = "";
            FirstNameLabel.Text = "";
            LastNameLabel.Text = "";
            SuffixLabel.Text = "";
            TitleLabel.Text = "";
            BioLabel.Text = "";
            CityLabel.Text = "";
            StateLabel.Text = "";
            GenderLabel.Text = "";
            EmailLabel.Text = "";
            passwordHiddenField.Value = "";
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            //update_studentInfo(firstNameStudent, lastNameStudent, yearInSchoolStudent, graduationYearStudent, bio, majorStudent, minorStudent);
            mpe.Hide();//ajax call to close the panel
        }

        private void get_newuser(int userId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
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
                    UserTypeLabel.Text = UserType;
                    FirstNameLabel.Text = FirstName;
                    LastNameLabel.Text = LastName;
                    SuffixLabel.Text = Suffix;
                    TitleLabel.Text = Title;
                    BioLabel.Text = Bio;
                    CityLabel.Text = City;
                    StateLabel.Text = State;
                    GenderLabel.Text = Gender;
                    EmailLabel.Text = Email;
                    passwordHiddenField.Value = userPassword;
                }
            }
        }

        private void insert_acceptedPerson(string PersonId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                string UserType = UserTypeLabel.Text;
                string FirstName = FirstNameLabel.Text;
                string LastName = LastNameLabel.Text;
                string Suffix = SuffixLabel.Text;
                string Title = TitleLabel.Text;
                string Bio = BioLabel.Text;
                string City = CityLabel.Text;
                string State = StateLabel.Text;
                string Gender = GenderLabel.Text;
                string Email = EmailLabel.Text;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert_acceptedPerson", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

        private void delete_newuser(int idnewuser)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("delete_newuser", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("idnewuser", idnewuser);
                    cmd.Parameters["idnewuser"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}