<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Moreti_TG_39141004_Assessment_3.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link rel="stylesheet" href="styles.css" type="text/css" />
<head runat="server">
    <title>Ticket logger</title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <div>
                        <h1>Log IT Tickets</h1>
                    </div>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td>
                    <div class="TicketDetails">

                        <div class="EmplIdClass">
                            <div class="EmplIdClass">
                                <asp:TextBox ID="EmpId" runat="server" placeholder="Employee id"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmpId" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="EmplIdClass">
                                <asp:TextBox ID="Name" runat="server" placeholder="Employee Name"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Name" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="EmplIdClass">
    <asp:TextBox ID="IssueDescription" runat="server" placeholder="Issue Description"></asp:TextBox><br />
    <asp:RequiredFieldValidator ControlToValidate="IssueDescription" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
</div>

                            <div class="EmplIdClass">
                                <asp:TextBox ID="Email" runat="server" placeholder="Email"></asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            
                        </div>

                        <div class="EmplIdClass">
                            <div class="statusDB">
                                <h3>Status</h3>
                                <asp:DropDownList ID="StatusDropDown" runat="server"></asp:DropDownList>
                            </div>
                            <div class="priorityDB">
                                <h3>Priority</h3>
                                <asp:DropDownList ID="PriorityDropDown" runat="server"></asp:DropDownList><br />
                            </div>
                            <div class="departmentDB">
                                <h3>Department</h3>
                            <asp:DropDownList ID="DepartmentDropDown" runat="server"></asp:DropDownList><br />
                            </div>
                        </div>

                        <div class="EmplIdClass">
                            <asp:TextBox ID="Comments" runat="server" placeholder="Comments" Rows="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="Comments" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div>
                            <h2>When do you expect the problem to be resolved?</h2>
                            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        </div>

                        <asp:Button ID="CreateTicketBtn" runat="server" Text="Create Ticket" OnClick="CreateTicketBtn_Click1" />
                       
                        

                    </div>


                    <div>
                    </div>
                    <asp:Label ID="LblDisplay" runat="server" Text=""></asp:Label>

                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>

        </table>


    </form>
</body>

</html>

