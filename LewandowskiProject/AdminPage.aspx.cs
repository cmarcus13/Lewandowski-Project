using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LewandowskiProject
{
    public partial class AdminPage : System.Web.UI.Page
    {

        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private int personID = 4;
        private List<int> idList = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the code that gets the "logged in" person ID from the state.
            if (!IsPostBack)
            {
                personID = 4;
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
            con.Close();
            cmd = new MySqlCommand("Select idnewuser as 'ID' from newuser;", con);
            using (var command = new MySqlCommand(cmd.CommandText, con))
            {
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    var list = new List<int>();
                    while (reader.Read())
                        list.Add(personID = reader.GetInt32(0));
                    idList = list;
                }
            }
        }

        protected void BtnViewUserProfile_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;

            get_newuser(rowindex);
            UserModalPopupExtender.Show();//ajax call to show the modal panel
        }

        protected void newUsersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            //update_studentInfo(firstNameStudent, lastNameStudent, yearInSchoolStudent, graduationYearStudent, bio, majorStudent, minorStudent);
            mpe.Hide();//ajax call to close the panel
        }

        private void get_newuser(int rowIndex)
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

                    int userId = 0;
                    idList = (List<int>)Session["userIds"];

                    userId = idList[rowIndex];

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

                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters["Email"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("userPassword", userPassword);
                    cmd.Parameters["userPassword"].Direction = ParameterDirection.Output;

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
                    PasswordLabel.Text = userPassword;
                }
            }
        }
    }
}