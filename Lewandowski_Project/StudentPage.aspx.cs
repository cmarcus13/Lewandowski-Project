using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lewandowski_Project.Account
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        string dbConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void updateStudentRecord(string FirstName, string LastName, string BioResearchInterest, string Minor, string Major, string YearInSchool)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_studentRecord", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //InOut Parameters Into The Stored Proceedure

                    cmd.Parameters.AddWithValue("people_FirstName", FirstName);
                    cmd.Parameters["people_FirstName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("people_LastName", LastName);
                    cmd.Parameters["people_LastName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("people_BioResearchInterest", Minor);
                    cmd.Parameters["educations_Minor"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("educations_Major", Major);
                    cmd.Parameters["educations_Minor"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("educations_Minor", Minor);
                    cmd.Parameters["educations_Minor"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("educations_YearInSchool", YearInSchool);
                    cmd.Parameters["educations_YearInSchool"].Direction = ParameterDirection.Input;

                    //Out Parameters Into The TextBoxes

                    cmd.Parameters.AddWithValue("people_FirstName", MySqlDbType.VarChar);
                    cmd.Parameters["people_FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("people_LastName", MySqlDbType.VarChar);
                    cmd.Parameters["people_LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("people_BioResearchInterest", MySqlDbType.VarChar);
                    cmd.Parameters["people_BioResearchInterest"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("educations_Major", MySqlDbType.VarChar);
                    cmd.Parameters["educations_Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("educations_Minor", MySqlDbType.VarChar);
                    cmd.Parameters["educations_Minor"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("educations_YearInSchool", MySqlDbType.VarChar);
                    cmd.Parameters["educations_YearInSchool"].Direction = ParameterDirection.Output;

                    FullName.Text = cmd.ExecuteNonQuery().ToString();

                    BioResearchInterestTextBox.Text = cmd.ExecuteNonQuery().ToString();

                    SchoolYear.SelectedValue = cmd.ExecuteNonQuery().ToString();

                    Majors.Text = cmd.ExecuteNonQuery().ToString();

                    Minors.Text = cmd.ExecuteNonQuery().ToString();
                }
            }
        }

        protected void getPractitionersContactsEducationsGenders(string FirstName, string LastName, string Profession, string City, string State)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessions", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Out Parameters Into The TextBoxes

                    cmd.Parameters.AddWithValue("people_FirstName", MySqlDbType.VarChar);
                    cmd.Parameters["people_FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("people_LastName", MySqlDbType.VarChar);
                    cmd.Parameters["people_LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("people_City", MySqlDbType.VarChar);
                    cmd.Parameters["people_City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("people_State", MySqlDbType.VarChar);
                    cmd.Parameters["educations_Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Professions_ProfessionTitle", MySqlDbType.VarChar);
                    cmd.Parameters["Professions_ProfessionTitle"].Direction = ParameterDirection.Output;

                    //alumniTable.Rows.FirstName + LastName = cmd.ExecuteNonQuery().ToString();

                    //alumniTable.Rows.City = cmd.ExecuteNonQuery().ToString();

                    //alumniTable.Rows.State = cmd.ExecuteNonQuery().ToString();

                    //alumniTable.Rows.Profession = cmd.ExecuteNonQuery().ToString();

                }
            }
        }

    }
}
     
