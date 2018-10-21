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
        private int personID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the code that gets the "logged in" person ID from the state.
            //Temporarly set the person ID to 1 for testing purposes.
            personID = 1;
        }

        private void fillStudentInfo()
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

                    cmd.Parameters.AddWithValue("FirstName", MySqlDbType.VarChar);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", MySqlDbType.VarChar);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("BioResearchInterst", MySqlDbType.VarChar);
                    cmd.Parameters["BioResearchInterst"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("GraduationYear", MySqlDbType.VarChar);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Major", MySqlDbType.VarChar);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Minor", MySqlDbType.VarChar);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}