using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moreti_TG_39141004_Assessment_3
{
    public partial class Dashboard : System.Web.UI.Page
    {

        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Givenchie\Desktop\ASPNET PROJECTS\Moreti_TG_39141004_Assessment 3\Moreti_TG_39141004_Assessment 3\App_Data\TicketsDB.mdf"";Integrated Security=True";
      
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommand cmd;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get all the data when the page loads.
          
           
                string searchQuery = "Select * from TicketsTable";
                CustomRetrieveMethod(searchQuery);
            
            
        }



        protected void GoHomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        //type here to start searching based on user id.


        private void CustomSearchMethod(string searchQuery,string searchKey)
        {
            try
            {
                if (IsPostBack) { 
                    con = new SqlConnection(connString);
                    adapter = new SqlDataAdapter();
                    con.Open();

                    cmd = new SqlCommand(searchQuery, con);
            
                    cmd.Parameters.AddWithValue("searchKey", searchKey);
                    ds = new DataSet();

                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    GridViewTickets.DataSource = ds;        //bind data sources
                    GridViewTickets.DataBind();
                }

            }
            catch(SqlException ex)
            {
                LblError.Text = ex.Message;     //user feedback
            }
            finally
            {
                con.Close();    //close connections.
            }

        }
 

        protected void SearchIdBtn_Click(object sender, EventArgs e)
        {
            //ideally when a user types any number the query should filter the available numbers and display accordingly.
            string searchKey = SearchById.Text;
            string searchQuery = "Select * from TicketsTable where EmployeeId Like @searchKey";
            CustomSearchMethod(searchQuery, searchKey);
        }

        private void CustomRetrieveMethod(string searchQuery)
        {
           
                try
                {
                    con = new SqlConnection(connString);
                    adapter = new SqlDataAdapter();
                    con.Open();

                    ds = new DataSet();
                    cmd = new SqlCommand(searchQuery, con);

                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    GridViewTickets.DataSource = ds;
                    GridViewTickets.DataBind();

                   
                }
                catch (Exception ex)
                {
                    LblError.Text = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            

        }

        //gets all the tickets from db when clicked
        protected void RetrieveAllBtn_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string searchQuery = "Select * from TicketsTable";
                CustomRetrieveMethod(searchQuery);
            }
        }

        protected void SearchDepartmentBtn_Click(object sender, EventArgs e)
        {
            string searchKey = SearchByDepartment.Text;
            string searchQuery = "Select * from TicketsTable where department Like @searchKey";
            CustomSearchMethod(searchQuery, searchKey);
        }

        protected void SearchByStatusBtn_Click(object sender, EventArgs e)
        {
            string searchKey = SearchByStatus.Text;
            string searchQuery = "Select * from TicketsTable where status Like @searchKey";
            CustomSearchMethod(searchQuery, searchKey);
        }

        protected void SearchIssueBtn_Click(object sender, EventArgs e)
        {
            string searchKey = SearchByIssue.Text;
            string searchQuery = "Select * from TicketsTable where issueDescription Like @searchKey";
            CustomSearchMethod(searchQuery, searchKey);
        }

        private void CustomDeleteMethod(string deleteQuery,int empId)
        {
            try
            {
                con = new SqlConnection(connString);
                adapter = new SqlDataAdapter();
                con.Open();

                cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("empId", empId);

                adapter.DeleteCommand = cmd;
               

               int deleteCount = adapter.DeleteCommand.ExecuteNonQuery();

                //check if ticket is closed successfully.
                if(deleteCount > 0)
                {
                    LblError.Text = $"Closed  ticket number {empId} successfully ";
                }
                else
                {
                    LblError.Text = "failed to close a ticket";
                }

            } catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
        protected void DeleteTicketBtn_Click(object sender, EventArgs e)
        {
            int empId = Int32.Parse(SearchById.Text);
            string query = $"Delete from TicketsTable where employeeId = @empId";
            if (empId >= 0)
            {

                CustomDeleteMethod(query, empId);
            }
            else
            {
                LblError.Text = "The employeeId field is blank";
                SearchById.Focus();
            }
        }

        protected void SearchPriorityBtn_Click(object sender, EventArgs e)
        {
            string searchKey = SearchByPriority.Text;
            string searchQuery = "Select * from TicketsTable where priority Like @searchKey";
            CustomSearchMethod(searchQuery, searchKey);
        }

        protected void UpdateTicketBtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("UpdateTicket.aspx");
            Response.Redirect("homepage.aspx");   //take user to the home page
        }

        protected void CreateTicketBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}