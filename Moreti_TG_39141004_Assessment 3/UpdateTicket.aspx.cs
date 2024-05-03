using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Moreti_TG_39141004_Assessment_3

    
{
   
    public partial class UpdateTicket : System.Web.UI.Page
    {

        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Givenchie\Desktop\ASPNET PROJECTS\Moreti_TG_39141004_Assessment 3\Moreti_TG_39141004_Assessment 3\App_Data\TicketsDB.mdf"";Integrated Security=True";

        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //PRIORITY
                PriorityDropDown1.Items.Add("High");
                PriorityDropDown1.Items.Add("Medium");
                PriorityDropDown1.Items.Add("Low");


                //STATUS
                StatusDropDown1.Items.Add("Open");
                StatusDropDown1.Items.Add("In progress");
                StatusDropDown1.Items.Add("On hold");
                StatusDropDown1.Items.Add("Resolved");


                //DEPARTMENT
                DepartmentDropDown1.Items.Add("IT");
                DepartmentDropDown1.Items.Add("Management");
                DepartmentDropDown1.Items.Add("Planning");
                DepartmentDropDown1.Items.Add("Admin");
                DepartmentDropDown1.Items.Add("Other");

            }
        }

        private void CustomRetrieveMethod(string searchQuery)
        {

            try
            {
                conn = new SqlConnection(connString);
                adapter = new SqlDataAdapter();
                conn.Open();

                ds1 = new DataSet();
                cmd = new SqlCommand(searchQuery, conn);

                cmd.Parameters.AddWithValue("@searchQuery",searchQuery);

                adapter.SelectCommand = cmd;

                adapter.Fill(ds1);
                
                //listview item

            }
            catch (Exception ex)
            {
                LblDisplay.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        protected void UpdateTicketBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string updateItem = EmpId1.Text;

                CustomRetrieveMethod("Select * from TicketsTable where EmployeeId = @updateItem");

                conn = new SqlConnection(connString);
                adapter = new SqlDataAdapter();

                //update Query
                string updateQuery = "Update TicketsTable SET name = @newName,email=@newEmail,issueDescription";

                cmd = new SqlCommand(updateQuery, conn);
                conn.Open();



            }catch(SqlException ex)
            {
                LblDisplay.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        //update page
        private bool IsValidDate()
        {
            DateTime todaysDate = DateTime.Today;
            DateTime selectedDate = Calendar2.SelectedDate;

            if (selectedDate < todaysDate)
            {

                return false;
            }
            return true;
        }

        //update page date
        private DateTime GetSelectedDate()
        {
            return Calendar2.SelectedDate;
        }

        private bool IsValidFieldInputs()
        {
            return !string.IsNullOrEmpty(EmpId1.Text) &&
                !string.IsNullOrEmpty(Name1.Text) &&
                !string.IsNullOrEmpty(Email1.Text) &&
                !string.IsNullOrEmpty(Comments1.Text) &&
                !string.IsNullOrEmpty(IssueDescription1.Text);
        }





    }
}