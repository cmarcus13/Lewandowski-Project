using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LewandowskiProject
{
    public partial class StudentPage : System.Web.UI.Page
    {
        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private int personID = 2;
        private List<int> idList = new List<int>();
        private string firstNameStudent;
        private string firstNamePractitioner;
        private string lastNameStudent;
        private string lastNamePractitioner;
        private string graduationYearStudent;
        private string graduationYearPractitioner;
        private string bio;
        private string majorStudent;
        private string majorPractitioner;
        private string minorStudent;
        private string minorPractitioner;
        private string gender;
        private string phone1;
        private string email1;
        private string professionalHealthExperienceType;
        private string instituteName;
        private string city;
        private string state;
        private string areaOfExpertise;
        private string positionTitle;
        private string yearsInExperience;
        private string description;
        private string currentJob;
        private string degreeEarned;
        private string yearInSchoolStudent;
        private string yearInSchoolPractitioner;
        private string professionTitle;
        private string specialty;
        private string inProfession;
        private string yearsInProfession;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the code that gets the "logged in" person ID from the state.
            if (!IsPostBack)
            {
                personID = 2;
                get_studentInfo();
                update_studentInfo(firstNameStudent, lastNameStudent, yearInSchoolStudent, graduationYearStudent, bio, majorStudent, minorStudent);
                BindListView();
                Session["PersonIds"] = idList;
            }
        }

        public void BindListView()
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.personId = contacts.personId and people.userType = 'practitioner' ", con);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
            myAdapter.Fill(dt);
            PractitionerGridView.DataSource = dt;

            PractitionerGridView.DataBind();

            cmd = new MySqlCommand("Select people.PersonID as 'Person ID' from people where  people.userType = 'practitioner'", con);
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
            con.Close();
        }

        protected void ClientButton_Click(object sender, EventArgs e)
        {
            mpe.Show();//ajax call to show the modal panel
        }

        protected void BtnViewPractitionerProfile_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;

            get_practitionerInfo(rowindex);
            PractitionerGridView_ModalPopupExtender.Show();//ajax call to show the modal panel
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            //update_studentInfo(firstNameStudent, lastNameStudent, yearInSchoolStudent, graduationYearStudent, bio, majorStudent, minorStudent);
            mpe.Hide();//ajax call to close the panel
        }

        protected void PractitionerCloseButton_Click(object sender, EventArgs e)
        {
            PractitionerGridView_ModalPopupExtender.Hide();//ajax call to close the panel
        }

        //Storage Procedure to gather the student information for the edit information modal.
        private void get_studentInfo()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_studentInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("FirstName", firstNameStudent);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", lastNameStudent);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("BioResearchInterst", bio);
                    cmd.Parameters["BioResearchInterst"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearInSchool", yearInSchoolStudent);
                    cmd.Parameters["YearInSchool"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("GraduationYear", graduationYearStudent);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Major", majorStudent);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Minor", minorStudent);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the global variables to the stored proc output variables. 
                    firstNameStudent = cmd.Parameters["FirstName"].Value.ToString();
                    lastNameStudent = cmd.Parameters["LastName"].Value.ToString();
                    yearInSchoolStudent = cmd.Parameters["YearInSchool"].Value.ToString();
                    graduationYearStudent = cmd.Parameters["GraduationYear"].Value.ToString();
                    bio = cmd.Parameters["BioResearchInterst"].Value.ToString();
                    majorStudent = cmd.Parameters["Major"].Value.ToString();
                    minorStudent = cmd.Parameters["Minor"].Value.ToString();

                    //Assigning the global variables to the text field values.
                    FNameTextBox.Text = firstNameStudent;
                    LNameTextBox.Text = lastNameStudent;

                    if (yearInSchoolStudent.Equals("freshman") || yearInSchoolStudent.Equals("Freshman") || yearInSchoolStudent.Equals("FRESHMAN") || yearInSchoolStudent.Equals("FR") || yearInSchoolStudent.Equals("Fr"))
                    {
                        YearDropDownList.SelectedIndex = 1;
                    }
                    else if (yearInSchoolStudent.Equals("sophomore") || yearInSchoolStudent.Equals("Sophomore") || yearInSchoolStudent.Equals("SOPHOMORE") || yearInSchoolStudent.Equals("SO") || yearInSchoolStudent.Equals("So"))
                    {
                        YearDropDownList.SelectedIndex = 2;
                    }
                    else if (yearInSchoolStudent.Equals("junior") || yearInSchoolStudent.Equals("Junior") || yearInSchoolStudent.Equals("JUNIOR") || yearInSchoolStudent.Equals("JR") || yearInSchoolStudent.Equals("Jr"))
                    {
                        YearDropDownList.SelectedIndex = 3;
                    }
                    else if (yearInSchoolStudent.Equals("senior") || yearInSchoolStudent.Equals("Senior") || yearInSchoolStudent.Equals("SENIOR") || yearInSchoolStudent.Equals("SR") || yearInSchoolStudent.Equals("Sr"))
                    {
                        YearDropDownList.SelectedIndex = 4;
                    }

                    GraduationYearTextbox.Text = graduationYearStudent;
                    MajorTextBox.Text = majorStudent;
                    MinorTextBox.Text = minorStudent;
                    BioTextArea.Text = bio;
                }
            }
        }

        //Storage Procedure to update the student information in the edit modal.
        private void update_studentInfo(string firstName, string lastName, string yearInSchool, string graduationYear, string bio, string major, string minor)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_studentInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("YearInSchool", yearInSchoolStudent);
                    cmd.Parameters["YearInSchool"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("GraduationYear", graduationYearStudent);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Bio", bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Major", major);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Minor", minor);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //Storage Procedure to update the student information in the edit modal.
        private void update_studentInfo(string firstName, string lastName, string bio, string major, string minor)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_studentInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Bio", bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Major", major);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Minor", minor);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //Storage Procedure to get the practitioner information.
        private void get_practitionerInfo(int rowIndex)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionerInfo", con))
                {
                    string practitionerFirst = "", practitionerLast = "", practitionerGender = "",
                        practitionerPhone = "", practitionerEmail = "", practitionerCity = "",
                        practitionerState = "";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    int personId = 0;
                    idList = (List<int>)Session["PersonIds"];

                    personId = idList[rowIndex];

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personId);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("FirstName", practitionerFirst);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", practitionerLast);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Gender", practitionerGender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone1", practitionerPhone);
                    cmd.Parameters["Phone1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email1", PractitionerEmail);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", practitionerCity);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", practitionerState);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    practitionerFirst = cmd.Parameters["FirstName"].Value.ToString();
                    practitionerLast = cmd.Parameters["LastName"].Value.ToString();
                    practitionerGender = cmd.Parameters["Gender"].Value.ToString();
                    practitionerPhone = cmd.Parameters["Phone1"].Value.ToString();
                    practitionerEmail = cmd.Parameters["Email1"].Value.ToString();
                    practitionerCity = cmd.Parameters["City"].Value.ToString();
                    practitionerState = cmd.Parameters["State"].Value.ToString();


                    PractitionerFirstName.Text = practitionerFirst;
                    PractitionerLastName.Text = practitionerLast;
                    PractitionerGender.Text = practitionerGender;
                    PractitionerPhoneNumber.Text = practitionerPhone;
                    PractitionerEmail.Text = practitionerEmail;
                    PractitionerCity.Text = practitionerCity;
                    PractitionerState.Text = practitionerState;
                }
            }
        }

        private void get_practitionersProfessonalHealthExperiences()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessonalHealthExperiences", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceType", MySqlDbType.VarChar);
                    cmd.Parameters["ProfessionalHealthExperienceType"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("InstituteName", MySqlDbType.VarChar);
                    cmd.Parameters["InstituteName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", MySqlDbType.VarChar);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", MySqlDbType.VarChar);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", MySqlDbType.VarChar);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("PositionTitle", MySqlDbType.VarChar);
                    cmd.Parameters["PositionTitle"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearsInExperience", MySqlDbType.VarChar);
                    cmd.Parameters["YearsInExperience"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Description", MySqlDbType.VarChar);
                    cmd.Parameters["Description"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("CurrentJob", MySqlDbType.VarChar);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void get_practitionersContactsEducationsGendersAndPeople()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersContactsEducationsGendersAndPeople", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("GraduationYear", MySqlDbType.VarChar);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("InstituteName", MySqlDbType.VarChar);
                    cmd.Parameters["InstituteName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Major", MySqlDbType.VarChar);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Minor", MySqlDbType.VarChar);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("DegreeEarned", MySqlDbType.VarChar);
                    cmd.Parameters["DegreeEarned"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearInSchool", MySqlDbType.VarChar);
                    cmd.Parameters["YearInSchool"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void get_practitionersProfessions()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersContactsEducationsGendersAndPeople", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //output parameters

                    cmd.Parameters.AddWithValue("professionTitle", MySqlDbType.VarChar);
                    cmd.Parameters["professionTitle"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("specialty", MySqlDbType.VarChar);
                    cmd.Parameters["specialty"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("inProfession", MySqlDbType.VarChar);
                    cmd.Parameters["inProfession"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("city", MySqlDbType.VarChar);
                    cmd.Parameters["city"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("state", MySqlDbType.VarChar);
                    cmd.Parameters["state"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("yearsInProfession", MySqlDbType.VarChar);
                    cmd.Parameters["yearsInProfession"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("currentJob", MySqlDbType.VarChar);
                    cmd.Parameters["currentJob"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        protected void PractitionerGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}