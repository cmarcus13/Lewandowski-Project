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
    public partial class PractitionerPage : System.Web.UI.Page
    {

        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
         //Add the code that gets the "logged in" person ID from the state.
         //Temporarly set the person ID to 1 for testing purposes.
            private int personID = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            get_practitionerInfo();
        }

        protected void PractitionerPersonalInfoSaveButton_Click(object sender, EventArgs e)
        {
            
        }

        private void get_practitionerInfo()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string firstName = "";
                string lastName = "";
                string gender = "";
                string phone1 = "";
                string email1 = "";
                string city = "";
                string state = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionerInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Gender", gender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone1", phone1);
                    cmd.Parameters["Phone1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email1", email1);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", city);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", state);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    firstName = cmd.Parameters["FirstName"].Value.ToString();
                    lastName = cmd.Parameters["LastName"].Value.ToString();
                    gender = cmd.Parameters["Gender"].Value.ToString();
                    phone1 = cmd.Parameters["Phone1"].Value.ToString();
                    email1 = cmd.Parameters["Email1"].Value.ToString();
                    city = cmd.Parameters["City"].Value.ToString();
                    state = cmd.Parameters["State"].Value.ToString();

                    //Assigning the Fields Text or Index to the Local Variables

                    PractitionerFirstName.Text = firstName;//FirstName Textbox
                    PractitionerLastName.Text = lastName;//LastName Textbox

                    if (gender.Equals("Male") || gender.Equals("male") || gender.Equals("MALE") || gender.Equals("M"))
                    {
                        PractitionerGenderRadioButtonList.SelectedIndex = 1;// Select The Index That Corresponds with the Male Button
                    }
                    else if (gender.Equals("Female") || gender.Equals("female") || gender.Equals("FEMALE") || gender.Equals("F"))
                    {
                        PractitionerGenderRadioButtonList.SelectedIndex = 0;//Select The Index That Corresponds with the Female Button
                    }

                    PractitionerPhoneNumber.Text = phone1;
                    PractitionerEmail.Text = email1;
                    PractitionerCity.Text = city;

                    //Logic For Which State Will Be Selected

                    if (state.Equals("Alabama") || state.Equals("AL") || state.Equals("Al"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 0;
                    }
                    else if (state.Equals("Alaska") || state.Equals("AK") || state.Equals("Ak"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 1;
                    }
                    else if (state.Equals("Arizona") || state.Equals("AZ") || state.Equals("Az"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 2;
                    }
                    else if (state.Equals("Arkansas") || state.Equals("AR") || state.Equals("Ar"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 3;
                    }
                    else if (state.Equals("California") || state.Equals("CA") || state.Equals("Ca"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 4;
                    }
                    else if (state.Equals("Colorado") || state.Equals("CO") || state.Equals("Co"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 5;
                    }
                    else if (state.Equals("Connecticut") || state.Equals("CT") || state.Equals("Ct"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 6;
                    }
                    else if (state.Equals("Delaware") || state.Equals("DE") || state.Equals("De"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 7;
                    }
                    else if (state.Equals("District of Columbia") || state.Equals("DC") || state.Equals("Dc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 8;
                    }
                    else if (state.Equals("Florida") || state.Equals("FL") || state.Equals("Fl"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 9;
                    }
                    else if (state.Equals("Georgia") || state.Equals("GA") || state.Equals("Ga"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 10;
                    }
                    else if (state.Equals("Hawaii") || state.Equals("HI") || state.Equals("Hi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 11;
                    }
                    else if (state.Equals("Idaho") || state.Equals("ID") || state.Equals("Id"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 12;
                    }
                    else if (state.Equals("Illinois") || state.Equals("IL") || state.Equals("Il"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 13;
                    }
                    else if (state.Equals("Indiana") || state.Equals("IN") || state.Equals("In"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 15;
                    }
                    else if (state.Equals("Iowa") || state.Equals("IA") || state.Equals("Ia"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 16;
                    }
                    else if (state.Equals("Kansas") || state.Equals("KS") || state.Equals("Ks"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 17;
                    }
                    else if (state.Equals("Kentucky") || state.Equals("KY") || state.Equals("Ky"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 18;
                    }
                    else if (state.Equals("Louisiana") || state.Equals("LA") || state.Equals("La"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 19;
                    }
                    else if (state.Equals("Maine") || state.Equals("ME") || state.Equals("Me"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 20;
                    }
                    else if (state.Equals("Maryland") || state.Equals("MD") || state.Equals("Md"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 21;
                    }
                    else if (state.Equals("Massachusetts") || state.Equals("MA") || state.Equals("Ma"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 22;
                    }
                    else if (state.Equals("Michigan") || state.Equals("MI") || state.Equals("Mi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 23;
                    }
                    else if (state.Equals("Minnesota") || state.Equals("MN") || state.Equals("Mn"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 24;
                    }
                    else if (state.Equals("Mississippi") || state.Equals("MS") || state.Equals("Ms"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 25;
                    }
                    else if (state.Equals("Missouri") || state.Equals("MO") || state.Equals("Mo"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 26;
                    }
                    else if (state.Equals("Montana") || state.Equals("MT") || state.Equals("Mt"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 27;
                    }
                    else if (state.Equals("Nebraska") || state.Equals("NE") || state.Equals("Ne"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 28;
                    }
                    else if (state.Equals("Nevada") || state.Equals("NV") || state.Equals("Nv"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 29;
                    }
                    else if (state.Equals("New Hampshire") || state.Equals("NH") || state.Equals("Nh"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 30;
                    }
                    else if (state.Equals("New Jersey") || state.Equals("NJ") || state.Equals("Nj"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 31;
                    }
                    else if (state.Equals("New Mexico") || state.Equals("NM") || state.Equals("Nm"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 32;
                    }
                    else if (state.Equals("New York") || state.Equals("NY") || state.Equals("Ny"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 33;
                    }
                    else if (state.Equals("North Carolina") || state.Equals("NC") || state.Equals("Nc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 34;
                    }
                    else if (state.Equals("North Dakota") || state.Equals("ND") || state.Equals("Nd"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 35;
                    }
                    else if (state.Equals("Ohio") || state.Equals("OH") || state.Equals("Oh"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 36;
                    }
                    else if (state.Equals("Oklahoma") || state.Equals("OK") || state.Equals("Ok"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 37;
                    }
                    else if (state.Equals("Oregon") || state.Equals("OR") || state.Equals("Or"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 38;
                    }
                    else if (state.Equals("Pennsylvania") || state.Equals("PA") || state.Equals("Pa"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 39;
                    }
                    else if (state.Equals("Puerto Rico") || state.Equals("PR") || state.Equals("Pr"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 40;
                    }
                    else if (state.Equals("Rhode Island") || state.Equals("RI") || state.Equals("Ri"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 41;
                    }
                    else if (state.Equals("South Carolina") || state.Equals("SC") || state.Equals("Sc"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 42;
                    }
                    else if (state.Equals("South Dakota") || state.Equals("SD") || state.Equals("Sd"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 43;
                    }
                    else if (state.Equals("Tennessee") || state.Equals("TN") || state.Equals("Tn"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 44;
                    }
                    else if (state.Equals("Texas") || state.Equals("TX") || state.Equals("Tx"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 45;
                    }
                    else if (state.Equals("Utah") || state.Equals("UT") || state.Equals("Ut"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 46;
                    }
                    else if (state.Equals("Vermont") || state.Equals("VT") || state.Equals("Vt"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 47;
                    }
                    else if (state.Equals("Virginia") || state.Equals("VA") || state.Equals("Va"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 48;
                    }
                    else if (state.Equals("Virgin Islands") || state.Equals("VI") || state.Equals("Vi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 49;
                    }
                    else if (state.Equals("Washington") || state.Equals("WA") || state.Equals("Wa"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 50;
                    }
                    else if (state.Equals("West Virginia") || state.Equals("WV") || state.Equals("Wv"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 51;
                    }
                    else if (state.Equals("Wisconsin") || state.Equals("WI") || state.Equals("Wi"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 52;
                    }
                    else if (state.Equals("Wyoming") || state.Equals("WY") || state.Equals("Wy"))
                    {
                        PractitionerPersonalInformationStateDropDownList.SelectedIndex = 53;
                    }
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

        private void update_practitionerEducation(int educationId, string major, string minor, string institutionName,
                string degreeEarned, string graduationYear, string yearInSchool)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionerEducation", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("educationId", educationId);
                    cmd.Parameters["educationId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("major", major);
                    cmd.Parameters["major"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("minor", minor);
                    cmd.Parameters["minor"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("degreeEarned", degreeEarned);
                    cmd.Parameters["degreeEarned"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("institutionName", institutionName);
                    cmd.Parameters["institutionName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("graduationYear", graduationYear);
                    cmd.Parameters["graduationYear"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("yearInSchool", yearInSchool);
                    cmd.Parameters["yearInSchool"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void update_practitionerProfessions(int professionId, string professionTitle, string specialty,
            string inProfession, string city, string state, string areaOfExpertise, string yearsInProfession, string currentJob)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionerProfessions", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("professionId", professionId);
                    cmd.Parameters["professionId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("professionTitle", professionTitle);
                    cmd.Parameters["professionTitle"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("specialty", specialty);
                    cmd.Parameters["specialty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("inProfession", inProfession);
                    cmd.Parameters["inProfession"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("city", city);
                    cmd.Parameters["city"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("state", state);
                    cmd.Parameters["state"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("areaOfExpertise", areaOfExpertise);
                    cmd.Parameters["areaOfExpertise"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("yearsInProfession", yearsInProfession);
                    cmd.Parameters["yearsInProfession"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        private void update_practitionerProfessionalHealthExperience(int professionalHealthExperienceId,
            string professionalHealthExperienceType, string instituteName, string city, string state,
            string positionTitle, string yearsInExperience, string currentJob, string description)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionerProfessions", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("professionalHealthExperienceId", professionalHealthExperienceId);
                    cmd.Parameters["professionalHealthExperienceId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("professionalHealthExperienceType", professionalHealthExperienceType);
                    cmd.Parameters["professionalHealthExperienceType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("instituteName", instituteName);
                    cmd.Parameters["instituteName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("city", city);
                    cmd.Parameters["city"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("state", state);
                    cmd.Parameters["state"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("positionTitle", positionTitle);
                    cmd.Parameters["positionTitle"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("yearsInExperience", yearsInExperience);
                    cmd.Parameters["yearsInExperience"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("currentJob", currentJob);
                    cmd.Parameters["currentJob"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters["description"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}