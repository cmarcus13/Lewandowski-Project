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
    public partial class StudentPage : System.Web.UI.Page
    {
        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private int personID = 1;
        private string firstNameStudent = "";
        private string firstNamePractitioner = "";
        private string lastNameStudent = "";
        private string lastNamePractitioner = "";
        private string graduationYearStudent = "";
        private string graduationYearPractitioner = "";
        private string bio = "";
        private string majorStudent = "";
        private string majorPractitioner = "";
        private string minorStudent = "";
        private string minorPractitioner = "";
        private string gender = "";
        private string phone1 = "";
        private string email1 = "";
        private string professionalHealthExperienceType = "";
        private string instituteName = "";
        private string city = "";
        private string state = "";
        private string areaOfExpertise = "";
        private string positionTitle = "";
        private string yearsInExperience = "";
        private string description = "";
        private string currentJob = "";
        private string degreeEarned = "";
        private string yearInSchoolStudent = "";
        private string yearInSchoolPractitioner = "";
        private string professionTitle = "";
        private string specialty = "";
        private string inProfession = "";
        private string yearsInProfession = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the code that gets the "logged in" person ID from the state.
            //Temporarly set the person ID to 1 for testing purposes.
            personID = 1;            
        }

        protected void ClientButton_Click(object sender, EventArgs e)
        {            
            get_studentInfo();
            mpe.Show();//ajax call to show the modal panel
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            update_studentInfo(firstNameStudent, lastNameStudent, yearInSchoolStudent, graduationYearStudent, bio, majorStudent, minorStudent);
            mpe.Hide();//ajax call to close the panel
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

        //Storage Procedure to get the practitioner information.
        private void get_practitionerInfo()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionerInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("FirstName", firstNamePractitioner);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", lastNamePractitioner);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Bio", bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Gender", gender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone1", phone1);
                    cmd.Parameters["Phone1"].Direction = ParameterDirection.Output;
                    
                    cmd.Parameters.AddWithValue("Email1", email1);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

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

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceType", professionalHealthExperienceType);
                    cmd.Parameters["ProfessionalHealthExperienceType"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("InstituteName", instituteName);
                    cmd.Parameters["InstituteName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", city);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", state);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", areaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("PositionTitle", positionTitle);
                    cmd.Parameters["PositionTitle"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearsInExperience", yearsInExperience);
                    cmd.Parameters["YearsInExperience"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Description", description);
                    cmd.Parameters["Description"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("CurrentJob", currentJob);
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

                    cmd.Parameters.AddWithValue("GraduationYear", graduationYearPractitioner);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("InstituteName", instituteName);
                    cmd.Parameters["InstituteName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Major", majorPractitioner);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Minor", minorPractitioner);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("DegreeEarned", degreeEarned);
                    cmd.Parameters["DegreeEarned"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearInSchool", yearInSchoolPractitioner);
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

                    cmd.Parameters.AddWithValue("professionTitle", professionTitle);
                    cmd.Parameters["professionTitle"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("specialty", specialty);
                    cmd.Parameters["specialty"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("inProfession", inProfession);
                    cmd.Parameters["inProfession"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("city", city);
                    cmd.Parameters["city"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("state", state);
                    cmd.Parameters["state"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("yearsInProfession", yearsInProfession);
                    cmd.Parameters["yearsInProfession"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("currentJob", currentJob);
                    cmd.Parameters["currentJob"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}