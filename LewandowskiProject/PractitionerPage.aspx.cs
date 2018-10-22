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
        private int personID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the code that gets the "logged in" person ID from the state.
            //Temporarly set the person ID to 1 for testing purposes.
            personID = 1;
        }

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

                    cmd.Parameters.AddWithValue("FirstName", MySqlDbType.VarChar);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", MySqlDbType.VarChar);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Bio", MySqlDbType.VarChar);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Gender", MySqlDbType.VarChar);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone1", MySqlDbType.VarChar);
                    cmd.Parameters["Phone1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone2", MySqlDbType.VarChar);
                    cmd.Parameters["Phone2"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone3", MySqlDbType.VarChar);
                    cmd.Parameters["Phone3"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email1", MySqlDbType.VarChar);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email2", MySqlDbType.VarChar);
                    cmd.Parameters["Email2"].Direction = ParameterDirection.Output;

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