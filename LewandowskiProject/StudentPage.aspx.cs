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
        //Global Variables
        //Connection String to be used for accessing data from the database
        private string dbConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private string personID = "";
        //List of integers used to hold ID's of the Professional partners for later use
        private List<string> idList = new List<string>();
        //Variables used for the variety of stored procedures from mySQL
        private string firstNameStudent;
        private string lastNameStudent;
        private string graduationYearStudent;
        private string bio;
        private string majorStudent;
        private string minorStudent;
        private string yearInSchoolStudent;
        private string email;

        //Page Load. When the page loads, if the current logged in user is a student then they will have access to this page
        protected void Page_Load(object sender, EventArgs e)
        {
            //Add the code that gets the "logged in" person ID from the state.
            //If the page has not post backed yet, then we do the following
            if (!IsPostBack)
            {
                personID = Session["PersonId"].ToString();
                //Call get_studentInfo() to pre-load the information to the edit profile modal
                get_studentInfo();
                //An update method that goes when the modal is closed and updates the student information in the database
                update_studentInfo(firstNameStudent, lastNameStudent, yearInSchoolStudent, graduationYearStudent, bio, majorStudent, minorStudent);
                // Default Databinding of the Gridview that displays the Professional Partners basic information
                BindGridView();
            }
        }

        //BindGridView. This method get all the Professional partners that are currently in the Database and displays them in a gridview
        //It also saves a list of their ID's for use in displaying their information to the students
        public void BindGridView()
        {
            //Create a connection to the database and make a DataTable object
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            DataTable dt = new DataTable();
            //A MySQL query to select basic Professional Partner information where their usertype is practitioner. Refer to database of need be
            MySqlCommand cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.personId = contacts.personId and people.userType = 'practitioner' ", con);
            //Create an MySqlAdapter object to run the command query just made and use the adapter to fill the DataTable
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
            myAdapter.Fill(dt);
            //Set the Gridview's DataSource as the DataTable and Databind it to make it visible on the page
            PractitionerGridView.DataSource = dt;
            PractitionerGridView.DataBind();

            //Another Command query to get all the PersonID's from the table into a list for use in displaying the practitioner modal
            cmd = new MySqlCommand("Select people.PersonID as 'Person ID' from people where  people.userType = 'practitioner'", con);
            using (var command = new MySqlCommand(cmd.CommandText, con))
            {
                //Open Connection
                con.Open();
                //Read through the database and collect the personID's
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idList.Add(personID = reader[0].ToString());
                    }
                }
            }
            //Close Connection
            con.Close();
            //Session Variable for the list to persist between postbacks. Whenever the list is updated, save it to a session variable so it
            //will not be null when trying to use it.
            Session["PersonIds"] = idList;
        }

        //OnClick for Edit Profile button, which brings up a modal for the students to update their information if they need to
        protected void ClientButton_Click(object sender, EventArgs e)
        {
            mpe.Show();//ajax call to show the modal panel
        }

        //OnClick for View Practitioner Profile button in the gridView, which gets the current row index that the button was clicked in and 
        //gets the appropriate information into the modal for the practitioner's information.
        protected void BtnViewPractitionerProfile_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;

            //Clearing the Text Fields From The Last Click If There Was One
            resetPractitionerInformationLabels();

            //Assigning Practitioners Information Accross the Different Fields
            get_practitionerInfo(rowindex);
            get_practitionersEducations(rowindex);
            get_practitionersProfessionalHealthExperiences(rowindex);
            get_practitionersProfessions(rowindex);
            get_practitionersBio(rowindex);
            PractitionerGridView_ModalPopupExtender.Show();//ajax call to show the modal panel
        }

        protected void CloseButton_Click(object sender, EventArgs e)
        {
            mpe.Hide();//ajax call to close the panel
        }

        protected void PractitionerCloseButton_Click(object sender, EventArgs e)
        {
            PractitionerGridView_ModalPopupExtender.Hide();//ajax call to close the panel
        }

        private void resetPractitionerInformationLabels()
        {
            //Reseting the Practitioner Information Labels
            PractitionerFirstNameLabel.Text = "First Name: ";
            PractitionerLastNameLabel.Text = "Last Name: ";
            PractitionerGenderLabel.Text = "Gender: ";
            PractitionerPhoneNumberLabel.Text = "Phone Number: ";
            PractitionerEmailLabel.Text = "Email: ";
            PractitionerCityLabel.Text = "City: ";
            PractitionerStateLabel.Text = "State: ";

            //Reseting the Practitioner Educations Labels
            PractitionerEducationYearInLabel.Text = "Year In School: ";
            PractitionerEducationGradYearTextLabel.Text = "Graduation Year: ";
            PractitionerEducationDegreeEarnedDropDownListLabel.Text = "Degree Earned: ";
            PractitionerEducationMajorLabel.Text = "Degree Earned in/Major: ";
            PractitionerEducationMinorTextLabel.Text = "Minor: ";

            //Reseting the Practitioner Professional Health Experience Labels
            PractitionerExperiencesLabel.Text = "Type of Experience: ";
            PractitionerInternshipNameOrTitleLabel.Text = "Name/Title: ";
            PractitionerInternshipsAreaDropDownListLabel.Text = "Area of Expertise: ";
            PractitionerInternshipsInstituteNameTextLabel.Text = "Name of Institute: ";
            PractitionerInternshipsInstituteCityLabel.Text = "City: ";
            PractitionerInternshipsInstituteStateDropDownListLabel.Text = "State: ";
            PractitionerInternshipsTextAreaLabel.Text = "Description: ";
            PractitionerInternshipsCurrentRadioButtonListLabel.Text = "Currently Working at This Position: ";

            //Reseting the Practitioner Profession Labels
            PractitionerProfessionNameOrTitleLabel.Text = "Name/Title: ";
            PractitionerProfessionDropDownListLabel.Text = "Area of Expertise: ";
            PractitionerProfessionLocationTextLabel.Text = "Company Name: ";
            PractitionerProfessionCityLabel.Text = "City: ";
            PractitionerProfessionStateDropDownListLabel.Text = "State: ";
            PractitionerProfessionSpecialtyLabel.Text = "Specialty: ";
            PractitionerProfessionCurrentRadioButtonListLabel.Text = "Currently Working at This Position: ";
            PractitionerYearsInLabel.Text = "Years In Profession: ";

            //Reseting the Practitioner Bio Textbox
            PractitionerBioTextArea.Text = " ";
        }

        //Stored Procedure to gather the student information for the edit information modal.
        private void get_studentInfo()
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_studentInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //For use of Stored Procedures from MySql, use of input and/or output variables are used in order to get the needed information 
                    //from the database

                    //input parameter
                    //Local variables are used to hold the values used in the stored procedures parameters and to input values as well
                    //When using an input variable, the direction is input and it is output when using an output variable

                    cmd.Parameters.AddWithValue("personId", personID);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //output parameters

                    cmd.Parameters.AddWithValue("FirstName", firstNameStudent);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", lastNameStudent);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("BioResearchInterst", bio);
                    cmd.Parameters["BioResearchInterst"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email1", email);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the global variables to the stored procedures output variables. 
                    firstNameStudent = cmd.Parameters["FirstName"].Value.ToString();
                    lastNameStudent = cmd.Parameters["LastName"].Value.ToString();
                    bio = cmd.Parameters["BioResearchInterst"].Value.ToString();
                    email = cmd.Parameters["Email1"].Value.ToString();

                    //Assigning the global variables to the text field values.
                    FNameTextBox.Text = firstNameStudent;
                    LNameTextBox.Text = lastNameStudent;
                    BioTextArea.Text = bio;
                    EmailLabel.Text = EmailLabel.Text + email;
                }
            }
        }

        //Stored Procedure to update the student information in the edit profile modal.
        private void update_studentInfo(string firstName, string lastName, string yearInSchool, string graduationYear, string bio, string major, string minor)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_studentInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //input parameters

                    //Get all the information used in the Edit Profile Modal and execute the query to udpate that information in the database
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

        //Stored Procedure to update the student information in the edit profile modal.
        private void update_studentInfo(string firstName, string lastName, string bio, string major, string minor)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_studentInfo", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //input parameters

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

        //Stored Procedure to get the practitioner's basic information.
        private void get_practitionerInfo(int rowIndex)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionerInfo", con))
                {
                    //These are the Local Variables for use in the Stored Procedures
                    string practitionerFirst = "", practitionerLast = "", practitionerGender = "",
                        practitionerPhone = "", practitionerEmail = "", practitionerCity = "",
                        practitionerState = "";
                    int acceptsStudents = 0;

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Get the current list of practitioner person IDs from the session variable
                    string personId = "";
                    idList = (List<string>)Session["PersonIds"];

                    //Set the personId to the current value of the Id list with the current row index
                    personId = idList[rowIndex];

                    //input parameter

                    cmd.Parameters.AddWithValue("personId", personId);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    //output parameters

                    cmd.Parameters.AddWithValue("FirstName", practitionerFirst);
                    cmd.Parameters["FirstName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("LastName", practitionerLast);
                    cmd.Parameters["LastName"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Gender", practitionerGender);
                    cmd.Parameters["Gender"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Phone1", practitionerPhone);
                    cmd.Parameters["Phone1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("Email1", practitionerEmail);
                    cmd.Parameters["Email1"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("City", practitionerCity);
                    cmd.Parameters["City"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("State", practitionerState);
                    cmd.Parameters["State"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("AcceptsStudents", acceptsStudents);
                    cmd.Parameters["AcceptsStudents"].Direction = ParameterDirection.Output;

                    //Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    //Save the parameter values to local variables and display them in their respective labels
                    practitionerFirst = cmd.Parameters["FirstName"].Value.ToString();
                    practitionerLast = cmd.Parameters["LastName"].Value.ToString();
                    practitionerGender = cmd.Parameters["Gender"].Value.ToString();
                    practitionerPhone = cmd.Parameters["Phone1"].Value.ToString();
                    practitionerEmail = cmd.Parameters["Email1"].Value.ToString();
                    practitionerCity = cmd.Parameters["City"].Value.ToString();
                    practitionerState = cmd.Parameters["State"].Value.ToString();
                    try
                    {
                        acceptsStudents = Convert.ToInt16(cmd.Parameters["AcceptsStudents"].Value.ToString());
                    }
                    catch
                    {
                        acceptsStudents = -1;
                    }
                    PractitionerFirstNameLabel.Text += practitionerFirst;
                    PractitionerLastNameLabel.Text += practitionerLast;
                    PractitionerGenderLabel.Text += practitionerGender;
                    PractitionerPhoneNumberLabel.Text += practitionerPhone;
                    PractitionerEmailLabel.Text += practitionerEmail;
                    PractitionerCityLabel.Text += practitionerCity;
                    PractitionerStateLabel.Text += practitionerState;

                    if (acceptsStudents == 0)
                    {
                        PractitionerAcceptsStudents.Text = "Currently Accepting Students: Yes";
                    }
                    else if (acceptsStudents == 1)
                    {
                        PractitionerAcceptsStudents.Text = "Currently Accepting Students: No";
                    }
                    else
                    {
                        PractitionerAcceptsStudents.Text = "Currently Accepting Students: Did Not Specify";
                    }
                }
            }
        }

        //Stored Procedure to get the practitioner's education information.
        private void get_practitionersEducations(int rowIndex)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables for use in the Stored Procedures
                string InstitutionName = "", EducationId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersEducations", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    string personId = "";
                    idList = (List<string>)Session["PersonIds"];

                    personId = idList[rowIndex];

                    //input parameters

                    cmd.Parameters.AddWithValue("personId", personId);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    //This if statement checks if the practitioner has multiple educations and displays them with the first education populating 
                    //the modal. It also changes the visibility of the dropdownlist depending on if the practitioner has multiple educations or not.
                    if (myReader.HasRows)
                    {
                        PractitionerAddEducationDropDownList.Visible = true;
                        PractitionerAddEducationDropDownList.Items.Clear();
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
                    }
                }
            }
        }

        //This method updates the Practioner Modal if the user chooses a different value from the Pratictioner's Educations dropdownlist
        protected void PractitionerAddEducationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int EducationId = Convert.ToInt16(PractitionerAddEducationDropDownList.SelectedItem.Value);
            get_practitionersEducation(EducationId);
            PractitionerGridView_ModalPopupExtender.Show();
        }

        //Stored Procedure to display the practitioner's education information.
        private void get_practitionersEducation(int EducationId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables for use in the Stored Procedures
                string InstitutionName = "", YearInSchool = "", GraduationYear = "", DegreeEarned = "", Major = "", Minor = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersEducation", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Input parameter

                    cmd.Parameters.AddWithValue("EducationId", EducationId);
                    cmd.Parameters["EducationId"].Direction = ParameterDirection.Input;

                    //output parameters

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
                    PractitionerEducationYearInLabel.Text = "Year In School: " + YearInSchool;
                    PractitionerEducationGradYearTextLabel.Text = "Graduation Year: " + GraduationYear;
                    PractitionerEducationDegreeEarnedDropDownListLabel.Text = "Degree Earned: " + DegreeEarned;
                    PractitionerEducationMajorLabel.Text = "Major: " + Major;
                    PractitionerEducationMinorTextLabel.Text = "Minor: " + Minor;
                }
            }
        }

        //Stored Procedure to get the practitioner's professional health experiences information.
        private void get_practitionersProfessionalHealthExperiences(int rowIndex)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables for use in the Stored Procedures
                string InstituteName = "";
                string PositionTitle = "";
                string ProfessionalHealthExperienceId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessionalHealthExperiences", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    string personId = "";
                    idList = (List<string>)Session["PersonIds"];

                    personId = idList[rowIndex];

                    //input parameter

                    cmd.Parameters.AddWithValue("personId", personId);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    //This if statement checks if the practitioner has multiple professional health experiences and displays them with the first professional health experience
                    //populating the modal fields. It also changes the visibility of the dropdownlist depending on if the practitioner has multiple professional health experiences or not.
                    if (myReader.HasRows)
                    {
                        PractitionerAddInternshipsDropDownList.Visible = true;
                        PractitionerAddInternshipsDropDownList.Items.Clear();

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
                    }
                }
            }
        }

        //This method updates the Practioner Modal if the user chooses a different value from the Pratictioner's Health Experiences dropdownlist
        protected void PractitionerAddInternshipsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProfessionalHealthExperienceId = Convert.ToInt16(PractitionerAddInternshipsDropDownList.SelectedItem.Value);
            get_practitionersProfessionalHealthExperience(ProfessionalHealthExperienceId);
            PractitionerGridView_ModalPopupExtender.Show();
        }

        //Stored Procedure to display the practitioner's professional health experiences information.
        private void get_practitionersProfessionalHealthExperience(int ProfessionalHealthExperienceId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables for use in the Stored Procedures
                string professionalHealthExperienceType = "", instituteName = "", city = "", state = "", areaOfExpertise = "", positionTitle = "", description = "";
                // not using yearsInExperience but keep if we want to later
                string yearsInExperience = "";
                int currentJob = 0;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessionalHealthExperience", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Input parameter

                    cmd.Parameters.AddWithValue("ProfessionalHealthExperienceId", ProfessionalHealthExperienceId);
                    cmd.Parameters["ProfessionalHealthExperienceId"].Direction = ParameterDirection.Input;

                    //Output parameters

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
                    PractitionerExperiencesLabel.Text = "Type of experience: " + professionalHealthExperienceType;
                    PractitionerInternshipNameOrTitleLabel.Text = "Name/Title: " + positionTitle;
                    PractitionerInternshipsAreaDropDownListLabel.Text = "Area of Expertise: " + areaOfExpertise;
                    PractitionerInternshipsInstituteNameTextLabel.Text = "Name of Institute:" + instituteName;
                    PractitionerInternshipsInstituteCityLabel.Text = "Name of City: " + city;
                    PractitionerInternshipsInstituteStateDropDownListLabel.Text = "State: " + state;
                    PractitionerInternshipsTextAreaLabel.Text = "Description: " + description;

                    //if else statement determining if the practitioner is Currently Working or not               
                    if (currentJob == 0)
                    {
                        PractitionerInternshipsCurrentRadioButtonListLabel.Text = "Currently Working at This Position: Yes";
                    }
                    else
                    {
                        PractitionerInternshipsCurrentRadioButtonListLabel.Text = "Currently Working at This Position: No";
                    }
                }
            }
        }

        //Stored Procedure to get the practitioner's profession information.
        private void get_practitionersProfessions(int rowIndex)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {

                //These are the Local Variables for use in the Stored Procedures
                string NameOfCompany = "", ProfessionTitle = "", ProfessionId = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfessions", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    string personId = "";
                    idList = (List<string>)Session["PersonIds"];

                    personId = idList[rowIndex];

                    //input parameter

                    cmd.Parameters.AddWithValue("personId", personId);
                    cmd.Parameters["personId"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    MySqlDataReader myReader;
                    myReader = cmd.ExecuteReader();
                    //This if statement checks if the practitioner has multiple professions and displays them with the first profession populating the modal
                    //fields. It also changes the visibility of the dropdownlist depending on if the practitioner has multiple professions or not.
                    if (myReader.HasRows)
                    {
                        PractitionerAddPrfessionDropDownList.Visible = true;
                        PractitionerAddPrfessionDropDownList.Items.Clear();
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
                    }
                }
            }
        }

        //This method updates the Practioner Modal if the user chooses a different value from the Pratictioner's Professions dropdownlist
        protected void PractitionerAddPrfessionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProfessionId = Convert.ToInt16(PractitionerAddPrfessionDropDownList.SelectedItem.Value);
            get_practitionersProfession(ProfessionId);
            PractitionerGridView_ModalPopupExtender.Show();
        }

        //Stored Procedure to display the practitioner's profession information.
        private void get_practitionersProfession(int ProfessionId)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables for use in the Stored Procedures
                string professionTitle = "", specialty = "", nameOfCompany = "", city = "", state = "", yearsInProfession = "", areaOfExpertise = "";
                int currentJob = 0;

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersProfession", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Input parameter

                    cmd.Parameters.AddWithValue("ProfessionId", ProfessionId);
                    cmd.Parameters["ProfessionId"].Direction = ParameterDirection.Input;

                    //output parameters

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
                    PractitionerProfessionNameOrTitleLabel.Text = "Name/Title: " + professionTitle;
                    PractitionerProfessionDropDownListLabel.Text = "Area of Expertise: " + areaOfExpertise;
                    PractitionerProfessionLocationTextLabel.Text = "Company Name: " + nameOfCompany;
                    PractitionerProfessionCityLabel.Text = "City: " + city;
                    PractitionerProfessionStateDropDownListLabel.Text = "State: " + state;
                    PractitionerProfessionSpecialtyLabel.Text = "Specialty: " + specialty;

                    //if else statement determining if the practitioner is Currently Working or not             
                    if (currentJob == 0)
                    {
                        PractitionerProfessionCurrentRadioButtonListLabel.Text = "Currently Working at This Position: Yes";
                    }
                    else
                    {
                        PractitionerProfessionCurrentRadioButtonListLabel.Text = "Currently Working at This Position: No";
                    }

                    PractitionerYearsInLabel.Text = "Years In Profession: " + yearsInProfession;
                }
            }
        }

        //Stored Procedure to display the practitioner's bio.
        private void get_practitionersBio(int rowIndex)
        {
            using (MySqlConnection con = new MySqlConnection(dbConnectionString))
            {
                //These are the Local Variables for use in the Stored Procedures
                string Bio = "";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("get_practitionersBio", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    string personId = "";
                    idList = (List<string>)Session["PersonIds"];

                    personId = idList[rowIndex];

                    //Input parameter

                    cmd.Parameters.AddWithValue("PersonId", personId);
                    cmd.Parameters["PersonId"].Direction = ParameterDirection.Input;

                    //Output parameters

                    cmd.Parameters.AddWithValue("Bio", Bio);
                    cmd.Parameters["Bio"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //Assigning the Parameters to the Local Variables
                    Bio = cmd.Parameters["Bio"].Value.ToString();

                    //Assigning the Fields Text or Index to the Local Variables
                    PractitionerBioTextArea.Text = Bio;
                }
            }
        }

        //On Click method for the Reset List button
        protected void resetButton_Click(object sender, EventArgs e)
        {
            //Reset the gridview, dropdownlists, and textboxes used for filtering to their default state
            BindGridView();
            professionDropDown.SelectedIndex = 0;
            cityTextBox.Text = "";
            yearTextBox.Text = "";
            stateDropDown.SelectedIndex = 0;
            searchTextBox.Text = "";
        }

        //Method for determining how the gridview will be filtered based on what the user inputs into the three textboxes and two dropdownlists
        //Pass in two commands, one for displaying the information in the gridview and a second one for creating the list of person ids for the filtered
        //data being displayed.
        private void filterGridView(MySqlCommand cmd, MySqlCommand listCmd)
        {
            //Create a connection to the database and create a datatable for use in data binding the gridview
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            DataTable dt = new DataTable();
            //Case if only state and profession are being used in filtering
            if (!stateDropDown.SelectedValue.Equals("Select State") && !professionDropDown.SelectedValue.Equals("Select Profession") &&
                searchTextBox.Text.Equals("") && cityTextBox.Text.Equals("") && yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                 " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                 "and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" + professionDropDown.SelectedValue + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" + professionDropDown.SelectedValue + "'", con);
            }
            //Case if only first/last name and state and profession are being used in filtering
            else if (!stateDropDown.SelectedValue.Equals("Select State") && !professionDropDown.SelectedValue.Equals("Select Profession")
                && !searchTextBox.Text.Equals("") && cityTextBox.Text.Equals("") && yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                "and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" + professionDropDown.SelectedValue + "' and " +
                "(people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" + professionDropDown.SelectedValue + "' and " +
                "(people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);
            }
            //Case if only state and city are being used in filtering
            else if (!stateDropDown.SelectedValue.Equals("Select State") && !cityTextBox.Text.Equals("") && professionDropDown.SelectedValue.Equals("Select Profession")
               && searchTextBox.Text.Equals("") && yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                "and people.State = '" + stateDropDown.SelectedValue + "' and people.City = '" + cityTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.State = '" + stateDropDown.SelectedValue + "' and people.City = '" + cityTextBox.Text + "'", con);
            }
            //Case if only first/last name and state are being used in filtering
            else if (!stateDropDown.SelectedValue.Equals("Select State") && !searchTextBox.Text.Equals("") && professionDropDown.SelectedValue.Equals("Select Profession")
               && cityTextBox.Text.Equals("") && yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                "and people.State = '" + stateDropDown.SelectedValue + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.State = '" + stateDropDown.SelectedValue + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);
            }
            //Case if only state and year are being used in filtering
            else if (!stateDropDown.SelectedValue.Equals("Select State") && !yearTextBox.Text.Equals("") && professionDropDown.SelectedValue.Equals("Select Profession")
               && searchTextBox.Text.Equals("") && cityTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts, educations Where people.PersonId = contacts.PersonId and people.PersonId = educations.PersonId and people.userType = 'practitioner' " +
                "and people.State = '" + stateDropDown.SelectedValue + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people, educations where people.userType = 'practitioner' and people.PersonId = educations.PersonId " +
                 "and people.State = '" + stateDropDown.SelectedValue + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);
            }
            //Case if only profession and city are being used in filtering
            else if (!professionDropDown.SelectedValue.Equals("Select Profession") && !cityTextBox.Text.Equals("") && stateDropDown.SelectedValue.Equals("Select State")
               && searchTextBox.Text.Equals("") && yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                "and people.Title = '" + professionDropDown.SelectedValue + "' and people.City = '" + cityTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.Title = '" + professionDropDown.SelectedValue + "' and people.City = '" + cityTextBox.Text + "'", con);
            }
            //Case if only first/last name and profession are being used in filtering
            else if (!professionDropDown.SelectedValue.Equals("Select Profession") && !searchTextBox.Text.Equals("") && stateDropDown.SelectedValue.Equals("Select State")
               && cityTextBox.Text.Equals("") && yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                "and people.Title = '" + professionDropDown.SelectedValue + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.Title = '" + professionDropDown.SelectedValue + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);
            }
            //Case if only profession and year are being used in filtering
            else if (!professionDropDown.SelectedValue.Equals("Select Profession") && !yearTextBox.Text.Equals("") && stateDropDown.SelectedValue.Equals("Select State")
               && searchTextBox.Text.Equals("") && cityTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts, educations Where people.PersonId = contacts.PersonId and people.PersonId = educations.PersonId and people.userType = 'practitioner' " +
                "and people.Title = '" + professionDropDown.SelectedValue + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people, educations where people.userType = 'practitioner' and people.PersonId = educations.PersonId " +
                 "and people.Title = '" + professionDropDown.SelectedValue + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);
            }
            //Case if only first/last name and city are being used in filtering
            else if (!cityTextBox.Text.Equals("") && !searchTextBox.Text.Equals("") && stateDropDown.SelectedValue.Equals("Select State") &&
                yearTextBox.Text.Equals("") && professionDropDown.SelectedValue.Equals("Select Profession"))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                "and people.City = '" + cityTextBox.Text + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.City = '" + cityTextBox.Text + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);
            }
            //Case if only city and year are being used in filtering
            else if (!cityTextBox.Text.Equals("") && !yearTextBox.Text.Equals("") && stateDropDown.SelectedValue.Equals("Select State")
               && searchTextBox.Text.Equals("") && professionDropDown.SelectedValue.Equals("Select Profession"))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts, educations Where people.PersonId = contacts.PersonId and people.PersonId = educations.PersonId and people.userType = 'practitioner' " +
                "and people.City = '" + cityTextBox.Text + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people, educations where people.userType = 'practitioner' and people.PersonId = educations.PersonId " +
                 "and people.City = '" + cityTextBox.Text + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);
            }
            //Case if only first/last name and year are being used in filtering
            else if (!searchTextBox.Text.Equals("") && !yearTextBox.Text.Equals("") && stateDropDown.SelectedValue.Equals("Select State") &&
                professionDropDown.SelectedValue.Equals("Select Profession") && cityTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts, educations Where people.PersonId = contacts.PersonId and people.PersonId = educations.PersonId and people.userType = 'practitioner' " +
                "and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "') and educations.GraduationYear = '" + yearTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people, educations where people.userType = 'practitioner' and people.PersonId = educations.PersonId " +
                 "and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "') and educations.GraduationYear = '" + yearTextBox.Text + "'", con);
            }
            //Case if only state, profession, first/last name and city are being used in filtering
            else if (!stateDropDown.SelectedValue.Equals("Select State") && !professionDropDown.SelectedValue.Equals("Select Profession")
               && !searchTextBox.Text.Equals("") && !cityTextBox.Text.Equals("") && yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                "and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" + professionDropDown.SelectedValue + "' and " +
                "(people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "') and people.City = '" +
                cityTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' " +
                 "and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" + professionDropDown.SelectedValue + "' and " +
                "(people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "') and people.City = '" +
                cityTextBox.Text + "'", con);
            }
            //Case of all 5 fields are being used in filtering
            else if (!stateDropDown.SelectedValue.Equals("Select State") && !professionDropDown.SelectedValue.Equals("Select Profession")
               && !searchTextBox.Text.Equals("") && !cityTextBox.Text.Equals("") && !yearTextBox.Text.Equals(""))
            {
                cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                " contacts.Phone1 as 'Phone' From people, contacts, educations Where people.PersonId = contacts.PersonId and people.PersonId = educations.PersonId " +
                "and people.userType = 'practitioner' and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" +
                professionDropDown.SelectedValue + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text
                + "') and people.City = '" + cityTextBox.Text + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);

                listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people, educations where and people.PersonId = educations.PersonId" +
                " and people.userType = 'practitioner' and people.State = '" + stateDropDown.SelectedValue + "' and people.Title = '" +
                professionDropDown.SelectedValue + "' and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text +
                "') and people.City = '" + cityTextBox.Text + "' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);
            }

            //Bind the data to the gridview and displays it
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
            myAdapter.Fill(dt);
            PractitionerGridView.DataSource = dt;
            PractitionerGridView.DataBind();

            //Run the listCmd and save the person ids to the list for use in the practitioner modal
            using (var command = new MySqlCommand(listCmd.CommandText, con))
            {
                con.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idList.Add(personID = reader[0].ToString());
                    }
                }
            }
            con.Close();
            Session["PersonIds"] = idList;
        }

        //Method for filtering with the state dropdown list
        protected void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            //Default command for use in databinding for filtering
            MySqlCommand cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                 " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                 "and people.State = '" + stateDropDown.SelectedValue + "'", con);
            //Default command for getting the list of corresponding person ids
            MySqlCommand listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where  people.userType = 'practitioner' and people.State = " +
                "'" + stateDropDown.SelectedValue + "'", con);
            //Call to the filterGridView method, passing in the two default commands for use in the filtering
            filterGridView(cmd, listCmd);
        }

        //Method for filtering with the profession dropdown list
        protected void professionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            //Default command for use in databinding for filtering
            MySqlCommand cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                 " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                 "and people.Title = '" + professionDropDown.SelectedValue + "'", con);
            //Default command for getting the list of corresponding person ids
            MySqlCommand listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where people.userType = 'practitioner' and people.Title = " +
                "'" + professionDropDown.SelectedValue + "'", con);
            //Call to the filterGridView method, passing in the two default commands for use in the filtering
            filterGridView(cmd, listCmd);
        }

        //Method for filtering with the search textbox for first or last name
        protected void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            //Default command for use in databinding for filtering
            MySqlCommand cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
                  " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
                  "and (people.LastName = '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);
            //Default command for getting the list of corresponding person ids
            MySqlCommand listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where people.userType = 'practitioner' and (people.LastName " +
                "= '" + searchTextBox.Text + "' or people.FirstName = '" + searchTextBox.Text + "')", con);
            //Call to the filterGridView method, passing in the two default commands for use in the filtering
            filterGridView(cmd, listCmd);
        }

        //Method for filtering with the city textbox
        protected void cityTextBox_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            //Default command for use in databinding for filtering
            MySqlCommand cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
            " contacts.Phone1 as 'Phone' From people, contacts Where people.PersonId = contacts.PersonId and people.userType = 'practitioner' " +
            "and people.City = '" + cityTextBox.Text + "'", con);
            //Default command for getting the list of corresponding person ids
            MySqlCommand listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people where people.userType = 'practitioner' and people.City = " +
                "'" + cityTextBox.Text + "'", con);
            //Call to the filterGridView method, passing in the two default commands for use in the filtering
            filterGridView(cmd, listCmd);
        }

        //Method for filtering with the year text box
        protected void yearTextBox_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            //Default command for use in databinding for filtering
            MySqlCommand cmd = new MySqlCommand("Select people.FirstName as 'First Name', people.LastName as 'Last Name',contacts.Email1 as 'Email'," +
            " contacts.Phone1 as 'Phone' From people, contacts, educations Where people.PersonId = contacts.PersonId and people.PersonId = educations.PersonId" +
            " and people.userType = 'practitioner' and educations.GraduationYear = '" + yearTextBox.Text + "'", con);
            //Default command for getting the list of corresponding person ids
            MySqlCommand listCmd = new MySqlCommand("Select people.PersonId as 'Person ID' from people, educations where people.userType = " +
                "'practitioner' and people.PersonId = educations.PersonId and educations.GraduationYear = '" + yearTextBox.Text + "'", con);
            //Call to the filterGridView method, passing in the two default commands for use in the filtering
            filterGridView(cmd, listCmd);
        }
    }
}