using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moreti_TG_39141004_Assessment_3
{
    public partial class Homepage : System.Web.UI.Page
    {

        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Givenchie\Desktop\ASPNET PROJECTS\Moreti_TG_39141004_Assessment 3\Moreti_TG_39141004_Assessment 3\App_Data\TicketsDB.mdf"";Integrated Security=True";

        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                    //PRIORITY
                PriorityDropDown.Items.Add("High");
                PriorityDropDown.Items.Add("Medium");
                PriorityDropDown.Items.Add("Low");


                    //STATUS
                StatusDropDown.Items.Add("Open");
                StatusDropDown.Items.Add("In progress");
                StatusDropDown.Items.Add("On hold");
                StatusDropDown.Items.Add("Resolved");


                    //DEPARTMENT
                DepartmentDropDown.Items.Add("IT");
                DepartmentDropDown.Items.Add("Management");
                DepartmentDropDown.Items.Add("Planning");
                DepartmentDropDown.Items.Add("Admin");
                DepartmentDropDown.Items.Add("Other");

            }
        }

        
       

        private bool IsValidDate()
        {
            DateTime todaysDate = DateTime.Today;
            DateTime selectedDate = Calendar1.SelectedDate;

            if(selectedDate < todaysDate) {

                return false;
            }
            return true;
        }

        //
        private DateTime GetSelectedDate()
        {
            return Calendar1.SelectedDate;
        }

        private bool IsValidFieldInputs()
        {
            return !string.IsNullOrEmpty(EmpId.Text) &&
                !string.IsNullOrEmpty(Name.Text) &&
                !string.IsNullOrEmpty(Email.Text) &&
                !string.IsNullOrEmpty(Comments.Text) &&
                !string.IsNullOrEmpty(IssueDescription.Text);
        }

        protected void CreateTicketBtn_Click1(object sender, EventArgs e)
        {
            try
            {
                if (IsValidFieldInputs() && IsValidDate())
                {

                    conn = new SqlConnection(connString);
                    adapter = new SqlDataAdapter();

                    conn.Open();

                    string employeeId = EmpId.Text;
                    string email = Email.Text;
                    string name = Name.Text;
                    string issueDescription = IssueDescription.Text;
                    string comments = Comments.Text;
                    DateTime date = GetSelectedDate();// select date

                    //inputs from drop downs
                    string status = StatusDropDown.SelectedItem.ToString();
                    string priority = PriorityDropDown.SelectedItem.ToString();
                    string department = DepartmentDropDown.SelectedItem.ToString();

                   
                    string insertUpdateQuery = @"IF NOT EXISTS (SELECT 1 FROM TicketsTable WHERE EmployeeId = @EmployeeId)
                            BEGIN
                                INSERT INTO TicketsTable (employeeId, email, name, issueDescription, comments, status, priority, department, date)
                                VALUES (@EmployeeId, @Email, @Name, @IssueDescription, @Comments, @Status, @Priority, @Department, @Date)
                            END
                            ELSE
                            BEGIN
                                UPDATE TicketsTable
                                SET email = @Email,
                                    name = @Name,
                                    issueDescription = @IssueDescription,
                                    comments = @Comments,
                                    status = @Status,
                                    priority = @Priority,
                                    department = @Department,
                                    date = @Date
                                WHERE EmployeeId = @EmployeeId
                            END
                        ";



                    cmd = new SqlCommand(insertUpdateQuery, conn);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@issueDescription", issueDescription);
                    cmd.Parameters.AddWithValue("@comments", comments);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@priority", priority);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@date", date);

                    adapter.InsertCommand = cmd;

                    int insertCount = adapter.InsertCommand.ExecuteNonQuery();

                    if (insertCount > 0)
                    {
                        //take user to the next page to see the list of tickets.
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        LblDisplay.Text = "Failed to create a ticket";
                    }
                }
                else
                {
                    Response.Write("Some Fields empty");
                }
            }
            catch (SqlException ex)
            {
                LblDisplay.Text = ex.Message;
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

        protected void SeeDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
    }
