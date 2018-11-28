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
        //Temporarly set the person ID to 4 for testing purposes.
        private string personID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                personID = Session["PersonId"].ToString();
                get_practitionerInfo();
                get_practitionersEducations();
                get_practitionersProfessionalHealthExperiences();
                get_practitionersProfessions();
                get_practitionersBio();
            }
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
                int acceptsStudents = 0;

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

                    cmd.Parameters.AddWithValue("AcceptsStudents", acceptsStudents);
                    cmd.Parameters["AcceptsStudents"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    firstName = cmd.Parameters["FirstName"].Value.ToString();
                    lastName = cmd.Parameters["LastName"].Value.ToString();
                    gender = cmd.Parameters["Gender"].Value.ToString();
                    phone1 = cmd.Parameters["Phone1"].Value.ToString();
                    email1 = cmd.Parameters["Email1"].Value.ToString();
                    city = cmd.Parameters["City"].Value.ToString();
                    state = cmd.Parameters["State"].Value.ToString();
                    try
                    {
                        acceptsStudents = Convert.ToInt16(cmd.Parameters["AcceptsStudents"].Value);
                    }
                    catch
                    {
                        acceptsStudents = -1;
                    }
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

                    PractitionerPersonalInformationStateDropDownList.SelectedIndex = getStateIndex(state);

                    if (acceptsStudents == 0)
                    {
                        AcceptingStudentsRadioButton.SelectedIndex = 0;
                    }
                    else if (acceptsStudents == 1)
                    {
                        AcceptingStudentsRadioButton.SelectedIndex = 1;
                    }
                    else
                    {
                        AcceptingStudentsRadioButton.SelectedIndex = -1;
                    }
                }
            }
        }

        private void get_practitionersEducations()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables Stored Proc
                string InstitutionName = "";
                string EducationId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersEducations", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        PractitionerAddEducationDropDownList.Visible = true;
                        PractitionerAddEducationDropDownList.Items.Clear();
                        PractitionerEducationAddButton.Visible = false;
                        PractitionerEducationUpdateButton.Visible = true;
                        PractitionerEducationDeleteButton.Visible = true;
                        while (myReader.Read())
                        {
                            InstitutionName = myReader["InstitutionName"].ToString();
                            EducationId = myReader["EducationId"].ToString();
                            PractitionerAddEducationDropDownList.Items.Add(new ListItem(InstitutionName, EducationId));
                        }
                        get_practitionersEducation(Convert.ToInt16(PractitionerAddEducationDropDownList.Items[0].Value));
                    }
                    else
                    {
                        PractitionerAddEducationDropDownList.Visible = false;
                        PractitionerEducationUpdateButton.Visible = false;
                        PractitionerEducationDeleteButton.Visible = false;
                        PractitionerEducationAddButton.Visible = true;
                    }
                }
            }
        }

        protected void PractitionerAddEducationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int EducationId = Convert.ToInt16(PractitionerAddEducationDropDownList.SelectedItem.Value);
            get_practitionersEducation(EducationId);
        }

        private void get_practitionersEducation(int EducationId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string InstitutionName = "";
                string YearInSchool = "";
                string GraduationYear = "";
                string DegreeEarned = "";
                string Major = "";
                string Minor = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersEducation", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("EducationId", EducationId);
                    cmd.Parameters["EducationId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("InstitutionName", InstitutionName);
                    cmd.Parameters["InstitutionName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearInSchool", YearInSchool);
                    cmd.Parameters["YearInSchool"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("GraduationYear", GraduationYear);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("DegreeEarned", DegreeEarned);
                    cmd.Parameters["DegreeEarned"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Major", Major);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Minor", Minor);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    InstitutionName = cmd.Parameters["InstitutionName"].Value.ToString();
                    YearInSchool = cmd.Parameters["YearInSchool"].Value.ToString();
                    GraduationYear = cmd.Parameters["GraduationYear"].Value.ToString();
                    DegreeEarned = cmd.Parameters["DegreeEarned"].Value.ToString();
                    Major = cmd.Parameters["Major"].Value.ToString();
                    Minor = cmd.Parameters["Minor"].Value.ToString();

                    //Assigning the Fields Text or Index to the Local Variables

                    PractitionerEducationSchoolNameText.Text = InstitutionName;
                    PractitionerEducationYearInText.Text = YearInSchool;
                    PractitionerEducationGradYearText.Text = GraduationYear;

                    if (DegreeEarned.Equals("Associates"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 0;
                    }
                    else if (DegreeEarned.Equals("Bachelors"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 1;
                    }
                    else if (DegreeEarned.Equals("Masters"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 2;
                    }
                    else if (DegreeEarned.Equals("Doctorate"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 3;
                    }
                    else if (DegreeEarned.Equals("Medical School"))
                    {
                        PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 4;
                    }

                    PractitionerEducationMajorText.Text = Major;
                    PractitionerEducationMinorText.Text = Minor;
                }
            }
        }

        private void get_practitionersProfessionalHealthExperiences()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables Stored Proc
                string InstituteName = "";
                string PositionTitle = "";
                string ProfessionalHealthExperienceId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessionalHealthExperiences", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        PractitionerAddInternshipsDropDownList.Visible = true;
                        PractitionerAddInternshipsDropDownList.Items.Clear();
                        PractitionerInternshipsAddButton.Visible = false;
                        PractitionerInternshipsUpdateButton.Visible = true;
                        PractitionerInternshipsDeleteButton.Visible = true;
                        while (myReader.Read())
                        {
                            InstituteName = myReader["InstituteName"].ToString();
                            PositionTitle = myReader["PositionTitle"].ToString();
                            ProfessionalHealthExperienceId = myReader["ProfessionalHealthExperienceId"].ToString();
                            PractitionerAddInternshipsDropDownList.Items.Add(new ListItem(InstituteName + " - " + PositionTitle, ProfessionalHealthExperienceId));
                        }
                        get_practitionersProfessionalHealthExperience(Convert.ToInt16(PractitionerAddInternshipsDropDownList.Items[0].Value));
                    }
                    else
                    {
                        PractitionerAddInternshipsDropDownList.Visible = false;
                        PractitionerInternshipsUpdateButton.Visible = false;
                        PractitionerInternshipsDeleteButton.Visible = false;
                        PractitionerInternshipsAddButton.Visible = true;
                    }
                }
            }
        }

        protected void PractitionerAddInternshipsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProfessionalHealthExperienceId = Convert.ToInt16(PractitionerAddInternshipsDropDownList.SelectedItem.Value);
            get_practitionersProfessionalHealthExperience(ProfessionalHealthExperienceId);
        }

        private void get_practitionersProfessionalHealthExperience(int ProfessionalHealthExperienceId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string professionalHealthExperienceType = "";
                string instituteName = "";
                string city = "";
                string state = "";
                string areaOfExpertise = "";
                string positionTitle = "";
                // not using yearsInExperience but keep if we want to later
                string yearsInExperience = "";
                string description = "";
                int currentJob = 0;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessionalHealthExperience", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceId", ProfessionalHealthExperienceId);
                    cmd.Parameters["ProfessionalHealthExperienceId"].Direction = ParameterDirection.Input;

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

                    //Assigning the Parameters to the Local Variables
                    professionalHealthExperienceType = cmd.Parameters["ProfessionalHealthExperienceType"].Value.ToString();
                    instituteName = cmd.Parameters["InstituteName"].Value.ToString();
                    city = cmd.Parameters["City"].Value.ToString();
                    state = cmd.Parameters["State"].Value.ToString();
                    areaOfExpertise = cmd.Parameters["AreaOfExpertise"].Value.ToString();
                    positionTitle = cmd.Parameters["PositionTitle"].Value.ToString();
                    yearsInExperience = cmd.Parameters["YearsInExperience"].Value.ToString();
                    description = cmd.Parameters["Description"].Value.ToString();
                    currentJob = Convert.ToInt16(cmd.Parameters["CurrentJob"].Value);

                    //Assigning the Fields Text or Index to the Local Variables
                    if (professionalHealthExperienceType.Equals("Internship"))
                    {
                        PractitionerInternshipsDropDownList.SelectedIndex = 0;
                    }
                    else if (professionalHealthExperienceType.Equals("Residency"))
                    {
                        PractitionerInternshipsDropDownList.SelectedIndex = 1;
                    }
                    else if (professionalHealthExperienceType.Equals("Fellowship"))
                    {
                        PractitionerInternshipsDropDownList.SelectedIndex = 2;
                    }


                    if (areaOfExpertise.Equals("Dentistry"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 0;
                    }
                    else if (areaOfExpertise.Equals("Surgery"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 1;
                    }
                    else if (areaOfExpertise.Equals("Other"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 2;
                    }


                    PractitionerInternshipsInstituteNameText.Text = instituteName;
                    PractitionerInternshipsInstituteCity.Text = city;

                    //Logic For Which State Will Be Selected

                    PractitionerInternshipsInstituteStateDropDownList.SelectedIndex = getStateIndex(state);


                    //Logic For Which Area of Expertise Will Be Selected

                    if (areaOfExpertise.Equals("Dentistry"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 0;
                    }
                    else if (areaOfExpertise.Equals("Surgery"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 1;
                    }
                    else if (PractitionerInternshipsAreaDropDownList.Equals("Other"))
                    {
                        PractitionerInternshipsAreaDropDownList.SelectedIndex = 2;
                    }

                    PractitionerInternshipNameOrTitle.Text = positionTitle;
                    PractitionerInternshipsTextArea.Text = description;

                    if (currentJob == 0)
                    {
                        PractitionerInternshipsCurrentRadioButtonList.SelectedIndex = 0;
                    }
                    else if (currentJob == 1)
                    {
                        PractitionerInternshipsCurrentRadioButtonList.SelectedIndex = 1;
                    }
                }
            }
        }

        private void get_practitionersProfessions()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables Stored Proc
                string NameOfCompany = "";
                string ProfessionTitle = "";
                string ProfessionId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessions", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //an in parameter

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        PractitionerAddPrfessionDropDownList.Visible = true;
                        PractitionerAddPrfessionDropDownList.Items.Clear();
                        PractitionerProfessionAddButton.Visible = false;
                        PractitionerProfessionUpdateButton.Visible = true;
                        PractitionerProfessionDeleteButton.Visible = true;
                        while (myReader.Read())
                        {
                            NameOfCompany = myReader["NameOfCompany"].ToString();
                            ProfessionTitle = myReader["ProfessionTitle"].ToString();
                            ProfessionId = myReader["ProfessionId"].ToString();
                            PractitionerAddPrfessionDropDownList.Items.Add(new ListItem(NameOfCompany + " - " + ProfessionTitle, ProfessionId));
                        }
                        get_practitionersProfession(Convert.ToInt16(PractitionerAddPrfessionDropDownList.Items[0].Value));
                    }
                    else
                    {
                        PractitionerAddPrfessionDropDownList.Visible = false;
                        PractitionerProfessionUpdateButton.Visible = false;
                        PractitionerProfessionDeleteButton.Visible = false;
                        PractitionerProfessionAddButton.Visible = true;
                    }
                }
            }
        }

        protected void PractitionerAddPrfessionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProfessionId = Convert.ToInt16(PractitionerAddPrfessionDropDownList.SelectedItem.Value);
            get_practitionersProfession(ProfessionId);
        }

        private void get_practitionersProfession(int ProfessionId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string professionTitle = "";
                string specialty = "";
                string nameOfCompany = "";
                string city = "";
                string state = "";
                string yearsInProfession = "";
                string areaOfExpertise = "";
                int currentJob = 0;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfession", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionId", ProfessionId);
                    cmd.Parameters["ProfessionId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("ProfessionTitle", professionTitle);
                    cmd.Parameters["ProfessionTitle"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Specialty", specialty);
                    cmd.Parameters["Specialty"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("NameOfCompany", nameOfCompany);
                    cmd.Parameters["NameOfCompany"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", city);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", state);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("YearsInProfession", yearsInProfession);
                    cmd.Parameters["YearsInProfession"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", areaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("CurrentJob", currentJob);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    professionTitle = cmd.Parameters["ProfessionTitle"].Value.ToString();
                    specialty = cmd.Parameters["Specialty"].Value.ToString();
                    nameOfCompany = cmd.Parameters["NameOfCompany"].Value.ToString();
                    city = cmd.Parameters["City"].Value.ToString();
                    state = cmd.Parameters["State"].Value.ToString();
                    yearsInProfession = cmd.Parameters["YearsInProfession"].Value.ToString();
                    areaOfExpertise = cmd.Parameters["AreaOfExpertise"].Value.ToString();
                    currentJob = Convert.ToInt16(cmd.Parameters["CurrentJob"].Value);

                    //Assigning the Fields Text or Index to the Local Variables
                    PractitionerProfessionNameOrTitle.Text = professionTitle;
                    PractitionerProfessionSpecialty.Text = specialty;
                    PractitionerProfessionLocationText.Text = nameOfCompany;
                    PractitionerProfessionCity.Text = city;

                    //Logic For Which State Will Be Selected


                    PractitionerProfessionStateDropDownList.SelectedIndex = getStateIndex(state);

                    PractitionerYearsInLabelText.Text = yearsInProfession;


                    //Logic For Which Area of Expertise Will Be Selected

                    if (areaOfExpertise.Equals("Dentistry"))
                    {
                        PractitionerProfessionDropDownList.SelectedIndex = 0;
                    }
                    else if (areaOfExpertise.Equals("Surgery"))
                    {
                        PractitionerProfessionDropDownList.SelectedIndex = 1;
                    }
                    else if (areaOfExpertise.Equals("Other"))
                    {
                        PractitionerProfessionDropDownList.SelectedIndex = 2;
                    }

                    if (currentJob == 0)
                    {
                        PractitionerProfessionCurrentRadioButtonList.SelectedIndex = 0;
                    }
                    else if (currentJob == 1)
                    {
                        PractitionerProfessionCurrentRadioButtonList.SelectedIndex = 1;
                    }
                }
            }
        }

        private void get_practitionersBio()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables Stored Proc
                string Bio = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersBio", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("PersonId", personID);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

                    //an out parameter

                    cmd.Parameters.AddWithValue("Bio", Bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    Bio = cmd.Parameters["Bio"].Value.ToString();

                    //Assigning the Fields Text or Index to the Local Variables
                    BioTextArea.Text = Bio;
                }
            }
        }

        //Update Store Procedures
        private void update_practitionerInfo(string PersonId, string FirstName, string LastName, string Gender, string City, string State, string Phone1, string Email, int AcceptsStudents)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionerInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("PersonId", PersonId);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("FirstName", FirstName);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("LastName", LastName);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Gender", Gender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("City", City);
                    cmd.Parameters["City"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("State", State);
                    cmd.Parameters["State"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Phone1", Phone1);
                    cmd.Parameters["Phone1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters["Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("AcceptsStudents", AcceptsStudents);
                    cmd.Parameters["AcceptsStudents"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerPersonalInfoSaveButton_Click(object sender, EventArgs e)
        {
            update_practitionerInfo(personID, PractitionerFirstName.Text, PractitionerLastName.Text, PractitionerGenderRadioButtonList.SelectedItem.ToString(), PractitionerCity.Text, PractitionerPersonalInformationStateDropDownList.SelectedItem.ToString(), PractitionerPhoneNumber.Text, PractitionerEmail.Text, AcceptingStudentsRadioButton.SelectedIndex);
        }

        private void update_practitionerEducation(int EducationId, string InstitutionName, string YearInSchool, string GraduationYear, string DegreeEarned, string Major, string Minor)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionerEducation", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("EducationId", EducationId);
                    cmd.Parameters["EducationId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("InstitutionName", InstitutionName);
                    cmd.Parameters["InstitutionName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("YearInSchool", YearInSchool);
                    cmd.Parameters["YearInSchool"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("GraduationYear", GraduationYear);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("DegreeEarned", DegreeEarned);
                    cmd.Parameters["DegreeEarned"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Major", Major);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Minor", Minor);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerEducationUpdateButton_Click(object sender, EventArgs e)
        {
            update_practitionerEducation(Convert.ToInt16(PractitionerAddEducationDropDownList.SelectedValue), PractitionerEducationSchoolNameText.Text, PractitionerEducationYearInText.Text, PractitionerEducationGradYearText.Text, PractitionerEducationDegreeEarnedDropDownList.SelectedItem.ToString(), PractitionerEducationMajorText.Text, PractitionerEducationMinorText.Text);
            get_practitionersEducations();
        }

        private void update_practitionersProfessionalHealthExperience(int ProfessionalHealthExperienceId, string ProfessionalHealthExperienceType, string InstituteName, string City, string State, string AreaOfExpertise, string PositionTitle, string Description, int CurrentJob)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionersProfessionalHealthExperience", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceId", ProfessionalHealthExperienceId);
                    cmd.Parameters["ProfessionalHealthExperienceId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceType", ProfessionalHealthExperienceType);
                    cmd.Parameters["ProfessionalHealthExperienceType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("InstituteName", InstituteName);
                    cmd.Parameters["InstituteName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("City", City);
                    cmd.Parameters["City"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("State", State);
                    cmd.Parameters["State"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", AreaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("PositionTitle", PositionTitle);
                    cmd.Parameters["PositionTitle"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Description", Description);
                    cmd.Parameters["Description"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("CurrentJob", CurrentJob);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerInternshipsUpdateButton_Click(object sender, EventArgs e)
        {
            int CurrentJob = 0;

            if (PractitionerInternshipsCurrentRadioButtonList.SelectedIndex == 0)
            {
                CurrentJob = 0;
            }
            else if (PractitionerInternshipsCurrentRadioButtonList.SelectedIndex == 1)
            {
                CurrentJob = 1;
            }

            update_practitionersProfessionalHealthExperience(Convert.ToInt16(PractitionerAddInternshipsDropDownList.SelectedValue), PractitionerInternshipsDropDownList.SelectedItem.ToString(), PractitionerInternshipsInstituteNameText.Text, PractitionerInternshipsInstituteCity.Text, PractitionerInternshipsInstituteStateDropDownList.SelectedItem.ToString(), PractitionerInternshipsAreaDropDownList.SelectedItem.ToString(), PractitionerInternshipNameOrTitle.Text, PractitionerInternshipsTextArea.Text, CurrentJob);
            get_practitionersProfessionalHealthExperiences();
        }

        private void update_practitionerProfession(int ProfessionId, string ProfessionTitle, string Specialty, string NameOfCompany, string City, string State, string YearsInProfession, string AreaOfExpertise, int CurrentJob)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionerProfession", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionId", ProfessionId);
                    cmd.Parameters["ProfessionId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("ProfessionTitle", ProfessionTitle);
                    cmd.Parameters["ProfessionTitle"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Specialty", Specialty);
                    cmd.Parameters["Specialty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("NameOfCompany", NameOfCompany);
                    cmd.Parameters["NameOfCompany"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("City", City);
                    cmd.Parameters["City"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("State", State);
                    cmd.Parameters["State"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("YearsInProfession", YearsInProfession);
                    cmd.Parameters["YearsInProfession"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", AreaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("CurrentJob", CurrentJob);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerProfessionUpdateButton_Click(object sender, EventArgs e)
        {
            int CurrentJob = 0;

            if (PractitionerProfessionCurrentRadioButtonList.SelectedIndex == 0)
            {
                CurrentJob = 0;
            }
            else if (PractitionerProfessionCurrentRadioButtonList.SelectedIndex == 1)
            {
                CurrentJob = 1;
            }

            update_practitionerProfession(Convert.ToInt16(PractitionerAddPrfessionDropDownList.SelectedValue), PractitionerProfessionNameOrTitle.Text, PractitionerProfessionSpecialty.Text, PractitionerProfessionLocationText.Text, PractitionerProfessionCity.Text, PractitionerProfessionStateDropDownList.SelectedItem.ToString(), PractitionerYearsInLabelText.Text, PractitionerProfessionDropDownList.SelectedItem.ToString(), CurrentJob);
            get_practitionersProfessions();
        }

        private void update_practitionerBio(string personId, string Bio)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_practitionerBio", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("personId", personId);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Bio", Bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerBioButton_Click(object sender, EventArgs e)
        {
            update_practitionerBio(personID, BioTextArea.Text);
        }


        //Delete Methods

        private void delete_practitionerEducation(int EducationId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("delete_practitionerEducation", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("EducationId", EducationId);
                    cmd.Parameters["EducationId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerEducationDeleteButton_Click(object sender, EventArgs e)
        {
            delete_practitionerEducation(Convert.ToInt16(PractitionerAddEducationDropDownList.SelectedValue));
            clearEducationArea();
            get_practitionersEducations();
        }

        private void clearEducationArea()
        {
            PractitionerAddEducationDropDownList.Visible = false;
            PractitionerEducationSchoolNameText.Text = "";
            PractitionerEducationYearInText.Text = "";
            PractitionerEducationGradYearText.Text = "";
            PractitionerEducationDegreeEarnedDropDownList.SelectedIndex = 0;
            PractitionerEducationMajorText.Text = "";
            PractitionerEducationMinorText.Text = "";
        }

        private void delete_practitionersProfessionalHealthExperience(int ProfessionalHealthExperienceId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("delete_practitionersProfessionalHealthExperience", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceId", ProfessionalHealthExperienceId);
                    cmd.Parameters["ProfessionalHealthExperienceId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerInternshipsDeleteButton_Click(object sender, EventArgs e)
        {
            delete_practitionersProfessionalHealthExperience(Convert.ToInt16(PractitionerAddInternshipsDropDownList.SelectedValue));
            clearPractitionersProfessionalHealthExperienceArea();
            get_practitionersProfessionalHealthExperiences();
        }

        private void clearPractitionersProfessionalHealthExperienceArea()
        {
            PractitionerAddInternshipsDropDownList.Visible = false;
            PractitionerInternshipNameOrTitle.Text = "";
            PractitionerInternshipsAreaDropDownList.SelectedIndex = 0;
            PractitionerInternshipsInstituteNameText.Text = "";
            PractitionerInternshipsInstituteCity.Text = "";
            PractitionerInternshipsInstituteStateDropDownList.SelectedIndex = 0;
            PractitionerInternshipsTextArea.Text = "";
            PractitionerInternshipsCurrentRadioButtonList.SelectedIndex = 0;
        }

        private void delete_practitionersProfession(int ProfessionId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("delete_practitionersProfession", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("ProfessionId", ProfessionId);
                    cmd.Parameters["ProfessionId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerProfessionDeleteButton_Click(object sender, EventArgs e)
        {
            delete_practitionersProfession(Convert.ToInt16(PractitionerAddPrfessionDropDownList.SelectedValue));
            clearPractitionersProfessionArea();
            get_practitionersProfessions();
        }

        private void clearPractitionersProfessionArea()
        {
            PractitionerAddPrfessionDropDownList.Visible = false;
            PractitionerProfessionNameOrTitle.Text = "";
            PractitionerProfessionDropDownList.SelectedIndex = 0;
            PractitionerProfessionLocationText.Text = "";
            PractitionerProfessionCity.Text = "";
            PractitionerProfessionStateDropDownList.SelectedIndex = 0;
            PractitionerProfessionSpecialty.Text = "";
            PractitionerProfessionCurrentRadioButtonList.SelectedIndex = 0;
            PractitionerYearsInLabelText.Text = "";
        }

        //insert methods

        private void insert_practitionersEducation(string PersonId, string InstitutionName, string YearInSchool, string GraduationYear, string DegreeEarned, string Major, string Minor)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert_practitionersEducation", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("PersonId", PersonId);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("InstitutionName", InstitutionName);
                    cmd.Parameters["InstitutionName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("YearInSchool", YearInSchool);
                    cmd.Parameters["YearInSchool"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("GraduationYear", GraduationYear);
                    cmd.Parameters["GraduationYear"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("DegreeEarned", DegreeEarned);
                    cmd.Parameters["DegreeEarned"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Major", Major);
                    cmd.Parameters["Major"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Minor", Minor);
                    cmd.Parameters["Minor"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerEducationAddButton_Click(object sender, EventArgs e)
        {
            string InstitutionName = PractitionerEducationSchoolNameText.Text;
            string YearInSchool = PractitionerEducationYearInText.Text;
            string GraduationYear = PractitionerEducationGradYearText.Text;
            string DegreeEarned = PractitionerEducationDegreeEarnedDropDownList.SelectedItem.ToString();
            string Major = PractitionerEducationMajorText.Text;
            string Minor = PractitionerEducationMinorText.Text;
            if ((InstitutionName != "") && (YearInSchool != "") && (GraduationYear != "") && (DegreeEarned != "") && (Major != "") && (Minor != ""))
            {
                insert_practitionersEducation(personID, InstitutionName, YearInSchool, GraduationYear, DegreeEarned, Major, Minor);
                clearEducationArea();
                get_practitionersEducations();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please ensure all fields are selected or inputed.');", true);
            }
        }

        protected void PractitionerEducationClearButton_Click(object sender, EventArgs e)
        {
            PractitionerEducationAddButton.Visible = true;
            PractitionerEducationUpdateButton.Visible = false;
            PractitionerEducationDeleteButton.Visible = false;
            clearEducationArea();
        }

        private void insert_practitionersProfessionalHealthExperience(string PersonId, string ProfessionalHealthExperienceType, string InstituteName, string City, string State, string AreaOfExpertise, string PositionTitle, string Description, int CurrentJob)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert_practitionersProfessionalHealthExperience", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("PersonId", PersonId);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceType", ProfessionalHealthExperienceType);
                    cmd.Parameters["ProfessionalHealthExperienceType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("InstituteName", InstituteName);
                    cmd.Parameters["InstituteName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("City", City);
                    cmd.Parameters["City"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("State", State);
                    cmd.Parameters["State"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", AreaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("PositionTitle", PositionTitle);
                    cmd.Parameters["PositionTitle"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Description", Description);
                    cmd.Parameters["Description"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("CurrentJob", CurrentJob);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerInternshipsAddButton_Click(object sender, EventArgs e)
        {
            string ProfessionalHealthExperienceType = PractitionerInternshipsDropDownList.SelectedItem.ToString();
            string InstituteName = PractitionerInternshipsInstituteNameText.Text;
            string City = PractitionerInternshipsInstituteCity.Text;
            string State = PractitionerInternshipsInstituteStateDropDownList.SelectedItem.ToString();
            string AreaOfExpertise = PractitionerInternshipsAreaDropDownList.SelectedItem.ToString();
            string PositionTitle = PractitionerInternshipNameOrTitle.Text;
            string Description = PractitionerInternshipsTextArea.Text;
            int CurrentJob = PractitionerInternshipsCurrentRadioButtonList.SelectedIndex;
            if ((InstituteName != "") && (City != "") && (PositionTitle != "") && (Description != ""))
            {
                insert_practitionersProfessionalHealthExperience(personID, ProfessionalHealthExperienceType, InstituteName, City, State, AreaOfExpertise, PositionTitle, Description, CurrentJob);
                clearPractitionersProfessionalHealthExperienceArea();
                get_practitionersProfessionalHealthExperiences();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please ensure all fields are selected or inputed.');", true);
            }
        }

        protected void PractitionerInternshipsClearButton_Click(object sender, EventArgs e)
        {
            PractitionerInternshipsAddButton.Visible = true;
            PractitionerInternshipsUpdateButton.Visible = false;
            PractitionerInternshipsDeleteButton.Visible = false;
            clearPractitionersProfessionalHealthExperienceArea();
        }

        private void insert_practitionersProfession(string PersonId, string ProfessionTitle, string Specialty, string NameOfCompany, string City, string State, string YearsInProfession, string AreaOfExpertise, int CurrentJob)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert_practitionersProfession", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //In parameters

                    cmd.Parameters.AddWithValue("PersonId", PersonId);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("ProfessionTitle", ProfessionTitle);
                    cmd.Parameters["ProfessionTitle"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("Specialty", Specialty);
                    cmd.Parameters["Specialty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("NameOfCompany", NameOfCompany);
                    cmd.Parameters["NameOfCompany"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("City", City);
                    cmd.Parameters["City"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("State", State);
                    cmd.Parameters["State"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("YearsInProfession", YearsInProfession);
                    cmd.Parameters["YearsInProfession"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("AreaOfExpertise", AreaOfExpertise);
                    cmd.Parameters["AreaOfExpertise"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("CurrentJob", CurrentJob);
                    cmd.Parameters["CurrentJob"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void PractitionerProfessionAddButton_Click(object sender, EventArgs e)
        {
            string ProfessionTitle = PractitionerProfessionNameOrTitle.Text;
            string Specialty = PractitionerProfessionSpecialty.Text;
            string NameOfCompany = PractitionerProfessionLocationText.Text;
            string City = PractitionerProfessionCity.Text;
            string State = PractitionerProfessionStateDropDownList.SelectedItem.ToString();
            string YearsInProfession = PractitionerYearsInLabelText.Text;
            string AreaOfExpertise = PractitionerProfessionDropDownList.SelectedItem.ToString();
            int CurrentJob = PractitionerProfessionCurrentRadioButtonList.SelectedIndex;
            if ((ProfessionTitle != "") && (Specialty != "") && (NameOfCompany != "") && (City != "") && (YearsInProfession != ""))
            {
                insert_practitionersProfession(personID, ProfessionTitle, Specialty, NameOfCompany, City, State, YearsInProfession, AreaOfExpertise, CurrentJob);
                clearPractitionersProfessionArea();
                get_practitionersProfessions();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please ensure all fields are selected or inputed.');", true);
            }
        }

        protected void PractitionerProfessionClearButton_Click(object sender, EventArgs e)
        {
            PractitionerProfessionAddButton.Visible = true;
            PractitionerProfessionUpdateButton.Visible = false;
            PractitionerProfessionDeleteButton.Visible = false;
            clearPractitionersProfessionArea();
        }

        //State Method

        private int getStateIndex(string state)
        {
            int stateIndex = 0;

            if (state.Equals("Alabama") || state.Equals("AL") || state.Equals("Al"))
            {
                stateIndex = 0;
            }
            else if (state.Equals("Alaska") || state.Equals("AK") || state.Equals("Ak"))
            {
                stateIndex = 1;
            }
            else if (state.Equals("Arizona") || state.Equals("AZ") || state.Equals("Az"))
            {
                stateIndex = 2;
            }
            else if (state.Equals("Arkansas") || state.Equals("AR") || state.Equals("Ar"))
            {
                stateIndex = 3;
            }
            else if (state.Equals("California") || state.Equals("CA") || state.Equals("Ca"))
            {
                stateIndex = 4;
            }
            else if (state.Equals("Colorado") || state.Equals("CO") || state.Equals("Co"))
            {
                stateIndex = 5;
            }
            else if (state.Equals("Connecticut") || state.Equals("CT") || state.Equals("Ct"))
            {
                stateIndex = 6;
            }
            else if (state.Equals("Delaware") || state.Equals("DE") || state.Equals("De"))
            {
                stateIndex = 7;
            }
            else if (state.Equals("District of Columbia") || state.Equals("DC") || state.Equals("Dc"))
            {
                stateIndex = 8;
            }
            else if (state.Equals("Florida") || state.Equals("FL") || state.Equals("Fl"))
            {
                stateIndex = 9;
            }
            else if (state.Equals("Georgia") || state.Equals("GA") || state.Equals("Ga"))
            {
                stateIndex = 10;
            }
            else if (state.Equals("Hawaii") || state.Equals("HI") || state.Equals("Hi"))
            {
                stateIndex = 11;
            }
            else if (state.Equals("Idaho") || state.Equals("ID") || state.Equals("Id"))
            {
                stateIndex = 12;
            }
            else if (state.Equals("Illinois") || state.Equals("IL") || state.Equals("Il"))
            {
                stateIndex = 13;
            }
            else if (state.Equals("Indiana") || state.Equals("IN") || state.Equals("In"))
            {
                stateIndex = 14;
            }
            else if (state.Equals("Iowa") || state.Equals("IA") || state.Equals("Ia"))
            {
                stateIndex = 15;
            }
            else if (state.Equals("Kansas") || state.Equals("KS") || state.Equals("Ks"))
            {
                stateIndex = 16;
            }
            else if (state.Equals("Kentucky") || state.Equals("KY") || state.Equals("Ky"))
            {
                stateIndex = 17;
            }
            else if (state.Equals("Louisiana") || state.Equals("LA") || state.Equals("La"))
            {
                stateIndex = 18;
            }
            else if (state.Equals("Maine") || state.Equals("ME") || state.Equals("Me"))
            {
                stateIndex = 19;
            }
            else if (state.Equals("Maryland") || state.Equals("MD") || state.Equals("Md"))
            {
                stateIndex = 20;
            }
            else if (state.Equals("Massachusetts") || state.Equals("MA") || state.Equals("Ma"))
            {
                stateIndex = 21;
            }
            else if (state.Equals("Michigan") || state.Equals("MI") || state.Equals("Mi"))
            {
                stateIndex = 22;
            }
            else if (state.Equals("Minnesota") || state.Equals("MN") || state.Equals("Mn"))
            {
                stateIndex = 23;
            }
            else if (state.Equals("Mississippi") || state.Equals("MS") || state.Equals("Ms"))
            {
                stateIndex = 24;
            }
            else if (state.Equals("Missouri") || state.Equals("MO") || state.Equals("Mo"))
            {
                stateIndex = 25;
            }
            else if (state.Equals("Montana") || state.Equals("MT") || state.Equals("Mt"))
            {
                stateIndex = 26;
            }
            else if (state.Equals("Nebraska") || state.Equals("NE") || state.Equals("Ne"))
            {
                stateIndex = 27;
            }
            else if (state.Equals("Nevada") || state.Equals("NV") || state.Equals("Nv"))
            {
                stateIndex = 28;
            }
            else if (state.Equals("New Hampshire") || state.Equals("NH") || state.Equals("Nh"))
            {
                stateIndex = 29;
            }
            else if (state.Equals("New Jersey") || state.Equals("NJ") || state.Equals("Nj"))
            {
                stateIndex = 30;
            }
            else if (state.Equals("New Mexico") || state.Equals("NM") || state.Equals("Nm"))
            {
                stateIndex = 31;
            }
            else if (state.Equals("New York") || state.Equals("NY") || state.Equals("Ny"))
            {
                stateIndex = 32;
            }
            else if (state.Equals("North Carolina") || state.Equals("NC") || state.Equals("Nc"))
            {
                stateIndex = 33;
            }
            else if (state.Equals("North Dakota") || state.Equals("ND") || state.Equals("Nd"))
            {
                stateIndex = 34;
            }
            else if (state.Equals("Ohio") || state.Equals("OH") || state.Equals("Oh"))
            {
                stateIndex = 35;
            }
            else if (state.Equals("Oklahoma") || state.Equals("OK") || state.Equals("Ok"))
            {
                stateIndex = 36;
            }
            else if (state.Equals("Oregon") || state.Equals("OR") || state.Equals("Or"))
            {
                stateIndex = 37;
            }
            else if (state.Equals("Pennsylvania") || state.Equals("PA") || state.Equals("Pa"))
            {
                stateIndex = 38;
            }
            else if (state.Equals("Puerto Rico") || state.Equals("PR") || state.Equals("Pr"))
            {
                stateIndex = 39;
            }
            else if (state.Equals("Rhode Island") || state.Equals("RI") || state.Equals("Ri"))
            {
                stateIndex = 40;
            }
            else if (state.Equals("South Carolina") || state.Equals("SC") || state.Equals("Sc"))
            {
                stateIndex = 41;
            }
            else if (state.Equals("South Dakota") || state.Equals("SD") || state.Equals("Sd"))
            {
                stateIndex = 42;
            }
            else if (state.Equals("Tennessee") || state.Equals("TN") || state.Equals("Tn"))
            {
                stateIndex = 43;
            }
            else if (state.Equals("Texas") || state.Equals("TX") || state.Equals("Tx"))
            {
                stateIndex = 44;
            }
            else if (state.Equals("Utah") || state.Equals("UT") || state.Equals("Ut"))
            {
                stateIndex = 45;
            }
            else if (state.Equals("Vermont") || state.Equals("VT") || state.Equals("Vt"))
            {
                stateIndex = 46;
            }
            else if (state.Equals("Virginia") || state.Equals("VA") || state.Equals("Va"))
            {
                stateIndex = 47;
            }
            else if (state.Equals("Virgin Islands") || state.Equals("VI") || state.Equals("Vi"))
            {
                stateIndex = 48;
            }
            else if (state.Equals("Washington") || state.Equals("WA") || state.Equals("Wa"))
            {
                stateIndex = 49;
            }
            else if (state.Equals("West Virginia") || state.Equals("WV") || state.Equals("Wv"))
            {
                stateIndex = 50;
            }
            else if (state.Equals("Wisconsin") || state.Equals("WI") || state.Equals("Wi"))
            {
                stateIndex = 51;
            }
            else if (state.Equals("Wyoming") || state.Equals("WY") || state.Equals("Wy"))
            {
                stateIndex = 52;
            }


            return stateIndex;
        }

    }
}