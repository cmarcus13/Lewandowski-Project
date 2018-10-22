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

        }

        private void get_practitionersEducations()
        {

        }

        private void get_practitionersProfessionalHealthExperiences()
        {

        }

        private void get_practitionersProfessions()
        {

        }

        private void update_practitionerEducation()
        {

        }

        private void update_practitionerProfession()
        {

        }

        private void update_practitionerProfessionalHealthExperience()
        {

        }
    }
}